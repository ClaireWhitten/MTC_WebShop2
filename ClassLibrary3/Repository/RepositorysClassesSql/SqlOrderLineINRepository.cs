using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlOrderLineINRepository : TDSrepositoryAsync<OrderLineIN>, IOrderLineINRepository
    {
        //==================================================================================

        public SqlOrderLineINRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
