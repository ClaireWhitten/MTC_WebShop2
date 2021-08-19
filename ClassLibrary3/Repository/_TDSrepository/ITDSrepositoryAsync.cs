using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public interface ITDSrepositoryAsync<TDSentity> where TDSentity : class
    {
        //lezen
        //----------------------------------------------------------
        Task<TSDreposResultOneObject<TDSentity>> GetByIdAsync(params object[] aPrimaryKey);
        Task<TSDreposResultIenumerable<TDSentity>> GetAllAsync();
        Task<TSDreposResultIenumerable<TDSentity>> GetByConditionAsync(Expression<Func<TDSentity, bool>> aPredicate);
        Task<TSDreposResultOneObject<TDSentity>> GetSingleOrDefaultAsync(Expression<Func<TDSentity, bool>> aPredicate);


        //toevoegen
        //----------------------------------------------------------
        Task<TSDreposResultOneObject<TDSentity>> AddAsync(TDSentity aEntity, bool autoSaveChange = true);
        Task<TSDreposResultIenumerable<TDSentity>> AddRangeAsync(IEnumerable<TDSentity> aEntities, bool autoSaveChange = true);


        //verwijderen
        //----------------------------------------------------------
        Task<TSDreposResultOneObject<TDSentity>> RemoveAsync(TDSentity aEntity, bool autoSaveChange = true);

        Task<TSDreposResultIenumerable<TDSentity>> RemoveByCondition(Expression<Func<TDSentity, bool>> aPredicate, bool autoSaveChange = true);

        Task<TSDreposResultIenumerable<TDSentity>> RemoveRangeAsync(IEnumerable<TDSentity> aEntities, bool autoSaveChange = true);


        //updaten
        //----------------------------------------------------------
        Task<TSDreposResultOneObject<TDSentity>> UpdateAsync(TDSentity aEntity, bool autoSaveChange = true);




    }
}



