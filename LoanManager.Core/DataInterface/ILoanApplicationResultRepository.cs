using LoanManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanApplicationResultRepository
    {

        List<LoanApplicationResult> GetLoanApplicationResults();

        LoanApplicationResult GetLoan(int id);

        void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult);


    }
}
