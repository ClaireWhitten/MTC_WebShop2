
using MTCrepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public interface IApplicationRepository
    {
        IProductRepository Products { get; }
        IAddressRepository Addresses { get; }

        IBonusRepository Bonusses { get; }
        IClientRepository Clients { get; }
        IOrderINRepository OrderINs { get; }
        IOrderLineINRepository OrderlineINs { get; }
        IOrderLineOUTRepository OrderlineOUTs { get; }
        IOrderOUTRepository OrderOUTs { get; }
        IProductCategorieRepository ProductCategories { get; }
        IProductReviewRepository ProductReviews { get; }
        IReturnedProductsRepository ReturnedProducts { get; }
        ISupplierRepository Suppliers { get; }
        ITransporterRepository Transporters { get; }
        IZoneRepository Zones { get; }


        //void SaveChanged();
    }
}
