using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
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
    }
}
