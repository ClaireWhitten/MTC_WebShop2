using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlClientRepository : TDSrepositoryAsync<Client>, IClientRepository
    {
        //==================================================================================

        public SqlClientRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
