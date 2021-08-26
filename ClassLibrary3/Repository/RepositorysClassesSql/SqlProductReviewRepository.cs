using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MTCrepository.Repository
{
    public class SqlProductReviewRepository : TDSrepositoryAsync<ProductReview>, IProductReviewRepository
    {
        //==================================================================================

        public SqlProductReviewRepository(AppDbContext aAppContext) : base(aAppContext)
        {
            
        }

        public override Task<TSDreposResultOneObject<ProductReview>> AddAsync(ProductReview aEntity, bool autoSaveChange = true)
        {
            if(aEntity.Rating>0)
            { 
            var countRatings = _context.ProductReviews.Where(x => x.ProductEAN == aEntity.ProductEAN).Select(x => x.Rating).ToList();

            countRatings.Add(aEntity.Rating);


            double newAVRrating = (double)countRatings.Sum() / countRatings.Count();

            var productFounded = _context.Products.FirstOrDefault(x => x.EAN == aEntity.ProductEAN);
            productFounded.AverageRating = newAVRrating;
            productFounded.RatingCount = countRatings.Count();
            _context.SaveChanges();
                
            }


            return base.AddAsync(aEntity, autoSaveChange);
        }
        public async override Task<TSDreposResultOneObject<ProductReview>> GetByIdAsync(params object[] aPrimaryKey)
        {
            var terug = new TSDreposResultOneObject<ProductReview>();
            try
            {
                terug.Data = await _context.Set<ProductReview>().Include(x => x.Client).FirstOrDefaultAsync(x=>x.ClientId==aPrimaryKey.ToString());
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
    }
}
