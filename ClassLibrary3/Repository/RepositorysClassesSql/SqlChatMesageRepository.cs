using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;


namespace MTCrepository.Repository
{
    public class SqlChatMesageRepository : TDSrepositoryAsync<ChatMessage>, IChatMessageRepository
    {
        //==================================================================================

        public SqlChatMesageRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }

        public async Task<List<ShortClientDataForChat_DTO>> GetAllShortClientDataAsync()
        {
            var result = await _context.Clients.Select(x =>
            new ShortClientDataForChat_DTO
            {
                ClientId = x.Id,
                UnreadedMessages = x.ChatMessages.Count(cm => cm.IsReaded == false && cm.IsFromAdmin==false),
                FirstName = x.FirstName,
                IsOnline = false,
                Email = x.ApplicationUser.Email
            }).ToListAsync();

            return result;
        }

        public async Task SetClientMessagesAsReaded(string aClientId)
        {
            await _context.ChatMessages.Where(cm => cm.IsFromAdmin == false && cm.CliendId == aClientId)
                .UpdateAsync(x => new ChatMessage() { IsReaded = true });
        }

        public async Task SetAdmindMessagesAsReaded(string aClientId)
        {
            await _context.ChatMessages.Where(cm => cm.IsFromAdmin == true && cm.CliendId == aClientId)
                 .UpdateAsync(x => new ChatMessage() { IsReaded = true });
        }


    }
}

