using LoanManager.Core.DataInterface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoanManager.RazorPages.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanApplicationResultRepository repo;

        public LoanController(ILoanApplicationResultRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("loans")]
        public IActionResult Index(int start, int length = 2)
        {

            System.Collections.Generic.List<Core.Domain.LoanApplicationResult> loanResults = repo.GetLoanApplicationResults();
            int totalRecords = loanResults.Count;

            System.Collections.Generic.List<Core.Domain.LoanApplicationResult> filteredLoanResults = loanResults.Skip(start).Take(length).ToList();

            var response = new
            {
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,
                data = filteredLoanResults
            };

            return Ok(response);
        }

        [HttpGet("loans/{id}")]
        public IActionResult Index(int id)
        {
            Core.Domain.LoanApplicationResult loan = repo.GetLoan(id);
            return View(loan);
        }
    }
}
