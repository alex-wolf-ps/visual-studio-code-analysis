using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using LoanManager.Core.Services;
using LoanManager.RazorPages.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LoanManager.RazorPages.Pages.NewLoan
{
    public class CreateModel : PageModel
    {
        private readonly LoanProcessingService _loanProcessingService;

        private readonly ILoanApplicationResultRepository _resultRepository;

        public CreateModel(LoanProcessingService loanProcessingService, ILoanApplicationResultRepository resultRepository)
        {
            _loanProcessingService = loanProcessingService;
            _resultRepository = resultRepository;
        }

        public IList<SelectListItem> Persons { get; private set; }

        public IList<SelectListItem> LoanTerms { get; private set; }


        [BindProperty]
        public LoanApplication LoanApplication { get; set; }

        [BindProperty]
        public int TermYears { get; set; }


        public IActionResult OnGet()
        {
            LoanTerms = LoanTerm.LoanTerms.Values
                .OrderBy(t => t.Years)
                .ToSelectList(t => t.Years.ToString(), t => t.Name);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoanTerms = LoanTerm.LoanTerms.Values
                    .OrderBy(t => t.Years)
                    .ToSelectList(t => t.Years.ToString(), t => t.Name);

                return Page();
            }

            LoanApplication.Term = LoanTerm.GetLoanTerm(TermYears);

            LoanApplicationResult result = _loanProcessingService.ProcessLoan(LoanApplication);
            _resultRepository.SaveLoanApplicationResult(result);

            return RedirectToPage($"./LoanApplicationResult", new { id = result.ResultId });
        }

    }
}