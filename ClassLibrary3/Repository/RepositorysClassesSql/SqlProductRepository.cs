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
        ////public override Task<TSDreposResultOneObject<Product>> AddAsync(Product aEntity, bool autoSaveChange = true)
        ////{
        ////    //hier isActive = false

        ////    //return base.RemoveAsync(aEntity, autoSaveChange);
        ////}
    }
}
