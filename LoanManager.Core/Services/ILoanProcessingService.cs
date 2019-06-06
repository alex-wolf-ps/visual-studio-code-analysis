using LoanManager.Core.Domain;

namespace LoanManager.Core.Services
{
    public interface ILoanProcessingService
    {
        LoanApplicationResult ProcessLoan(LoanApplication application);
    }
}