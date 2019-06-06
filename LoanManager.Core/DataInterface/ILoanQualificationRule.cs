using LoanManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManager.Core.DataInterface
{
    public interface ILoanQualificationRule
    {

        String RuleName { get; }

        bool CheckLoanApprovalRule(LoanApplication application);


        
    }
}
