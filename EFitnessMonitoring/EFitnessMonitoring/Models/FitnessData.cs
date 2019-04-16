namespace EFitnessMonitoring.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using EFitnessMonitoring.Models.Identity;

    public partial class FitnessDbContext : IdentityDbContext<ApplicationUser, RoleIntPk, int,
    UserLoginIntPk, UserRoleIntPk, UserClaimIntPk>
    {
        public FitnessDbContext()
            : base("name=FitnessData")
        {
        }

        public static FitnessDbContext Create()
        {
            return new FitnessDbContext();
        }

        public virtual DbSet<DomeniuAntrenamente> DomeniuAntrenamentes { get; set; }
        public virtual DbSet<DomeniuSanatate> DomeniuSanatates { get; set; }
        public virtual DbSet<DomeniuSport> DomeniuSports { get; set; }
        public virtual DbSet<ExercitiiSpeciale> ExercitiiSpeciales { get; set; }
        public virtual DbSet<GraficAntrenament> GraficAntrenaments { get; set; }
        public virtual DbSet<Medicina> Medicinas { get; set; }
        public virtual DbSet<Nutritie> Nutrities { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }
        public virtual DbSet<SubiecteForum> SubiecteForums { get; set; }
        public virtual DbSet<Warkout> Warkouts { get; set; }
        public virtual DbSet<UserRoleIntPk> UserRoleIntPks { get; set; }

        //public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } // asita
        //public virtual DbSet<RoleIntPk> RoleIntPks { get; set; }  // aista

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleIntPk>().ToTable("RoleIntPks"); // This may be not needed, check it.

            modelBuilder.Entity<RoleIntPk>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DomeniuAntrenamente>()
                .HasMany(e => e.GraficAntrenaments)
                .WithRequired(e => e.DomeniuAntrenamente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomeniuSanatate>()
                .HasMany(e => e.Medicinas)
                .WithRequired(e => e.DomeniuSanatate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomeniuSanatate>()
                .HasMany(e => e.Nutrities)
                .WithRequired(e => e.DomeniuSanatate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomeniuSport>()
                .HasMany(e => e.Warkouts)
                .WithRequired(e => e.DomeniuSport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medicina>()
                .HasMany(e => e.ExercitiiSpeciales)
                .WithRequired(e => e.Medicina)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubiecteForum>()
                .Property(e => e.Comntariu)
                .IsUnicode(false);

            modelBuilder.Entity<SubiecteForum>()
                .HasMany(e => e.Users)
                .WithMany(e => e.SubiecteForums1)
                .Map(m => m.ToTable("Comentarii").MapLeftKey("Id_subiect").MapRightKey("Id_user"));

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.DomeniuAntrenamentes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.DomeniuSanatates)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.DomeniuSports)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.ExercitiiSpeciales)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.GraficAntrenaments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Medicinas)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Nutrities)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Produses)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.SubiecteForums)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Warkouts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
