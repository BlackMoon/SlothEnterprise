namespace SlothEnterprise.ProductApplication.ServicesImpl
{
    using System;
    using SlothEnterprise.External;
    using SlothEnterprise.External.V1;

    public class ConfidentialInvoiceService : IConfidentialInvoiceService
    {
        public IApplicationResult SubmitApplicationFor(CompanyDataRequest applicantData, decimal invoiceLedgerTotalValue, decimal advantagePercentage, decimal vatRate)
        {
            throw new NotImplementedException();
        }
    }
}
