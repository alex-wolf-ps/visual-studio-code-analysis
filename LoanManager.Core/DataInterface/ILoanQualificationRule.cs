using LoanManager.Core.Domain;
using System;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanQualificationRule
    {

        String RuleName { get; }

        bool CheckLoanApprovalRule(LoanApplication application);



    }
}
