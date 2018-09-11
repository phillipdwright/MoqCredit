namespace Credit
{
    public class CreditDecision
    {
        public string MakeCreditDecision(int creditScore)
        {
            if (creditScore < 550)
            {
                return "Declined";
            }

            if (creditScore < 675)
            {
                return "Maybe";
            }

            return "We look forward to doing business with you!";
        }
    }
}
