using System.Collections.Generic;
using System.Linq;
using PetProject.Data.Infrastructure;
using PetProject.Model.Model;

namespace PetProject.Data.Repositories
{
    /// <summary>
    /// viết thêm các phương thức khác 
    /// </summary>
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    /// <summary>
    /// kế thừa các phương thức đã có sẵn tại RepositoryBase
    /// </summary>
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
