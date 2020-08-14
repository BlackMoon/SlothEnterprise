namespace SlothEnterprise.ProductApplication.Handlers
{
    using SlothEnterprise.External.V1;
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Products;    

    public class SelectiveInvoiceDiscountHandler : IProductHandler<SelectiveInvoiceDiscount, int>
    {
        private readonly ISelectInvoiceService _selectInvoiceService;

        public SelectiveInvoiceDiscountHandler(ISelectInvoiceService selectInvoiceService)
        {
            this._selectInvoiceService = selectInvoiceService;
        }       

        public int Execute(ISellerApplication application)
        {
            var sid = application.Product as SelectiveInvoiceDiscount;
            if (application.CompanyData == null || sid == null)
            {
                return Globals.NulResult;
            }

            return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), sid.InvoiceAmount, sid.AdvancePercentage);
        }
    }
}
