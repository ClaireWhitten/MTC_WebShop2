using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlProductCategorieRepository : TDSrepositoryAsync<ProductCategorie>, IProductCategorieRepository
    {
        //==================================================================================

        public SqlProductCategorieRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
