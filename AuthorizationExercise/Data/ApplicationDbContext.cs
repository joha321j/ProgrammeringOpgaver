using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthorizationExercise.Models;

namespace AuthorizationExercise.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AuthorizationExercise.Models.Nisse> Nisse { get; set; }
        public DbSet<AuthorizationExercise.Models.HotGayDad> HotGayDads { get; set; }
    }
}
