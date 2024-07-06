using Domain.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RelationalDB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }


        public ApplicationDbContext(CustomDbContextOptions customDbContextOptions) : base(customDbContextOptions.DbContextOptions)
        {
        }

        public static DbContextOptions<ApplicationDbContext> BuildDbContextOptions(RelationalDbConfiguration configuration)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptionsBuilder.UseSqlServer(configuration.ConnectionString);
            // dbContextOptionsBuilder.UseInMemoryDatabase("example-task-db");

            return dbContextOptionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


    ///////////////////////////////////////////////////////////////////////////

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var changedEntities = ChangeTracker.Entries()
                                            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in changedEntities)
        {
            var baseEntity = (BaseEntity)entity.Entity;
            if (entity.State == EntityState.Added)
            {
                baseEntity.CreatedAt = DateTime.Now;
            }
            else if (entity.State == EntityState.Modified)
            {

                var rowNumberProperty = entity.Properties.FirstOrDefault(p => p.Metadata.Name == "RowNumber");
                if (rowNumberProperty != null)
                {
                    rowNumberProperty.IsModified = false;
                }
                // Entry(entity).Property(x => (BaseEntity)x.Entity).IsModified = false;
                baseEntity.UpdatedAt = DateTime.Now;
                if (baseEntity.IsDeleted && !baseEntity.DeletedAt.HasValue)
                    baseEntity.DeletedAt = DateTime.Now;
                else if (!baseEntity.IsDeleted && baseEntity.DeletedAt.HasValue)
                    baseEntity.DeletedAt = null;
            }
        }
    }

    }
}