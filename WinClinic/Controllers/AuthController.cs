using bStudioHospital.Model;
using bStudioHospital.Model.Staff;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WinClinic.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<Staff> _userManager;
        private readonly SignInManager<Staff> _signInManager;
        public IHostingEnvironment _env { get; }
        private readonly DataContext db;

        public AuthController(UserManager<Staff> userManager, SignInManager<Staff> signInManager, DbContextOptions<DataContext> contextOptions, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = new DataContext(contextOptions);
            _env = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Staff user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var _user = await _userManager.FindByNameAsync(user.UserName);
            if (_user == null)
                return BadRequest(new { Message = "User name or password did not match any user" });
            if (!await _userManager.CheckPasswordAsync(_user, user.Password))
                return Unauthorized();
            var claims = await _userManager.GetClaimsAsync(_user);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xRBqwa5UtkVhr9w"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _env.IsProduction() ? "http://localhost:8097" : "https://localhost:44365",
                audience: _env.IsProduction() ? "http://localhost:8097" : "https://localhost:44365",
                claims: claims,
                expires: DateTime.Now.AddMonths(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Staff user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                return BadRequest(new { Message = result.Errors.First().Description });
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
            var _user = await _userManager.FindByIdAsync(user.Id);
            await _signInManager.SignInAsync(_user, true);
            await db.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> AddClaim([FromBody]Staff staff, string role)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var user = await _userManager.FindByIdAsync(staff.Id);
            if (user == null)
                return BadRequest("Could not find user to add role");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveClaim([FromBody]Staff staff, string role)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var user = await _userManager.FindByIdAsync(staff.Id);
            if (user == null)
                return BadRequest("Could not find user to add role");
            await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, role));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Accepted();
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                var claim = await _userManager.GetClaimsAsync(userToVerify);
                return claim as ClaimsIdentity;
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
