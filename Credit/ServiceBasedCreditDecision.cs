using Credit.Services;

namespace Credit
{
    public class ServiceBasedCreditDecision
    {
        private ICreditDecisionService _creditDecisionService;

        public ServiceBasedCreditDecision(ICreditDecisionService creditDecisionService)
        {
            _creditDecisionService = creditDecisionService;
        }

        public string MakeCreditDecision(int creditScore)
        {
            return _creditDecisionService.GetCreditDecision(creditScore);
        }
    }
}
