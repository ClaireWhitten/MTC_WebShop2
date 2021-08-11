using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlSupplierRepository : TDSrepositoryAsync<Supplier>, ISupplierRepository
    {
        //==================================================================================

        public SqlSupplierRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
