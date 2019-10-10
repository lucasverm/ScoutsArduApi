﻿using Microsoft.EntityFrameworkCore;
using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Gebruiker> Gebruikers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*builder.ApplyConfiguration(new AtelierConfiguration());
            builder.ApplyConfiguration(new CommentaarConfiguration());
            builder.ApplyConfiguration(new DagAtelierConfiguration());
            builder.ApplyConfiguration(new DagPlanningConfiguration());
            builder.ApplyConfiguration(new DagPlanningTemplateConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new OpmerkingConfiguration());
            builder.ApplyConfiguration(new GebruikerAtelierConfiguration());*/
        }
    }
}
