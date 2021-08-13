using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlOrderOUTRepository : TDSrepositoryAsync<OrderOUT>, IOrderOUTRepository
    {
        //==================================================================================

        public SqlOrderOUTRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }

        public override Task<TSDreposResultOneObject<OrderOUT>> AddAsync(OrderOUT aEntity, bool autoSaveChange = true)
        {
            //code schrijven voor count in stock voor product eerst aanpassen

            return base.AddAsync(aEntity, autoSaveChange);
        }
    }
}
