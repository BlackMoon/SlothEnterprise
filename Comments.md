Code issues with ProductApplicationService

1. Many if {} blocks. Difficult to maintain as the number of product types grows

2. ProductApplicationService constructor's arguments. 
Adding new external service into ProductApplicationService need to change the constructor.
After a while constructor may have a lot of arguments

3. Various argument types and return types for each external service call.
For each call to the external service, you need to use different objects types both for input and output.
This causes to import lots of references to types.

4. Absence of null checking. CompanyData and Product properties are references and may point to null.

5. 2 times writing the same code when creating new CompanyDataRequest from CompanyData. 
This can be moved to private method or extenssion

6. InvalidOperationException. It will be more convenient to add details to the error message.

7. Optional. Some interfaces and classes are located in the same file, e.g. SellerApplication, SellerCompanyData.
Separate interface and implementation files make code cleaner.



p.s. There is a new version of ProductApplicationService called ProductApplicationServiceEnhanced, which resolves all of the above problems.
Also it is covered with unit-tests.
