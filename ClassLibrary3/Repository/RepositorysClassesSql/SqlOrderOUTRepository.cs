using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlOrderOUTRepository : TDSrepositoryAsync<OrderOUT>, IOrderOUTRepository
    {
        //==================================================================================

        public SqlOrderOUTRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
