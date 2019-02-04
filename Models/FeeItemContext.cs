using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BillApp.Models
{
    public class FeeItemContext : DbContext
    {
        public FeeItemContext (DbContextOptions<FeeItemContext> options)
            : base(options)
        {
        }

        public DbSet<BillApp.Models.FeeItem> FeeItem { get; set; }
    }
}