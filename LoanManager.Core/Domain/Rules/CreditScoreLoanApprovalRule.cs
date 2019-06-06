using LoanManager.Core.DataInterface;
using System;

namespace LoanManager.Core.Domain
{
    public class CreditScoreLoanApprovalRule : ILoanQualificationRule
    {

        public const String RULE_NAME = "Credit Score";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            return application.CreditScore > 400;
        }
    }
}
