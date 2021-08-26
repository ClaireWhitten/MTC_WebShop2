using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlChatMesageRepository : TDSrepositoryAsync<ChatMessage>, IChatMessageRepository
    {
        //==================================================================================

        public SqlChatMesageRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}