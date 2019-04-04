using PetProject.Data.Infrastructure;
using PetProject.Model.Model;

namespace PetProject.Data.Repositories
{

    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
