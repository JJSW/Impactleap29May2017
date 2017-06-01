using Impactleap29May2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impactleap29May2017.Data
{
    public class DbInitializer
    {
        // This provides seed data for the database once it is initialized by Entity Framework

        public static void Initialize(ClientContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.FreeReports.Any())
            {
                return;   // DB has been seeded
            }

            var FreeReports = new FreeReport[]
            {
            new FreeReport{Name="Joe Bloggs",Email="j.bloggs@email.com",Company="PwC",SignUpDate=DateTime.Parse("2017-01-01")},
            new FreeReport{Name="Jane Doe",Email="j.doe@email.com",Company="TELUS",SignUpDate=DateTime.Parse("2017-02-02")},
            new FreeReport{Name="Adam Smith",Email="adam.smith@email.com",Company="PwC",SignUpDate=DateTime.Parse("2017-03-03")},
            new FreeReport{Name="Christie Stephenson",Email="c.stephenson@email.com",Company="UBC Sauder",SignUpDate=DateTime.Parse("2017-04-04")},
            new FreeReport{Name="Richard Muller",Email="r.muller@email.com",Company="TONIIC",SignUpDate=DateTime.Parse("2017-05-05")}
            };
            foreach (FreeReport f in FreeReports)
            {
                context.FreeReports.Add(f);
            }
            context.SaveChanges();

            var Newsletters = new Newsletter[]
            {
            new Newsletter{Name="Joe Bloggs",Email="j.bloggs@email.com",Company="PwC",SignUpDate=DateTime.Parse("2017-01-01")},
            new Newsletter{Name="Jane Doe",Email="j.doe@email.com",Company="TELUS",SignUpDate=DateTime.Parse("2017-02-02")},
            new Newsletter{Name="Adam Smith",Email="adam.smith@email.com",Company="PwC",SignUpDate=DateTime.Parse("2017-03-03")},
            new Newsletter{Name="Christie Stephenson",Email="c.stephenson@email.com",Company="UBC Sauder",SignUpDate=DateTime.Parse("2017-04-04")},
            new Newsletter{Name="Richard Muller",Email="r.muller@email.com",Company="TONIIC",SignUpDate=DateTime.Parse("2017-05-05")}
            };
            foreach (Newsletter n in Newsletters)
            {
                context.Newsletters.Add(n);
            }
            context.SaveChanges();

        }
    }

}
