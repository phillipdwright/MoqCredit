using Credit;
using Credit.Services;

using NUnit.Framework;

namespace CreditTests
{
    [TestFixture]
    public class ServiceBasedCreditDecisionTests
    {
        CreditDecisionApi _creditDecisionService;

        ServiceBasedCreditDecision _systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            _creditDecisionService = new CreditDecisionApi();
            _systemUnderTest = new ServiceBasedCreditDecision(_creditDecisionService);
        }

        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]
        public void MakeCreditDecision_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            var result = _systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
