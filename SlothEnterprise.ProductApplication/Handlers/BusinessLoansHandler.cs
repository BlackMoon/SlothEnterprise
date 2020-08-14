namespace SlothEnterprise.ProductApplication.Handlers
{
    using SlothEnterprise.External;
    using SlothEnterprise.External.V1;
    using SlothEnterprise.ProductApplication.Applications;
    using SlothEnterprise.ProductApplication.Products;

    public class BusinessLoansHandler : IProductHandler<BusinessLoans, int>
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoansHandler(IBusinessLoansService businessLoansService)
        {
            _businessLoansService = businessLoansService;
        }

        public int Execute(ISellerApplication application)
        {
            var loans = application.Product as BusinessLoans;
            if (application.CompanyData == null || loans != null)
            {
                return Globals.NulResult;
            }

            var result = _businessLoansService.SubmitApplicationFor(
                application.CompanyData.FromCompanyData(), 
                new LoansRequest
            {
                InterestRatePerAnnum = loans.InterestRatePerAnnum,
                LoanAmount = loans.LoanAmount
            });
            return result.Success ? result.ApplicationId ?? -1 : -1;
        }
    }
}
