using LoanManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanRateRepository
    {

        List<LoanRate> GetLoanRates();


    }
}
