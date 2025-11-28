using MetroClaim.Api.Data;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;

namespace MetroClaim.Api.Repositrories.Data;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(MetroClaimDbContext context) : base(context)
    {
    }
}
