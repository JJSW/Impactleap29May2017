using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Impactleap29May2017.Data;

namespace Impactleap29May2017.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20170529194458_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Impactleap29May2017.Models.FreeReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("SignUpDate");

                    b.HasKey("ID");

                    b.ToTable("FreeReports");
                });

            modelBuilder.Entity("Impactleap29May2017.Models.Newsletter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("SignUpDate");

                    b.HasKey("ID");

                    b.ToTable("Newsletters");
                });
        }
    }
}
