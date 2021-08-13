using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{

    public class SqlProductImageRepository : TDSrepositoryAsync<ProductImage>, IProductImageRepository
    {
        //==================================================================================

        public SqlProductImageRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
