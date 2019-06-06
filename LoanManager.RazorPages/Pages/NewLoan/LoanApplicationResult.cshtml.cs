using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanManager.RazorPages.Pages.NewLoan
{
    public class LoanApplicationResultModel : PageModel
    {

        public LoanApplicationResultModel(ILoanApplicationResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        private ILoanApplicationResultRepository _resultRepository;



        public LoanApplicationResult Result { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Result = _resultRepository.GetLoan(id.Value);

            if (Result == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}