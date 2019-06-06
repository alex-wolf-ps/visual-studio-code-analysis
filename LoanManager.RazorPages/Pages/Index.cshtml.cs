using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanHelperDemo;
using LoanManager.Core.DataInterface;
using LoanManager.Core.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanManager.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment _env;

        private ILoanApplicationResultRepository _loanResultRepository;

        private ILoanRateRepository _loanRateRepository;

        public IndexModel(ILoanApplicationResultRepository loanResultRepository, ILoanRateRepository rateRepo, IHostingEnvironment environment)
        {
            _env = environment;
            _loanResultRepository = loanResultRepository;
            _loanRateRepository = rateRepo;
        }

        public List<LoanRate> LoanRates { get; set; }

        public List<DisplayRate> MarketRates { get; set; }

        public List<LoanApplicationResult> LoanApplicationResults { get; set; }


        public void OnGet()
        {
            LoanApplicationResults = _loanResultRepository.GetLoanApplicationResults().Take(5).ToList();
            LoanRates = _loanRateRepository.GetLoanRates();


            if (_env.IsDevelopment())
            {
                MarketRates = this.GetSampleMarketRates();
            }
            else
            {
                try
                {
                    MarketRates = LoanHelper.GetMarketRates();
                }
                catch (Exception e)
                {

                }
            }
        }

        private List<DisplayRate> GetSampleMarketRates()
        {
            return new List<DisplayRate>()
            {
                new DisplayRate()
                {
                    Label = "Auto",
                    Rate = .02
                },
                new DisplayRate()
                {
                    Label = "Home",
                    Rate = .04
                },
                new DisplayRate()
                {
                    Label = "Personal",
                    Rate = .05
                },
                new DisplayRate()
                {
                    Label = "Education",
                    Rate = .06
                }
            };
        }
    }
}
