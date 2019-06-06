using LoanManager.Core.Domain;
using System.Collections.Generic;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanApplicationResultRepository
    {

        List<LoanApplicationResult> GetLoanApplicationResults();

        LoanApplicationResult GetLoan(int id);

        void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult);


    }
}
