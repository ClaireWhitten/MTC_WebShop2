using MTCmodel;
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
    }
}
