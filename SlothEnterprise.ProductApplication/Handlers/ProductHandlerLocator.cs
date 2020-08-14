namespace SlothEnterprise.ProductApplication
{
    using System;
    using System.Collections.Generic;
    using SlothEnterprise.External.V1;
    using SlothEnterprise.ProductApplication.Handlers;
    using SlothEnterprise.ProductApplication.Products;

    public class ProductHandlerLocator : IProductHandlerLocator<IProduct, IProductHandler<IProduct, int>>
    {
        private readonly IReadOnlyDictionary<Type, IProductHandler<IProduct, int>> _services;

        public ProductHandlerLocator(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _services = new Dictionary<Type, IProductHandler<IProduct, int>>
            {
                { typeof(BusinessLoans), new BusinessLoansHandler(businessLoansService) },
                { typeof(ConfidentialInvoiceDiscount), new ConfidentialInvoiceDiscountHandler(confidentialInvoiceWebService) },
                { typeof(SelectiveInvoiceDiscount), new SelectiveInvoiceDiscountHandler(selectInvoiceService) }
            };
        }

        public IProductHandler<IProduct, int> GetService<T>() where T : IProduct
        {
            _services.TryGetValue(typeof(T), out var handler);
            return handler;
        }

        public IProductHandler<IProduct, int> GetService(Type t)
        {
            IProductHandler<IProduct, int> handler = null;
            if (t != null) {
                _services.TryGetValue(t, out handler);
            }

            return handler;
        }
    }
}
