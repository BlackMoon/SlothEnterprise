namespace SlothEnterprise.ProductApplication
{
    using SlothEnterprise.External;
    using SlothEnterprise.ProductApplication.Applications;
    public static class Extensions
    {
        public static CompanyDataRequest FromCompanyData(this ISellerCompanyData companyData) =>

            new CompanyDataRequest
            {
                CompanyFounded = companyData.Founded,
                CompanyNumber = companyData.Number,
                CompanyName = companyData.Name,
                DirectorName = companyData.DirectorName
            };
    }
}
