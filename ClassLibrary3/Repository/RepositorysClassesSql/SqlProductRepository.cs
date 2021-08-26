using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public class SqlProductRepository : TDSrepositoryAsync<Product>, IProductRepository
    {
        //==================================================================================

        public SqlProductRepository(AppDbContext aAppContext) : base(aAppContext)
        {

        }
        public async Task<TSDreposResultIenumerable<Product>> GetProductsWithSuppliers()
        {
            var terug = new TSDreposResultIenumerable<Product>();

            terug.Data = await _context.Set<Product>().Include(x => x.Suppliers).Include(x => x.Images).Include(x => x.Categorie).ToListAsync();

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
        public async Task<List<Product>> GetProductsByCategoryId(int? categoryId = null, bool isSubsIncluded = true)
        {
            List<Product> foundedProducts;
            //List<ProductCategorie> fullPath = null; //replace in _layout
            //alle categorys ophalen uit DB

            if (categoryId == null)
            {
                foundedProducts = await _context.Products.Where(x => x.SolderPrice != null && x.SolderPrice > 0).Include(p => p.Images).ToListAsync();

                //this is slower then above, why?
                //var dbResult = await _context.Products.Select(i => new { Image = i.Images.FirstOrDefault(), Product = i }).ToListAsync();
                //foundedProducts = new List<Product>();
                //foreach (var item in dbResult)
                //{
                //    Product pr = item.Product;
                //    pr.Images = new List<ProductImage> { item.Image };
                //    foundedProducts.Add(item.Product);
                //}
            }
            else
            {

                List<ProductCategorie> allProductCategorys = await _context.ProductCategories.ToListAsync();

                //this is the list with  id of this cat,  and sub category if needed
                List<int> foundedSubs = new List<int>() { categoryId.Value };

                //we fill the list fullPath, logic is changed to _layout
                //fullPath = new List<ProductCategorie>();
                //ProductCategorie tmp = allProductCategorys.First(x => x.ID == categoryId);
                //while (true)
                //{
                //    fullPath.Insert(0, tmp);
                //    tmp = allProductCategorys.FirstOrDefault(x => x.ID == tmp.ParentCategorieID);
                //    if (tmp == null)
                //    {
                //        break;
                //    }
                //}

                //do
                //{
                //    tmp = allProductCategorys.First(x => x.ID == tmp.ParentCategorieID);
                //    fullPath.Insert(0,tmp);
                //} while (tmp.ParentCategorieID != null);

                //subs capture if needed
                if (isSubsIncluded)
                {
                    storeAlleSubcatsInListFoundedSubs(categoryId.Value, foundedSubs, allProductCategorys);
                }
                
                //do the bulck Select query, this give al the products by the list of category'ids
                foundedProducts = await _context.Products.Where(p => foundedSubs.Contains(p.CategorieId)).Include(p => p.Images).ToListAsync();

                //this is slower then above, why?
                //var dbResult = await _context.Products.Where(p => foundedSubs.Contains(p.CategorieId)).Include(p => p.Images).Select(i => new { Image = i.Images.FirstOrDefault(), Product = i }).ToListAsync();
                //foundedProducts = new List<Product>();
                //foreach (var item in dbResult)
                //{
                //    Product pr = item.Product;
                //    pr.Images = new List<ProductImage> { item.Image };
                //    foundedProducts.Add(item.Product);
                //}

            }

            return foundedProducts;

        }
        //recursivehelper for the above method
        private void storeAlleSubcatsInListFoundedSubs(int categoryToSearch, List<int> foundedSubs, List<ProductCategorie> allCategorys)
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
        //NOT WORKInG
        ////methode returnd alle prodcuten en maakt altijd de icolection Images aan, 
        ////het eerste element kan ofwel een image zijn ofwel null
        //public async Task<List<ProductWithOneImageAsString_DTO>> GetAllProductsWithFirstImage()
        //{

        //    var dbResult = await _context.Products.Select(i => new  { Image = i.Images.FirstOrDefault() , Product = i }) .ToListAsync();

            

        //    List<ProductWithOneImageAsString_DTO> terug = new List<ProductWithOneImageAsString_DTO>();
        //    foreach (var item in dbResult)
        //    {
        //        ProductWithOneImageAsString_DTO toAdd = new ProductWithOneImageAsString_DTO()
        //        {
        //            Product = item.Product;
        //        }
        //        //toAdd.Images = new List<ProductImage> { item.Image };
        //        toAdd.ProductImagesrc = item.Image !=null ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image.Image)): null ;
        //        terug.Add(toAdd);
        //    }
        //    return terug;
        //}
    }
}
