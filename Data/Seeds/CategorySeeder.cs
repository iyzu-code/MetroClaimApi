using MetroClaim.Api.Models;

namespace MetroClaim.Api.Data.Seeds;

public static class CategorySeeder
{
    // GUID fixed per kategori
    public static readonly Guid TransportationId = Guid.Parse("C0000000-0000-0000-0000-000000000001");
    public static readonly Guid MealId = Guid.Parse("C0000000-0000-0000-0000-000000000002");
    public static readonly Guid AccommodationId = Guid.Parse("C0000000-0000-0000-0000-000000000003");
    public static readonly Guid MedicalId = Guid.Parse("C0000000-0000-0000-0000-000000000004");
    public static readonly Guid OfficeSuppliesId = Guid.Parse("C0000000-0000-0000-0000-000000000005");
    public static readonly Guid TrainingId = Guid.Parse("C0000000-0000-0000-0000-000000000006");
    public static readonly Guid OtherId = Guid.Parse("C0000000-0000-0000-0000-000000000007");

    public static List<Category> GetDefaultCategories()
    {
        return new List<Category>
        {
            new Category
            {
                Id = TransportationId,
                Name = "Transportation",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = MealId,
                Name = "Meal",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = AccommodationId,
                Name = "Accommodation",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = MedicalId,
                Name = "Medical",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = OfficeSuppliesId,
                Name = "Office Supplies",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = TrainingId,
                Name = "Training & Development",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = OtherId,
                Name = "Other",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }
}
