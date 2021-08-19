using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MTCrepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public abstract class TDSrepositoryAsync  <TDSentity> : ITDSrepositoryAsync<TDSentity>
        where TDSentity : class
    {
        //======================================================================================================

        protected readonly AppDbContext _context;

        //protected List<TDSentity> _memoryList = null;

        //------------------------------------------------------------------------------------------------------
        public TDSrepositoryAsync(AppDbContext aContext)
        {
            _context = aContext;
            Console.WriteLine($"ik ben de constructor van {this.GetType().Name} ");
        }


        #region======================================================================================================Getters



        //======================================================================================================
        // getest:
        // - geen idee hoe  hier fouten te simuleren, voor de rest ok
        //======================================================================================================
        public virtual async Task<TSDreposResultIenumerable<TDSentity>> GetByConditionAsync(Expression<Func<TDSentity, bool>> predicate)
        {
            var terug = new TSDreposResultIenumerable<TDSentity>();

            try
            {
                terug.Data = await _context.Set<TDSentity>().Where(predicate).ToListAsync(); ;
                terug.SaveChangeCount = 0;
                terug.Succeeded = true;
            }
            catch(DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }

            return terug;
        }
        //======================================================================================================
        // getest:
        // - verkeerd argumenttype,     nvt ,   TDSreposErrCode.WRONG_ARGUMENTTYPE
        // - TODO: nog testen met multiple keys
        //======================================================================================================
        public virtual async Task<TSDreposResultOneObject<TDSentity>> GetByIdAsync(params object[] aPrimaryKey)
        {
            var terug = new TSDreposResultOneObject<TDSentity>();

            try
            {
                terug.Data = await _context.Set<TDSentity>().FindAsync(aPrimaryKey);
                terug.SaveChangeCount = 0;
                terug.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            catch (ArgumentException)
            {
                terug.ErrorCode = TDSreposErrCode.WRONG_ARGUMENTTYPE;
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = null;
            }
            return terug;
        }

        //======================================================================================================
        // getest:
        // - geen idee hoe hier fouten te simuleren, voor de rest ok
        //======================================================================================================
        public virtual async Task<TSDreposResultIenumerable<TDSentity>> GetAllAsync()
        {
            var terug = new TSDreposResultIenumerable<TDSentity>();

            try
            {
                terug.Data = await _context.Set<TDSentity>().ToListAsync();
                terug.SaveChangeCount = 0;
                terug.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            return terug;
        }

        //======================================================================================================
        // getest:
        // - geen idee hoe hier fouten te simuleren, voor de rest ok
        //======================================================================================================
        public virtual async Task<TSDreposResultOneObject<TDSentity>> GetSingleOrDefaultAsync(Expression<Func<TDSentity, bool>> aPredicate)
        {
            var terug = new TSDreposResultOneObject<TDSentity>();

            try
            {
                terug.Data = await _context.Set<TDSentity>().SingleOrDefaultAsync(aPredicate);
                terug.SaveChangeCount = 0;
                terug.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            return terug;
        }
        #endregion




        #region==================================================================================================== Bewerken



        //======================================================================================================
        // getest:
        // - verwijzende sleutel fout,     547 ,   FOREIGNKEY_CONFLICT
        // - unieke sleutel bestaat reeds, 2601 ,  TDSreposErrCode.DUPLICATE_KEY
        // - niet bestaat,                 nvt,    NOTFOUND
        //======================================================================================================

        /// <summary>
        /// by FOREIGNKEY_CONFLICT, Succeeded is false , ErrorCode = TDSreposErrCode.FOREIGNKEY_CONFLICT 
        /// by sdfdsfdsf
        /// </summary>
        public virtual async Task<TSDreposResultOneObject<TDSentity>> UpdateAsync(TDSentity aEntity, bool autoSaveChange = true)
        {

            var terug = new TSDreposResultOneObject<TDSentity>();

            try
            {
                bool bestaat = _context.Set<TDSentity>().Any(e => e == aEntity);
                if( !bestaat)
                {
                    terug.ErrorCode = TDSreposErrCode.NOTFOUND;
                    terug.SaveChangeCount = 0;
                    terug.Data = null;
                    terug.Succeeded = false;
             
                    return terug;
                }

                var founded = _context.Set<TDSentity>().Attach(aEntity);
                founded.State = EntityState.Modified;
                terug.Data = aEntity;
                terug.SaveChangeCount = await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            //catch(InvalidOperationException ex)
            //{
            //    Console.WriteLine(ex.GetType());
            //}
            return terug;
        }
        #endregion




        #region=================================================================================================== Toevoegen



        //======================================================================================================
        // getest:
        // - verwijzende sleutel fout,     547 ,   FOREIGNKEY_CONFLICT
        // - unieke sleutel bestaat reeds, 2601 ,  TDSreposErrCode.DUPLICATE_KEY
        //======================================================================================================

        public virtual async Task<TSDreposResultOneObject<TDSentity>> AddAsync(TDSentity aEntity, bool autoSaveChange = true)
        {
            var terug = new TSDreposResultOneObject<TDSentity>();

            try
            {
                await _context.Set<TDSentity>().AddAsync(aEntity);
                
                terug.SaveChangeCount = await _context.SaveChangesAsync();

                if (terug.SaveChangeCount == 0)
                    terug.Data = null;
                else
                    terug.Data = aEntity;
            }
            catch(DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            return terug;
        }


        //======================================================================================================
        // TODO: getest:
        // - NOG NIET GETEST !!!!!
        //======================================================================================================

        public virtual async Task<TSDreposResultIenumerable<TDSentity>> AddRangeAsync(IEnumerable<TDSentity> aEntities, bool autoSaveChange = true)
        {
            //=====================================================================================================
            throw new NotImplementedException($"deze nog uit commentaar halen, deze methode moet nog getest worden");
            //=====================================================================================================

            var terug = new TSDreposResultIenumerable<TDSentity>();

            try
            {
                await _context.Set<TDSentity>().AddRangeAsync(aEntities);

                terug.SaveChangeCount = await _context.SaveChangesAsync();
                terug.Data = aEntities;
            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            return terug;
        }
        #endregion




        #region================================================================================================= Verwijderen



        //======================================================================================================
        // getest:
        // - verwijzende sleutel fout,     547 ,   FOREIGNKEY_CONFLICT
        // - unieke sleutel bestaat reeds, 2601 ,  TDSreposErrCode.DUPLICATE_KEY
        //======================================================================================================
        public virtual async Task<TSDreposResultOneObject<TDSentity>> RemoveAsync(TDSentity aEntity, bool autoSaveChange = true)
        {
            var terug = new TSDreposResultOneObject<TDSentity>();
            
            try
            {


                _context.Entry(aEntity).State = EntityState.Deleted;

                terug.SaveChangeCount = await _context.SaveChangesAsync();

                if (terug.SaveChangeCount == 0)
                {
                    terug.Data = null;
                    terug.Succeeded = false;
                }
                else
                    terug.Data = aEntity;
            }
            catch (DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            return terug;
        }

        public virtual async Task<TSDreposResultOneObject<TDSentity>> RemoveAsyncByKey(params object[] aPrimaryKey )
        {
            var terug = new TSDreposResultOneObject<TDSentity>();
            terug.Data = await _context.Set<TDSentity>().FindAsync(aPrimaryKey);



            return terug;
        }

        //======================================================================================================
        // TODO: getest:
        // - NOG NIET GETEST !!!!!
        //======================================================================================================
        public virtual async Task<TSDreposResultIenumerable<TDSentity>> RemoveRangeAsync(IEnumerable<TDSentity> aEntities, bool autoSaveChange=true)
        {
            //=====================================================================================================
            //throw new NotImplementedException($"deze nog uit commentaar halen, deze methode moet nog getest worden");
            //=====================================================================================================
            var terug = new TSDreposResultIenumerable<TDSentity>();
            try {
                terug.Data = aEntities;
                _context.Set<TDSentity>().RemoveRange(aEntities);
                terug.SaveChangeCount = await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.SaveChangeCount = 0;
                terug.Data = null;
                terug.Succeeded = false;
                terug.DbUpdateException = ex;
            }
            return terug;
        }




        //======================================================================================================
        // TODO: getest:
        // - NOG NIET GETEST !!!!!
        //======================================================================================================
        /// <summary>
        /// nog niet getest
        /// </summary>
        /// <param name="aPredicate"></param>
        /// <param name="autoSaveChange"></param>
        /// <returns></returns>
        public virtual async Task<TSDreposResultIenumerable<TDSentity>> RemoveByCondition(Expression<Func<TDSentity, bool>> aPredicate, bool autoSaveChange = true)
        {
            //=====================================================================================================
            throw new NotImplementedException($"deze nog uit commentaar halen, deze methode moet nog getest worden");
            //=====================================================================================================

            var terug = new TSDreposResultIenumerable<TDSentity>();

            try
            {
                terug.Data = await _context.Set<TDSentity>().Where(aPredicate).ToListAsync();
                _context.Set<TDSentity>().RemoveRange(terug.Data);
                terug.SaveChangeCount = await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                terug.setErrorCode(ex);
                terug.Data = null;
                terug.Succeeded = false;
                terug.SaveChangeCount = 0;
                terug.DbUpdateException = ex;
            }
            return terug;
        }
        #endregion
    }
}


