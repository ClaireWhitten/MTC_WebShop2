using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlZoneRepository : TDSrepositoryAsync<Zone>, IZoneRepository
    {
        //==================================================================================

        public SqlZoneRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
