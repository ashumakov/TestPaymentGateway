using System;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Core.DataAccess.Models;

namespace PaymentGateway.Core.DataAccess.Seeds
{
    public static class Merchants
    {
        public static Merchant[] PopulateMerchants(this ModelBuilder modelBuilder)
        {
            var result = new[]
            {
                new Merchant
                {
                    Id = new Guid("daf008ed-beff-44c0-a67b-f256e650fe5f"),
                    Name = "Test merchant",
                    Description = "Shop that provides some good",
                    BankAccountNumber = "11111111111111111111111",
                    SigningKey = "Q#!SIPYCGOzcUGqDhMWAMizy9Wb9lt"
                }
            };

            modelBuilder.Entity<Merchant>().HasData(result);

            return result;
        }
    }
}