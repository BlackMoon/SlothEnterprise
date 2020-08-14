namespace SlothEnterprise.ProductApplication
{
    using System;    
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Handlers;
    using SlothEnterprise.ProductApplication.Products;   

    public class ProductApplicationServiceEnhanced
    {
        private readonly IProductHandlerLocator<IProduct, IProductHandler<IProduct, int>> _serviceLocator;

        public ProductApplicationServiceEnhanced(IProductHandlerLocator<IProduct, IProductHandler<IProduct, int>> serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public int SubmitApplicationFor(ISellerApplication application)
        {
            var productType = application.Product?.GetType();
            var handler = _serviceLocator.GetService(productType);
            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for product of {productType} not found");
            }

            return handler.Execute(application);
        }
    }

}
