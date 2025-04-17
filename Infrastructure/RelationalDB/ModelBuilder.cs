namespace Infrastructure.RelationalDB;

public static class CustomModelBuilder
{
    public static void Build(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        // Relations

        // Seeders
        DefaultDataSeeder.Seed(modelBuilder);
    }
}