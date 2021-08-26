using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MTCrepository.Repository
{
    public  class SqlProductRepository : TDSrepositoryAsync<Product>, IProductRepository
    {
        //==================================================================================

        public SqlProductRepository(AppDbContext aAppContext) : base(aAppContext)
        {
           
        }
        public async Task<TSDreposResultIenumerable<Product>> GetProductsWithSuppliers()
        {
            var terug = new TSDreposResultIenumerable<Product>();

            terug.Data = await _context.Set<Product>().Include(x => x.Suppliers).Include(x=>x.Images).Include(x=>x.Categorie).ToListAsync();

            return terug;
        }
        //public async Task<TSDreposResultOneObject<Product>> GetProductCategoryPath(int id)
        //{
        //    var parentCategories =_context.ProductCategories await _context.Products.FirstOrDefaultAsync(p=>p.CategorieId==id).get;
        //    string parentPath = "";
        //    foreach (var parentCategory in parentCategories)
        //    {
        //        parentPath += ">" + parentCategory.Name;
        //    }
        //}
        //public async Task<IEnumerable<ProductCategorie>> GetAllParents(int categoryId, List<ProductCategorie> productCategories = null)
        //{
        //    //if no list has been passed as parameter, create a new list
        //    productCategories = productCategories ?? new List<ProductCategorie>();

        //    //Get chosen category with it's parent category
        //    var chosenCategory = await _context.Set<ProductCategorie>().Include(c => c.ParentCategorie).FirstOrDefaultAsync(c => c.ID == categoryId);

        //    if (chosenCategory.ParentCategorie == null)
        //    {
        //        productCategories.Add(chosenCategory);
        //        productCategories.Reverse();
        //        return productCategories;
        //    }
        //    else
        //    {
        //        productCategories.Add(chosenCategory);
        //        return await GetAllParents(chosenCategory.ParentCategorie.ID, productCategories);
        //    }

        //}
        //public override Task<TSDreposResultOneObject<Product>> GetByIdAsync(Product aEntity, bool autoSaveChange = true)
        //{
        //    //hier isActive = false

        //    return base.RemoveAsync(aEntity, autoSaveChange);
        //}
        public override async Task<TSDreposResultOneObject<Product>> GetByIdAsync(params object[] aPrimaryKey)
        {
            var terug = new TSDreposResultOneObject<Product>();
                terug.Data = await _context.Set<Product>().Include(x => x.Images).Include(x => x.Suppliers).Include(x => x.ReturnedProducts).Include(x => x.ProductReviews).FirstOrDefaultAsync(p => p.EAN == aPrimaryKey[0].ToString());
                return terug;
        }

        public override Task<TSDreposResultOneObject<Product>> RemoveAsync(Product aEntity, bool autoSaveChange = true)
        {
            aEntity.IsActive = false;
            return base.UpdateAsync(aEntity, autoSaveChange);
        }





        #region=============================================================================================================== DTO for the home/index
        // new method writed by Tom
        // give all the products by productcategory
        // if the optional parameter 'isSubsIncluded' is true, also the subcats load his products
        public async Task<HomeIndexDTO> GetProductsByCategoryId(int? categoryId=null, bool isSubsIncluded=true)
        {
            List<Product> foundedProducts;

            if (categoryId == null)
            {
                foundedProducts = _context.Products.ToList();
            }
            else
            {
                //this is the list with  id of this cat,  and sub category if needed
                List<int> foundedSubs = new List<int>() { categoryId.Value };

                //subs capture if needed
                if (isSubsIncluded)
                {
                    //alle categorys ophalen uit DB
                    List<ProductCategorie> allProductCategorys = await _context.ProductCategories.ToListAsync();
                    storeAlleSubcatsInListFoundedSubs(categoryId.Value, foundedSubs, allProductCategorys);
                }

                //do the bulck Select query, this give al the products by the list of category'ids
                foundedProducts = _context.Products.Where(p => foundedSubs.Contains(p.CategorieId)).ToList();
            }

            return new HomeIndexDTO
            {
                Products = foundedProducts,
            };

        }
        //recursivehelper for the above method
        private void storeAlleSubcatsInListFoundedSubs(int categoryToSearch, List<int>foundedSubs , List<ProductCategorie>allCategorys  )
        {
            var alleInThisCat = allCategorys.Where(x => x.ParentCategorieID == categoryToSearch);

            foreach (var item in alleInThisCat)
            {
                //store in list
                foundedSubs.Add(item.ID);
                //and recursive
                storeAlleSubcatsInListFoundedSubs(item.ID, foundedSubs, allCategorys);
            }
        }





        public async Task<TSDreposResultIenumerable<Product>> GetProductsLowInStock()
        {
            var terug = new TSDreposResultIenumerable<Product>();

            terug.Data = await _context.Products.Where(p => p.IsActive && p.CountInStock <= p.MinStock)
                .Include(p => p.Suppliers)
                .Include(p => p.OrderLineINs)
                .ThenInclude(ol=>ol.OrderIN)
                .ToListAsync();

            return terug;
            
        }

        #endregion===================================================================================================================================

    }
}
