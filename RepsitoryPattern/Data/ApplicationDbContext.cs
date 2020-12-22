using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepsitoryPattern.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   
        }
        public DbSet<Projects> Projects
        { get; set; }
        public DbSet<Supervisor> Supervisor{ get; set; }
        public DbSet<Employee> Employee{ get; set; }

    }
}
