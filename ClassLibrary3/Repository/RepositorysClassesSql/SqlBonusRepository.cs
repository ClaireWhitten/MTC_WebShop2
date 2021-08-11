using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlBonusRepository : TDSrepositoryAsync<Bonus>, IBonusRepository
    {
        //==================================================================================

        public SqlBonusRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
