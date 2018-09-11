namespace Credit.Services
{
    public interface ICreditDecisionService
    {
        string GetCreditDecision(int creditScore);
    }
}
