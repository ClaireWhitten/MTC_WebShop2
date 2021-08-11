using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlReturnedProductsRepository : TDSrepositoryAsync<ReturnedProduct>, IReturnedProductsRepository
    {
        //==================================================================================

        public SqlReturnedProductsRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
