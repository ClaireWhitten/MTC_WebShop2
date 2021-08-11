using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlOrderLineOUTRepository : TDSrepositoryAsync<OrderLineOUT>, IOrderLineOUTRepository
    {
        //==================================================================================

        public SqlOrderLineOUTRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
