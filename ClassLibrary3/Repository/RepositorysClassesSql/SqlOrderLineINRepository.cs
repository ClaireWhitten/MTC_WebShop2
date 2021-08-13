using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlOrderLineINRepository : TDSrepositoryAsync<OrderLineIN>, IOrderLineINRepository
    {
        //==================================================================================

        public SqlOrderLineINRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
        public override Task<TSDreposResultOneObject<OrderLineIN>> AddAsync(OrderLineIN aEntity, bool autoSaveChange = true)
        {
            //code schrijven voor count in stock voor product eerst aanpassen

            return base.AddAsync(aEntity, autoSaveChange);
        }
    }
}
