namespace Credit.Services
{
    public class CreditDecisionApi : ICreditDecisionService
    {
        private CreditDecisionServer _creditDecisionServer;

        public CreditDecisionApi()
        {
            _creditDecisionServer = new CreditDecisionServer();
        }

        public string GetCreditDecision(int creditScore)
        {
            using (var serverConnection = _creditDecisionServer.Connect())
            {
                return serverConnection.GetCreditDecision(creditScore);
            }
        }
    }
}
