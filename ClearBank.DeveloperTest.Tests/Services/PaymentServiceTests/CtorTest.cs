using ClearBank.DeveloperTest.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClearBank.DeveloperTest.Tests.Services.PaymentServiceTests
{
    [TestClass]
    public class CtorTest : TestBase
    {
        [TestMethod]
        public void ShouldThrowArgumentNullException_WhenAccountServiceIsNull()
        {
            // Act
            Action act = () => new PaymentService(null);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithParameterName("accountService");
        }
    }
}
