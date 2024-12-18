﻿using hshmedstats.Application.Interfaces;
using hshmedstats.Domain;
using hshmedstats.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace hshmedstats.Persistence
{
    public sealed class HshDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>, IHshDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers() => Users;

        public HshDbContext()
        {
            
        }
        public HshDbContext(DbContextOptions<HshDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public int UserId { get; set; }
        public async Task SaveAsync()
        {
            if (ChangeTracker.HasChanges())
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is IHistoryEntity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entry.CurrentValues["CreatedAt"] = DateTime.UtcNow;
                            entry.CurrentValues["UpdatedAt"] = DateTime.UtcNow;
                            entry.CurrentValues["CreatedBy"] = UserId;
                            entry.CurrentValues["UpdatedBy"] = UserId;

                        }

                        if (entry.State == EntityState.Modified)
                        {
                            entry.Property("CreatedAt").IsModified = false;
                            entry.Property("CreatedBy").IsModified = false;
                            entry.CurrentValues["UpdatedAt"] = DateTime.UtcNow;
                            entry.CurrentValues["UpdatedBy"] = UserId;
                        }
                    }
                }
            }
            await SaveChangesAsync();
        }

        public void Save()
        {
            SaveChanges();
        }

        public IEnumerable<EntityEntry> GetChangedEntries()
        {
            return ChangeTracker.Entries();
        }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public IDbContextTransaction BeginTransaction() => Database.BeginTransaction();

       
    }
}
