using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace LoanManager.Data.EFCore
{


    public class LoanRateRepository : ILoanRateRepository
    {

        public LoanRateRepository(LoanCalculatorContext context)
        {
            _context = context;
        }


        private readonly LoanCalculatorContext _context;



        public List<LoanRate> GetLoanRates()
        {
            return _context.LoanRates.ToList();
        }
    }


}
