namespace SlothEnterprise.ProductApplication.Handlers
{   
    using SlothEnterprise.External.V1;
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Products;

    public class ConfidentialInvoiceDiscountHandler : IProductHandler<ConfidentialInvoiceDiscount, int>
    {
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;

        public ConfidentialInvoiceDiscountHandler(IConfidentialInvoiceService confidentialInvoiceService)
        {
            _confidentialInvoiceWebService = confidentialInvoiceService;
        }

        public int Execute(ISellerApplication application)
        {
            var cid = application.Product as ConfidentialInvoiceDiscount;
            if (application.CompanyData == null || cid == null)
            {
                return Globals.NulResult;
            }

            var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                  application.CompanyData.FromCompanyData(), 
                  cid.TotalLedgerNetworth, cid.AdvancePercentage, cid.VatRate);

            return result.Success ? result.ApplicationId ?? -1 : -1;
        }
    }
}
