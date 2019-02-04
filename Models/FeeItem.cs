using System;
using System.ComponentModel.DataAnnotations;

namespace BillApp.Models
{
    public class FeeItem
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
        public decimal Code { get; set; }
        public string Notes { get; set; }

    }
}