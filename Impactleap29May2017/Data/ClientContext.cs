using Impactleap29May2017.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impactleap29May2017.Data
{
         
    public class ClientContext : DbContext
    {
        // Coordinates Entity Framework functionality for a given data model

        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {
        }

        public DbSet<FreeReport> FreeReports { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }

    }
}
