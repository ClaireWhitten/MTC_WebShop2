using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //public override Task<TSDreposResultOneObject<OrderOUT>> AddAsync(OrderOUT aEntity, bool autoSaveChange = true)
        //{
        //    //code schrijven voor count in stock voor product eerst aanpassen

        //    return base.AddAsync(aEntity, autoSaveChange);
        //}

        public async Task<TSDreposResultOneObject<OrderOUT>> GetById_withOrderlineOut_Async(int aId)
        {
            var terug = new TSDreposResultOneObject<OrderOUT>();

            terug.Data = await _context.Set<OrderOUT>().Include(x=>x.OrderLineOUTs).FirstOrDefaultAsync(x=>x.Id == aId);

            return terug;
        }


        public async Task<OrderOutOverview_DTO> getOrderOutDTO(StatusOfOrder aOrderStateToGet, bool captureAvailableTransportersForListbox= false)
        {
            OrderOutOverview_DTO terug = new OrderOutOverview_DTO();
            

            terug.OrderOutOverviewItems = await _context.Set<OrderOUT>()
                .Where(oo => oo.Status == aOrderStateToGet)
                //.Include(cl => cl.Client)
                //.Include(lines=> lines.OrderLineOUTs) //just for capture the count
                .Select(x => new OrderOutOverview_DTO.OrderOutOverviewItem
                {
                    OrderOutId = x.Id,
                    OrderOutDate = x.Date,
                    //LineCount = x.OrderLineOUTs.Count,
                    FullNameOfClient = x.Client.FirstName + " " + x.Client.NameAdditional + " " + x.Client.LastName,
                    EmailClient = x.Client.ApplicationUser.Email,
                    
                    //we set the transporterid for this model on the first founded transprortid from the oredlineout item,
                    //we work on this moment on 1 transporter for the orderline... it's too much work for multiple transporters on this moment
                    //we have not time enough for implementate this.
                    TransporterId = x.OrderLineOUTs.First().TransporterId,
                    TransporterName = x.OrderLineOUTs.First().Transporter.Name
                }
                ).ToListAsync();

            terug.AvaillableTransproters = new List<SelectListItem>();
            if(captureAvailableTransportersForListbox)
            {
                terug.AvaillableTransproters = await _context.Set<Transporter>()
                    .Select(x => new SelectListItem
                    {
                        Text= x.Name,
                        Value= x.Id
                    }).ToListAsync();
            }
    
            return terug;
        }
    }
}
