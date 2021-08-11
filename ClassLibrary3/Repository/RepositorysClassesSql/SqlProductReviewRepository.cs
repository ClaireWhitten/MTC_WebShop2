using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
            var countRatings = _context.ProductReviews.Where(x => x.ProductEAN == aEntity.ProductEAN).Select(x => x.Rating).ToList();

            countRatings.Add(aEntity.Rating);


            double newAVRrating = (double)countRatings.Sum() / countRatings.Count();

            var productFounded = _context.Products.FirstOrDefault(x => x.EAN == aEntity.ProductEAN);
            productFounded.AverageRating = newAVRrating;
            _context.SaveChanges();



            return base.AddAsync(aEntity, autoSaveChange);
        }
    }
}
