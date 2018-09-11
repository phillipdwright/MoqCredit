using Credit;
using Credit.Services;

using Moq;
using NUnit.Framework;

using System;

namespace CreditTests
{
    [TestFixture]
    public class ServiceBasedCreditDecisionTestsWithMock
    {
        Mock<ICreditDecisionService> _mockCreditDecisionService;

        ServiceBasedCreditDecision _systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            _mockCreditDecisionService = new Mock<ICreditDecisionService>();
            _systemUnderTest = new ServiceBasedCreditDecision(_mockCreditDecisionService.Object);
        }

        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]
        public void MakeCreditDecision_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            _mockCreditDecisionService.Setup(p => p.GetCreditDecision(creditScore))
                .Returns(expectedResult);

            var result = _systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(100)]
        [TestCase(549)]
        public void MakeCreditDecision_GivenScoreUnder550_ReturnsDeclined(int creditScore)
        {
            _mockCreditDecisionService.Setup(
                p => p.GetCreditDecision(
                    It.Is<int>(
                        score => score < 550)))
                .Returns("Declined");

            var result = _systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo("Declined"));
        }

        [Test]
        public void MakeCreditDecision_GivenNegativeScore_ThrowsException()
        {
            _mockCreditDecisionService.Setup(p => p.GetCreditDecision(It.Is<int>(score => score < 0)))
                .Throws<Exception>();

            var negativeScore = -1;

            Assert.Throws<Exception>(
                () => _systemUnderTest.MakeCreditDecision(negativeScore));
        }

        [Test]
        public void MakeCreditDecision_CallsCreditDecisionService()
        {
            _mockCreditDecisionService.Setup(p => p.GetCreditDecision(It.IsAny<int>())).Returns("");
            var creditScore = 100;

            var result = _systemUnderTest.MakeCreditDecision(creditScore);

            _mockCreditDecisionService.Verify(
                cds => cds.GetCreditDecision(creditScore),
                Times.Once());
        }
    }
}
