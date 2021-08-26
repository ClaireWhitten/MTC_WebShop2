
using MTCrepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;
        //================================================================================= interne repositry's

        private IProductRepository _productsRepos;
        public IProductRepository Products => _productsRepos ?? new SqlProductRepository(_context);
        //-------------------------------------------------------------------

        private IAddressRepository _AddressRepos;
        public IAddressRepository Addresses => _AddressRepos ?? new SqlAddressRepository(_context);
        //-------------------------------------------------------------------
        private IBonusRepository _BonussesRepos;
        public IBonusRepository Bonusses => _BonussesRepos ?? new SqlBonusRepository(_context);
        //-------------------------------------------------------------------
        private IClientRepository _clientrepos;
        public IClientRepository Clients => _clientrepos ?? new SqlClientRepository(_context);
        //-------------------------------------------------------------------
        private IOrderINRepository _OrderInRepos;
        public IOrderINRepository OrderINs => _OrderInRepos ?? new SqlOrderINRepository(_context);
        //-------------------------------------------------------------------
        private IOrderLineINRepository _OrderLineInRepos;
        public IOrderLineINRepository OrderlineINs => _OrderLineInRepos ?? new SqlOrderLineINRepository(_context);
        //-------------------------------------------------------------------
        private IOrderLineOUTRepository _IOrderLineOUTRepository;
        public IOrderLineOUTRepository OrderlineOUTs => _IOrderLineOUTRepository ?? new SqlOrderLineOUTRepository(_context);
        //-------------------------------------------------------------------
        private IOrderOUTRepository _IOrderOUTRepository;
        public IOrderOUTRepository OrderOUTs => _IOrderOUTRepository ?? new SqlOrderOUTRepository(_context);
        //-------------------------------------------------------------------
        private IProductCategorieRepository _IProductCategorieRepository;
        public IProductCategorieRepository ProductCategories => _IProductCategorieRepository ?? new SqlProductCategorieRepository(_context);
        //-------------------------------------------------------------------
        private IProductReviewRepository _IProductReviewRepository;
        public IProductReviewRepository ProductReviews => _IProductReviewRepository ?? new SqlProductReviewRepository(_context);
        //-------------------------------------------------------------------
        private IReturnedProductsRepository _IReturnedProductsRepository;
        public IReturnedProductsRepository ReturnedProducts => _IReturnedProductsRepository ?? new SqlReturnedProductsRepository(_context);
        //-------------------------------------------------------------------
        private ISupplierRepository _ISupplierRepository;
        public ISupplierRepository Suppliers => _ISupplierRepository ?? new SqlSupplierRepository(_context);
        //-------------------------------------------------------------------
        private ITransporterRepository _ITransporterRepository;
        public ITransporterRepository Transporters => _ITransporterRepository ?? new SqlTransporterRepository(_context);
        //-------------------------------------------------------------------
        private IZoneRepository _IZoneRepository;
        public IZoneRepository Zones => _IZoneRepository ?? new SqlZoneRepository(_context);
        //-------------------------------------------------------------------
        private IProductImageRepository _IProductImageRepository;
        public IProductImageRepository ProductImages => _IProductImageRepository ?? new SqlProductImageRepository(_context);
        //-------------------------------------------------------------------
        private IITestModelRepository _IITestModelRepository;
        public IITestModelRepository TestModel => _IITestModelRepository ?? new SqlTestModelRepository(_context);
        //-------------------------------------------------------------------
        private IChatMessageRepository _IChatMessageRepository;
        public IChatMessageRepository ChatImages => _IChatMessageRepository ?? new SqlChatMesageRepository(_context);
        //-------------------------------------------------------------------

        //================================================================================================ ctor

        public ApplicationRepository(AppDbContext aApplicationContext)
        {
            _context = aApplicationContext;
        }


    }
}
