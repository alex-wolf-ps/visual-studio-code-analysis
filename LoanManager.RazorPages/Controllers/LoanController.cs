using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace LoanManager.RazorPages.Controllers
{
    public class LoanController : Controller
    {
        private ILoanApplicationResultRepository repo;

        public LoanController(ILoanApplicationResultRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("loans")]
        public IActionResult Index(int start, int length = 2)
        {

            var loanResults = this.repo.GetLoanApplicationResults();
            var totalRecords = loanResults.Count;

            var filteredLoanResults = loanResults.Skip(start).Take(length).ToList();

            var response = new {
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords, data = filteredLoanResults
            };

            return Ok(response);
        }

        [HttpGet("loans/{id}")]
        public IActionResult Index(int id)
        {
            var loan = this.repo.GetLoan(id);
            return View(loan);
        }
    }
}
