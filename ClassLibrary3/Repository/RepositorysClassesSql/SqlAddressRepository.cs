using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlAddressRepository : TDSrepositoryAsync<Address>, IAddressRepository
    {
        //==================================================================================

        public SqlAddressRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
