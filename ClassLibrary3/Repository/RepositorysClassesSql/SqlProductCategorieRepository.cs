using Microsoft.EntityFrameworkCore;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
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
    }
}
