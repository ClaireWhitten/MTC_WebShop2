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

        public async Task<TSDreposResultOneObject<OrderOUT>> GetById_withOrderlineOutAndClient_Async(int aId)
        {
            var terug = new TSDreposResultOneObject<OrderOUT>();

            terug.Data = await _context.Set<OrderOUT>().Include(x => x.OrderLineOUTs).Include(x => x.OrderLineOUTs).ThenInclude(x=>x.Product).Include(x=>x.Client).FirstOrDefaultAsync(x => x.Id == aId);

            return terug;
        }

        public async Task<TSDreposResultOneObject<OrderOUT>> GetById_withAll_Async(int aId)
        {
            var terug = new TSDreposResultOneObject<OrderOUT>();

            terug.Data = await _context.Set<OrderOUT>().Include(x => x.Bonusses).Include(x => x.Client).Include(x=>x.OrderLineOUTs).ThenInclude(x=>x.Product).Include(x => x.OrderLineOUTs).ThenInclude(x => x.Transporter).FirstOrDefaultAsync(x => x.Id == aId);

            return terug;
        }

        public override async Task<TSDreposResultOneObject<OrderOUT>> AddAsync(OrderOUT aEntity, bool autoSaveChange = true)
        {
            //using _context;
            using var _transaction = _context.Database.BeginTransaction();
            var terug = new TSDreposResultOneObject<OrderOUT>();


            try
            {
                //alle countinstocks ophalen van alle id's in de orderlijst
                List<string> allProductIdsInOrderLineOuts = aEntity.OrderLineOUTs.Select(oo => oo.ProductEAN).ToList();



                //de countInstock verlagen in de database, we doen nog geen commit
                //================================================================

                //https://stackoverflow.com/questions/44194877/how-to-bulk-update-records-in-entity-framework
                var onlyEANAndCountInStock = await _context.Products.Where(p => allProductIdsInOrderLineOuts.Contains(p.EAN)).Select(p => new { p.EAN, p.CountInStock }).ToListAsync();

                foreach (var olout in onlyEANAndCountInStock)
                {
                    //nieuw tijdelijk product maken, enkel met ean en countinstock props
                    Product tmpproduct = new Product { EAN = olout.EAN, CountInStock = olout.CountInStock };
                    tmpproduct.CountInStock -= aEntity.OrderLineOUTs.FirstOrDefault(oo => oo.ProductEAN == olout.EAN).Quantity; 

                    _context.Set<Product>().Attach(tmpproduct);
                    _context.Entry(tmpproduct).Property(x => x.CountInStock).IsModified = true;
                }
                _context.SaveChanges(); //dit is nog geen commit





                // controleren voor understock, 
                // dit doen we na het verlagen van de stockwaardes, dit omdat ondertussen een 
                // andere client de stock al verlaagd kan hebben
                //==================================================================================
                //uit db de stockvalues halen
                var EAN_countInStock = await _context.Products.Where(p => allProductIdsInOrderLineOuts.Contains(p.EAN)).Select( p=> new { p.EAN, p.CountInStock }).ToListAsync();
                foreach (var item in EAN_countInStock)
                {
                    if ( item.CountInStock<0)
                    {
                        throw new Exception("understock");
                    }

                }





                //de orderlines toevoegen aan de database
                //=============================================
                var addResult = await _context.Set<OrderOUT>().AddAsync(aEntity);
                terug.SaveChangeCount = await _context.SaveChangesAsync();



                //committen als er geen exceptions zijn, anders gebeurd een automtische rollback
                //==================================================================================
                _transaction.Commit();


                if (terug.SaveChangeCount == 0)
                    terug.Data = null;
                else
                    terug.Data = aEntity;

            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            catch (Exception ex)
            {
                if (ex.Message == "understock")
                    terug.setErrorCode(TDSreposErrCode.STOCK_UNDERFLOW);
                else
                    terug.setErrorCode(TDSreposErrCode.UNKNOW_ERROR);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = null;
            }
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
        public async Task<OrderOutOverview_DTO> getOrderOutForTransporterDTO(string aTransporterId)
        {
            OrderOutOverview_DTO terug = new OrderOutOverview_DTO();




            terug.OrderOutOverviewItems = await _context.Set<OrderOUT>()
                .Where(oo => oo.Status == StatusOfOrder.Sent && ( oo.OrderLineOUTs.First().TransporterId == aTransporterId))
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

            return terug;
        }

    }
}
