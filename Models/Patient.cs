using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalHealthNumber { get; set; }

        public List<FeeItem> FeeItems { get; set; }
    }
}