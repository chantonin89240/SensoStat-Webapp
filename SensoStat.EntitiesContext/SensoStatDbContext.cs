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

                entity.HasKey(e => e.Id);

                entity.HasOne(i => i.Session)
                    .WithMany(s => s.Instructions)
                    .HasForeignKey(i => i.IdSession);
            });

            modelBuilder.Entity<Panelist>(entity =>
            {
                entity.ToTable("Panelist");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasKey(e => e.Id);

                entity.HasOne(p => p.Role)
                    .WithMany(r => r.Persons)
                    .HasForeignKey(p => p.IdRole);
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.ToTable("Presentation");

                entity.HasKey(e => new { e.IdPanelist, e.IdProduct });

                entity.HasOne(p => p.Product)
                    .WithMany(p => p.Presentations)
                    .HasForeignKey(p => p.IdProduct);

                entity.HasOne(p => p.Panelist)
                    .WithMany(p => p.Presentations)
                    .HasForeignKey(p => p.IdPanelist);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasKey(e => e.Id);

                entity.HasOne(p => p.Session)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.IdSession);
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication");

                entity.HasKey(e => new { e.IdSession, e.IdPaneslist });

                entity.HasOne(p => p.Session)
                    .WithMany(s => s.Publications)
                    .HasForeignKey(p => p.IdSession);

                entity.HasOne(p => p.Panelist)
                   .WithMany(s => s.Publications)
                   .HasForeignKey(p => p.IdPaneslist);
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.ToTable("Response");

                entity.HasKey(e => new { e.IdProduct, e.IdInstruction, e.IdPanelist });

                entity.HasOne(r => r.Instruction)
                    .WithMany(i => i.Responses)
                    .HasForeignKey(r => r.IdInstruction);

                entity.HasOne(r => r.Product)
                   .WithMany(p => p.Responses)
                   .HasForeignKey(r => r.IdProduct)
                   .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(r => r.Panelist)
                   .WithMany(p => p.Responses)
                   .HasForeignKey(r => r.IdPanelist);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.HasKey(e => e.Id);

                entity.HasOne(s => s.Person)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(s => s.IdPerson);
            });
        }
    }
}