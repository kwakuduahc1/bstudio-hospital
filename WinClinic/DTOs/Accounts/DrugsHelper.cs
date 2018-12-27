using WinClinic.Model;
using WinClinic.Model.Accounts;
using WinClinic.Model.ConsultingRoom;
using WinClinic.Model.OPD;
using WinClinic.Model.Pharmacy;
using WinClinic.Model.Records;
using WinClinic.Model.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinClinic.DTOs.Accounts
{
    public class DrugsHelper
    {
        readonly DataContext db;

        public DrugsHelper(DbContextOptions<DataContext> context) => db = new DataContext(context);

        public Task<List<Drugs>> Drugs() => Task.Run(async () => await db.Drugs.ToListAsync());

        public Task<List<DrugCodes>> DrugCodes(Guid scheme) => Task.Run(async () => await db.DrugCodes.Include(x => x.Drugs).ToListAsync());

        public void AddDrugs(Drugs drug) => db.Add(drug);

        public void AddDrugCodes(DrugCodes codes) => db.Add(codes);

        public Task<int> Save() => Task.Run(async () => await db.SaveChangesAsync());

    //    public Task

    }
}
