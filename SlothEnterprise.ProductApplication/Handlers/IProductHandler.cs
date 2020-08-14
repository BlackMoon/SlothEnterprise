namespace SlothEnterprise.ProductApplication.Handlers
{
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Products;    

    /// <summary>
    /// Base interface for product handlers
    /// </summary>
    /// <typeparam name="TParameter">Product type</typeparam>
    /// <typeparam name="TResult">Command Result type</typeparam>
    public interface IProductHandler<out TParameter, TResult> where TParameter : IProduct
    {
        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns>Task</returns>
        TResult Execute(ISellerApplication application);
    }
}
