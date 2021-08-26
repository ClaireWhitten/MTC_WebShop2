using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTCrepository.Repository
{
    public interface IProductRepository : ITDSrepositoryAsync<Product>
    {
        Task<TSDreposResultIenumerable<Product>> GetProductsWithSuppliers();


        Task<HomeIndexDTO> GetProductsByCategoryId(int? categoryId, bool isSubsIncluded=false);

        Task<TSDreposResultIenumerable<Product>> GetProductsLowInStock();
    }
}
