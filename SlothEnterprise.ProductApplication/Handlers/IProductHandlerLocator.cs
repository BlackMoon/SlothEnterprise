namespace SlothEnterprise.ProductApplication.Handlers
{
    using SlothEnterprise.ProductApplication.Products;
    using System;

    public interface IProductHandlerLocator<TParameter, TResult> 
        where TParameter: IProduct 
        where TResult : IProductHandler<TParameter, int>
    {
        TResult GetService<T>() where T: IProduct;

        TResult GetService(Type t);
    }
}
