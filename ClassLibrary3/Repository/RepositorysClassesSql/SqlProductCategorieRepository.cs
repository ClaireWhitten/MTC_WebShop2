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

        //Gets all categories with subcategories and parent

        public async Task<TSDreposResultIenumerable<ProductCategorie>> GetCategoriesWithSubandParent()
        {
            var terug = new TSDreposResultIenumerable<ProductCategorie>();

            terug.Data = await _context.Set<ProductCategorie>().Include(c => c.ParentCategorie).Include(c => c.SubCategories).ToListAsync();

            return terug;
        }


        //Gets a category with parent, products, direct subcategories and their products

        public async Task<TSDreposResultOneObject<ProductCategorie>> GetCategoryWithAll(int id)
        {
            var terug = new TSDreposResultOneObject<ProductCategorie>();

            terug.Data = await _context.Set<ProductCategorie>()
                .Include(c => c.ParentCategorie)
                .Include(c => c.Products)
                .Include(c => c.SubCategories)         
                .ThenInclude(sc => sc.Products)
                .FirstOrDefaultAsync(c=>c.ID == id);

            return terug;
        }








        //Gets a category with products
        public async Task<TSDreposResultOneObject<ProductCategorie>> GetCategoryWithProducts(int categoryId)
        {
            var terug = new TSDreposResultOneObject<ProductCategorie>();

            terug.Data = await _context.Set<ProductCategorie>().Include(c => c.Products).FirstOrDefaultAsync(c=>c.ID == categoryId);

            return terug;
        }



        //method gets parent paths
        public async Task<Dictionary<int, string>> GetAllPosiblePaths()
        {
            Dictionary<int, string> dicToFill = new Dictionary<int, string>();
            List<ProductCategorie> allCategorys = await _context.Set<ProductCategorie>().ToListAsync();
            //eerst iriteren vanaf de productcategorys zonder parent
            foreach (var item in allCategorys.Where(x => x.ParentCategorieID == null))
            {
                dicToFill.Add(item.ID, item.Name);
                GetAllNextPaths(item.ID, item.Name, allCategorys, dicToFill);
            }

            return dicToFill;
        }
        //Dictionary<int, string>
        private void GetAllNextPaths(int id, string buildstringPath, List<ProductCategorie> allCategorys, Dictionary<int, string> dicToFill)
        {
            foreach (var item in allCategorys.Where(x => x.ParentCategorieID == id))
            {
                dicToFill.Add(item.ID, buildstringPath + ">" + item.Name);
                GetAllNextPaths(item.ID, buildstringPath + ">" + item.Name, allCategorys, dicToFill);
            }
        }







        ////Method returns list of all parents of a given category
        ////optional parameter
        //public async Task<IEnumerable<ProductCategorie>> GetAllParents(int categoryId, List<ProductCategorie> productCategories = null)
        //{
        //    //r AllCategorys = await _context.Set<ProductCategorie>().Include(c => c.ParentCategorie).ToListAsync();








        ////Method returns list of all parents of a given category
        //                                                                                               //optional parameter
        //public async Task<IEnumerable<ProductCategorie>> GetAllParents(int categoryId, List<ProductCategorie> productCategories = null)
        //{
        //    //if no list has been passed as parameter, create a new list
        //    productCategories = productCategories ?? new List<ProductCategorie>();

        //    //Get chosen category with its parent category
        //    var chosenCategory = await _context.Set<ProductCategorie>().Include(c => c.ParentCategorie).FirstOrDefaultAsync(c => c.ID == categoryId);

        //    if(chosenCategory.ParentCategorie == null)
        //    {
        //        productCategories.Add(chosenCategory);
        //        productCategories.Reverse();
        //        return productCategories;
        //    }
        //    else
        //    {
        //        productCategories.Add(chosenCategory);
        //        return await GetAllParents(chosenCategory.ParentCategorie.ID,  productCategories);
        //    }

        //}

        //    var chosenCategory = allCategorie.FirstOrDefault(c => c.ID == categoryId);


        //    if (chosenCategory.ParentCategorie == null)
        //    {
        //        productCategories.Add(chosenCategory);
        //        productCategories.Reverse();
        //        return productCategories;
        //    }
        //    else
        //    {
        //        productCategories.Add(chosenCategory);
        //        return await GetAllParentsPrivate(chosenCategory.ParentCategorie.ID, productCategories);
        //    }
        //}







        //Method returns list of all parents of a given category
        //optional parameter
        public async Task<Dictionary<int, string>> GetAllPosiblePaths()
        {
            Dictionary<int, string> dicToFill = new Dictionary<int, string>();
            List<ProductCategorie> allCategorys = await _context.Set<ProductCategorie>().ToListAsync();
            //eerst iriteren vanaf de productcategorys zonder parent
            foreach (var item in allCategorys.Where(x => x.ParentCategorieID == null))
            {
                dicToFill.Add(item.ID, item.Name);
                GetAllNextPaths(item.ID, item.Name, allCategorys, dicToFill);
            }

            return dicToFill;
        }
        //Dictionary<int, string>
        private void GetAllNextPaths(int id, string buildstringPath, List<ProductCategorie> allCategorys, Dictionary<int, string> dicToFill)
        {
            foreach (var item in allCategorys.Where(x => x.ParentCategorieID == id))
            {
                dicToFill.Add(item.ID, buildstringPath + ">" + item.Name);
                GetAllNextPaths(item.ID, buildstringPath + ">" + item.Name, allCategorys, dicToFill);
            }
        }






        //Method returns list of all related subcateogries 
        public List<ProductCategorie> Subcategories { get; set; } 

        public List<ProductCategorie> GetAllSubCats(int categoryId)
        {

            Subcategories = new List<ProductCategorie>();

            SearchAllSubs(categoryId);

            return Subcategories;
        }

        public void SearchAllSubs(int categoryId)
        {
            //Get chosen category including subcategories
            var chosenCategory = _context.Set<ProductCategorie>()
                .Include(c => c.SubCategories)
                .ThenInclude(c => c.Products)
                .FirstOrDefault(c => c.ID == categoryId);

            //if it has no subcategories return null
            if (chosenCategory.SubCategories.Count() != 0)
            {
                foreach (var subcategory in chosenCategory.SubCategories)
                {
                    Subcategories.Add(subcategory);
                    SearchAllSubs(subcategory.ID);
                }

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
