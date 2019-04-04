using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShoppingPetProjectDBContext dbContext;

        public ShoppingPetProjectDBContext Init()
        {
            return dbContext ?? (dbContext = new ShoppingPetProjectDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
