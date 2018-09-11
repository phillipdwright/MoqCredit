namespace Credit.Services
{
    public class CreditDecisionServer
    {
        public RemoteCreditDecisionService Connect()
        {
            return new RemoteCreditDecisionService();
        }
    }
}
