using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public interface IChatMessageRepository : ITDSrepositoryAsync<ChatMessage>
    {
        Task<List<ShortClientDataForChat_DTO>> GetAllShortClientDataAsync();
        Task SetClientMessagesAsReaded(string aClientId);
        Task SetAdmindMessagesAsReaded(string aClientId);
    }
}


