using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlOrderINRepository : TDSrepositoryAsync<OrderIN>, IOrderINRepository
    {
        //==================================================================================

        public SqlOrderINRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
