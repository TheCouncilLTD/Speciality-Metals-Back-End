﻿using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingProduct
{
    public class ReportProduct_Context : DbContext
    {
        public ReportProduct_Context(DbContextOptions<ReportProduct_Context> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Outgoing> Outgoing { get; set; }
        public DbSet<Sundry_Notes> Sundry_Note { get; set; }  // Add this line
    }
}

