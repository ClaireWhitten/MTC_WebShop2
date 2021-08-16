using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlTransporterRepository : TDSrepositoryAsync<Transporter>, ITransporterRepository
    {
        //==================================================================================

        public SqlTransporterRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }

        public override Task<TSDreposResultOneObject<Transporter>> AddAsync(Transporter aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Transporter>> AddRangeAsync(IEnumerable<Transporter> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddRangeAsync(aEntities, autoSaveChange);
        }
        //public override Task<TSDreposResultIenumerable<Transporter>> GetAllAsync()
        //{
        //    throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
        //    return base.GetAllAsync();
        //}
        //public override Task<TSDreposResultIenumerable<Transporter>> GetByConditionAsync(Expression<Func<Transporter, bool>> predicate)
        //{
        //    throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
        //    return base.GetByConditionAsync(predicate);
        //}
        //public override Task<TSDreposResultOneObject<Transporter>> GetByIdAsync(params object[] aPrimaryKey)
        //{
        //    throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
        //    return base.GetByIdAsync(aPrimaryKey);
        //}
        //public override Task<TSDreposResultOneObject<Transporter>> GetSingleOrDefaultAsync(Expression<Func<Transporter, bool>> aPredicate)
        //{
        //    throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
        //    return base.GetSingleOrDefaultAsync(aPredicate);
        //}
        public override Task<TSDreposResultOneObject<Transporter>> RemoveAsync(Transporter aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Transporter>> RemoveAsyncByKey(params object[] aPrimaryKey)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsyncByKey(aPrimaryKey);
        }
        public override Task<TSDreposResultIenumerable<Transporter>> RemoveByCondition(Expression<Func<Transporter, bool>> aPredicate, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveByCondition(aPredicate, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Transporter>> RemoveRangeAsync(IEnumerable<Transporter> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveRangeAsync(aEntities, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Transporter>> UpdateAsync(Transporter aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.UpdateAsync(aEntity, autoSaveChange);
        }
    }
}
