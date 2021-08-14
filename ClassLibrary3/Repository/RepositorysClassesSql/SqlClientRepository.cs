using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlClientRepository : TDSrepositoryAsync<Client>, IClientRepository
    {
        //==================================================================================

        public SqlClientRepository(AppDbContext aAppContext) : base(aAppContext)
        {
            
        }
        
        public override Task<TSDreposResultOneObject<Client>> AddAsync(Client aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Client>> AddRangeAsync(IEnumerable<Client> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.AddRangeAsync(aEntities, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Client>> GetAllAsync()
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetAllAsync();
        }
        public override Task<TSDreposResultIenumerable<Client>> GetByConditionAsync(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetByConditionAsync(predicate);
        }
        public override Task<TSDreposResultOneObject<Client>> GetByIdAsync(params object[] aPrimaryKey)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetByIdAsync(aPrimaryKey);
        }
        public override Task<TSDreposResultOneObject<Client>> GetSingleOrDefaultAsync(Expression<Func<Client, bool>> aPredicate)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.GetSingleOrDefaultAsync(aPredicate);
        }
        public override Task<TSDreposResultOneObject<Client>> RemoveAsync(Client aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsync(aEntity, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Client>> RemoveAsyncByKey(params object[] aPrimaryKey)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveAsyncByKey(aPrimaryKey);
        }
        public override Task<TSDreposResultIenumerable<Client>> RemoveByCondition(Expression<Func<Client, bool>> aPredicate, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveByCondition(aPredicate, autoSaveChange);
        }
        public override Task<TSDreposResultIenumerable<Client>> RemoveRangeAsync(IEnumerable<Client> aEntities, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.RemoveRangeAsync(aEntities, autoSaveChange);
        }
        public override Task<TSDreposResultOneObject<Client>> UpdateAsync(Client aEntity, bool autoSaveChange = true)
        {
            throw new NotImplementedException("Sorry, at this moment you can not use this method, Tom work on it");
            return base.UpdateAsync(aEntity, autoSaveChange);
        }
    }
}
