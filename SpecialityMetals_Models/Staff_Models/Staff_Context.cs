﻿using Microsoft.EntityFrameworkCore;

namespace Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models
{
    public class Staff_Context : DbContext
    {
        public Staff_Context(DbContextOptions<Staff_Context> options) : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
    }


}
