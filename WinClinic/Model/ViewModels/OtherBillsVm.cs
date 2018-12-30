using System;

namespace WinClinic.Models.ViewModels
{
    public class OtherBillsVm
    {
        public Guid ID { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public ItemTypes ItemTypes { get; set; }
    }

    public enum ItemTypes
    {
        Discounts = 1,
        Credits,
        Balance
    }
}
