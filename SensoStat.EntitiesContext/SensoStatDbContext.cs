namespace SensoStat.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using SensoStat.Entities;

    public class SensoStatDbContext : DbContext
    {
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Panelist> Panelists { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public SensoStatDbContext(DbContextOptions<SensoStatDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instruction>(entity =>
            {
                entity.ToTable("Instruction");

                entity.HasOne(i => i.Session)
                    .WithMany(s => s.Instructions)
                    .HasConstraintName("fk_Instruction_Session");
            });

            modelBuilder.Entity<Panelist>(entity =>
            {
                entity.ToTable("Panelist");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasOne(p => p.Role)
                    .WithMany(r => r.Persons)
                    .HasConstraintName("fk_Person_Role");
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.ToTable("Presentation");

                entity.HasOne(p => p.Product)
                    .WithMany(p => p.Presentations)
                    .HasConstraintName("fk_Presentation_Product");

                entity.HasOne(p => p.Panelist)
                    .WithMany(p => p.Presentations)
                    .HasConstraintName("fk_Presentation_Panelist");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasOne(p => p.Session)
                    .WithMany(s => s.Products)
                    .HasConstraintName("fk_Product_Session");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication");

                entity.HasOne(p => p.Session)
                    .WithMany(s => s.Publications)
                    .HasConstraintName("fk_Publication_Session");

                entity.HasOne(p => p.Panelist)
                   .WithMany(s => s.Publications)
                   .HasConstraintName("fk_Publication_Panelist");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.ToTable("Response");

                entity.HasOne(r => r.Instruction)
                    .WithMany(i => i.Responses)
                    .HasConstraintName("fk_Response_Instruction");

                entity.HasOne(r => r.Product)
                   .WithMany(p => p.Responses)
                   .HasConstraintName("fk_Response_Product");

                entity.HasOne(r => r.Panelist)
                   .WithMany(p => p.Responses)
                   .HasConstraintName("fk_Response_Panelist");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.HasOne(s => s.Person)
                    .WithMany(p => p.Sessions)
                    .HasConstraintName("fk_Session_Person");
            });
        }
    }
}