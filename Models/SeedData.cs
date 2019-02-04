using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BillApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FeeItemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FeeItemContext>>()))
            {
                // Look for any movies.
                if (context.FeeItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.FeeItem.AddRange(
                    new FeeItem
                    {
                        TransactionDate = DateTime.Parse("1989-2-12"),
                        Notes = "Headache",
                        Code = 113M
                    },

                    new FeeItem
                    {
                        TransactionDate = DateTime.Parse("1984-3-13"),
                        Notes = "Migraine",
                        Code = 114M
                    },

                    new FeeItem
                    {
                        TransactionDate = DateTime.Parse("1986-2-23"),
                        Notes = "Hearing Loss",
                        Code = 115M
                    },

                    new FeeItem
                    {
                        TransactionDate = DateTime.Parse("1959-4-15"),
                        Notes = "Cold",
                        Code = 116M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}