namespace SlothEnterprise.ProductApplication.Tests
{
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Products;
    using SlothEnterprise.ProductApplication.ServicesImpl;
    using System;
    using Xunit;

    public class ProductApplicationTests
    {
        private readonly ProductHandlerLocator _productHandlerLocator;
        private readonly ProductApplicationService _productApplicationService;
        private readonly ProductApplicationServiceEnhanced _productApplicationServiceEnhanced;
        public ProductApplicationTests()
        {
            var businessLoansService = new BusinessLoansService();
            var confidentialInvoiceWebService = new ConfidentialInvoiceService();
            var selectInvoiceService = new SelectInvoiceService();

            _productHandlerLocator = new ProductHandlerLocator(selectInvoiceService, confidentialInvoiceWebService, businessLoansService);
            _productApplicationService = new ProductApplicationService(selectInvoiceService, confidentialInvoiceWebService, businessLoansService);
            _productApplicationServiceEnhanced = new ProductApplicationServiceEnhanced(_productHandlerLocator);
        }

        [Theory]
        [InlineData(typeof(BusinessLoans))]
        [InlineData(typeof(ConfidentialInvoiceDiscount))]
        [InlineData(typeof(SelectiveInvoiceDiscount))]
        public void ProductHandlerLocator_Should_Get_Handler(Type productType)
        {
            var handler = _productHandlerLocator.GetService(productType);
            Assert.NotNull(handler);        
        }

        [Theory]
        [InlineData(typeof(SomeOtherProduct))]        
        public void ProductHandlerLocator_Should_Not_Get_Handler(Type productType)
        {
            var handler = _productHandlerLocator.GetService(productType);
            Assert.Null(handler);
        }

        [Fact]
        public void ProductApplicationService_Should_Throw_Exception_When_Product_Not_Defined()
        {
            var application = new SellerApplication();
            Assert.Throws<InvalidOperationException>(() => _productApplicationService.SubmitApplicationFor(application));
        }

        [Fact]
        public void ProductApplicationServiceEnhanced_Should_Throw_Exception_When_Product_Not_Defined()
        {
            var application = new SellerApplication();            
            Assert.Throws<InvalidOperationException>(() => _productApplicationServiceEnhanced.SubmitApplicationFor(application));
        }
    }
}
