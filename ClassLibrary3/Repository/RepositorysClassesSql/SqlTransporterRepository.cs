using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlTransporterRepository : TDSrepositoryAsync<Transporter>, ITransporterRepository
    {
        //==================================================================================

        public SqlTransporterRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
