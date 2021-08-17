using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public interface IProductCategorieRepository : ITDSrepositoryAsync<ProductCategorie>
    {
     
        Task<TSDreposResultIenumerable<ProductCategorie>> GetCategoriesWithSubandParent();

        Task<IEnumerable<ProductCategorie>> GetAllParents(int categoryId, List<ProductCategorie> productCategories = null);
    }
}
