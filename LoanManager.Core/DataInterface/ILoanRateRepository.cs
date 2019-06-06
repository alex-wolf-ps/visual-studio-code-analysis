using LoanManager.Core.Domain;
using System.Collections.Generic;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanRateRepository
    {

        List<LoanRate> GetLoanRates();


    }
}
