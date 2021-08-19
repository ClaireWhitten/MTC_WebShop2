using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public class SqlProductCategorieRepository : TDSrepositoryAsync<ProductCategorie>, IProductCategorieRepository
    {
        //==================================================================================

        public SqlProductCategorieRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }

        //Gets all products including their subcategories and parent

        public async Task<TSDreposResultIenumerable<ProductCategorie>> GetCategoriesWithSubandParent()
        {
            var terug = new TSDreposResultIenumerable<ProductCategorie>();

            terug.Data = await _context.Set<ProductCategorie>().Include(c=>c.ParentCategorie).Include(c=>c.SubCategories).Include(c=>c.Products).ToListAsync();

            return terug;
        }
                                                                                                            //optional parameter
        public async Task<IEnumerable<ProductCategorie>> GetAllParents(int categoryId, List<ProductCategorie> productCategories = null)
        {
            //if no list has been passed as parameter, create a new list
            productCategories = productCategories ?? new List<ProductCategorie>();

            //Get chosen category with it's parent category
            var chosenCategory = await _context.Set<ProductCategorie>().Include(c => c.ParentCategorie).FirstOrDefaultAsync(c => c.ID == categoryId);

            if(chosenCategory.ParentCategorie == null)
            {
                productCategories.Add(chosenCategory);
                productCategories.Reverse();
                return productCategories;
            }
            else
            {
                productCategories.Add(chosenCategory);
                return await GetAllParents(chosenCategory.ParentCategorie.ID,  productCategories);
            }

        }

        //public async Task<IEnumerable<ProductCategorie>> GetAllchilds(int categoryId, List<ProductCategorie> productCategories = null)
        //{
        //    //if no list has been passed as parameter, create a new list
        //    productCategories = productCategories ?? new List<ProductCategorie>();

        //    //Get chosen category with it's childs category
        //    var chosenCategory = await _context.Set<ProductCategorie>().Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.ID == categoryId);

        //    if (chosenCategory.SubCategories == null)
        //    {
        //        productCategories.Add(chosenCategory);

        //        return productCategories;
        //    }
        //    else
        //    {
        //        foreach (var item in chosenCategory.SubCategories)
        //        {
        //            productCategories.Add(item);
        //            return await GetAllchilds(item.ID, productCategories);

        //        }
        //        return productCategories;
        //    }

        //}
    }
}
