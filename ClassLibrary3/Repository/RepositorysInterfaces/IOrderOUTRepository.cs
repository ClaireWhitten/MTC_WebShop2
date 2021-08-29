using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public interface IOrderOUTRepository : ITDSrepositoryAsync<OrderOUT>
    {
        public Task<OrderOutOverview_DTO> getOrderOutDTO(StatusOfOrder aOrderStateToGet, bool captureAvailableTransportersForListbox = false);

        public Task<TSDreposResultOneObject<OrderOUT>> GetById_withOrderlineOut_Async(int aId);
        Task<TSDreposResultOneObject<OrderOUT>> GetById_withAll_Async(int aId);
        Task<TSDreposResultOneObject<OrderOUT>> GetById_withOrderlineOutAndClient_Async(int aId);
    }
}
