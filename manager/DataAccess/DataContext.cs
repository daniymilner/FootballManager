﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Migrations;
using DataAccess.Migrations.easygenerator.DataAccess.Migrations;
using DomainModel.Entities;

namespace DataAccess
{
    public class DataContext : DbContext, IDataContext, IUnitOfWork
    {
        static DataContext()
        {
            try
            {
                var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
                Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataContext()
            : this("DefaultConnection")
        {
        }

        public DataContext(string connectionString)
            : base(connectionString)
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += (sender, args) => DateTimeObjectMaterializer.Materialize(args.Entity);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillsPlayer> SkillsPlayer { get; set; }

        public IDbSet<T> GetSet<T>() where T : Entity
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<Guid>().Where(p => p.Name == "Id").Configure(p => p.IsKey());

            modelBuilder.Entity<User>().Property(e => e.Email).IsRequired().HasMaxLength(254);
            modelBuilder.Entity<User>().Property(e => e.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.ParentId).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.Skype).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.Sex).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.City).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.Birthday).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.AboutMySelf).IsOptional();
            modelBuilder.Entity<User>().Property(e => e.Language).IsRequired().HasMaxLength(10);

            modelBuilder.Entity<Country>().Property(e => e.Name).IsRequired().HasMaxLength(254);
            modelBuilder.Entity<Country>().Property(e => e.PublicId).IsRequired().HasMaxLength(254);

            modelBuilder.Entity<Illness>().Property(e => e.IllnessName).IsRequired().HasMaxLength(254);
            modelBuilder.Entity<Illness>().Property(e => e.TimeForRecovery).IsRequired();

            modelBuilder.Entity<Position>().Property(e => e.Name).IsRequired().HasMaxLength(254);
            modelBuilder.Entity<Position>().Property(e => e.PublicId).IsRequired().HasMaxLength(254);

            modelBuilder.Entity<Player>().Property(e => e.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Player>().Property(e => e.Surname).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Player>().Property(e => e.Age).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Weight).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Growth).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Number).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Salary).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Money).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Humor).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.Condition).IsRequired();
            modelBuilder.Entity<Player>().HasRequired(e => e.User);
            modelBuilder.Entity<Player>().HasRequired(e => e.Position);
            modelBuilder.Entity<Player>().HasRequired(e => e.Illness);
            modelBuilder.Entity<Player>().HasRequired(e => e.Country);
            modelBuilder.Entity<Player>().Property(e => e.PublicId).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.CreateDate).IsRequired();

            modelBuilder.Entity<Team>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Team>().Property(e => e.ShortName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Team>().Property(e => e.Logo).IsRequired();
            modelBuilder.Entity<Team>().Property(e => e.CoachId);
            modelBuilder.Entity<Team>().Property(e => e.AssistantId);
            modelBuilder.Entity<Team>().HasRequired(e => e.Country);
            modelBuilder.Entity<Team>().Property(e => e.Stadium).IsRequired();
            modelBuilder.Entity<Team>().Property(e => e.Year).IsRequired();

            modelBuilder.Entity<Skill>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Skill>().Property(e => e.Ordering).IsRequired();

            modelBuilder.Entity<SkillsPlayer>().HasRequired(e => e.Skill);
            modelBuilder.Entity<SkillsPlayer>().HasRequired(e => e.Player);
            modelBuilder.Entity<SkillsPlayer>().Property(e => e.Value).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                foreach (var validationErrors in exception.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}
