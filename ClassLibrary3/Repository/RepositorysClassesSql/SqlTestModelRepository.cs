using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.Repository
{
    public class SqlTestModelRepository : TDSrepositoryAsync<TestModel>, IITestModelRepository
    {
        //==================================================================================

        public SqlTestModelRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
    }
}
