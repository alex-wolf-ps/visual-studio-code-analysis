using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LoanManager.Data.EFCore
{
    public class LoanApplicationResultRepository : ILoanApplicationResultRepository
    {

        public LoanApplicationResultRepository(LoanCalculatorContext context)
        {
            _context = context;
        }


        private readonly LoanCalculatorContext _context;

        public List<LoanApplicationResult> GetLoanApplicationResults()
        {
            return _context.LoanApplicationResults.ToList();
        }

        public void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult)
        {
            _context.LoanApplicationResults.Add(loanApplicationResult);
            _context.SaveChanges();
        }

        public LoanApplicationResult GetLoan(int id)
        {
            return _context.LoanApplicationResults.FirstOrDefault(r => r.ResultId == id);
        }
    }
}
