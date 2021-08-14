using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlSupplierRepository : TDSrepositoryAsync<Supplier>, ISupplierRepository
    {
        //==================================================================================

        public SqlSupplierRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }


        public override Task<TSDreposResultOneObject<Supplier>> AddAsync(Supplier aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Supplier>> AddRangeAsync(IEnumerable<Supplier> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddRangeAsync(aEntities, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetAllAsync();
        }
        public override Task<TSDreposResultIenumerable<Supplier>> GetByConditionAsync(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetByConditionAsync(predicate);
        }
        public override Task<TSDreposResultOneObject<Supplier>> GetByIdAsync(params object[] aPrimaryKey)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetByIdAsync(aPrimaryKey);
        }
        public override Task<TSDreposResultOneObject<Supplier>> GetSingleOrDefaultAsync(Expression<Func<Supplier, bool>> aPredicate)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetSingleOrDefaultAsync(aPredicate);
        }
        public override Task<TSDreposResultOneObject<Supplier>> RemoveAsync(Supplier aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Supplier>> RemoveAsyncByKey(params object[] aPrimaryKey)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsyncByKey(aPrimaryKey);
        }
        public override Task<TSDreposResultIenumerable<Supplier>> RemoveByCondition(Expression<Func<Supplier, bool>> aPredicate, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveByCondition(aPredicate, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Supplier>> RemoveRangeAsync(IEnumerable<Supplier> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveRangeAsync(aEntities, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Supplier>> UpdateAsync(Supplier aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.UpdateAsync(aEntity, autoSaveChange);
        }


    }
}
