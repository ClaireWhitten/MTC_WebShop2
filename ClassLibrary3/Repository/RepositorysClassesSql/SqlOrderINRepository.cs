using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlOrderINRepository : TDSrepositoryAsync<OrderIN>, IOrderINRepository
    {
        //==================================================================================

        public SqlOrderINRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }

        public async Task<TSDreposResultIenumerable<OrderIN>> GetOrderInsWithOrderLines(int id)
        {
            var terug = new TSDreposResultIenumerable<OrderIN>();

            terug.Data = await _context.Set<OrderIN>().Where(o=>o.ID == id)
                .Include(o => o.OrderLinesINs)
                .ThenInclude(ol=>ol.Product)
                .ToListAsync();

            return terug;
        }

       


    }
}
