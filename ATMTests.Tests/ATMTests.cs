using System;
using System.Collections.Generic;
using System.Text;
using ATMCode;
using Xunit;

namespace ATMTests.Tests
{
    public class ATMTests
    {
        [Fact]
        public static void ViewBalance_should_return_balance()
        {
            // No arrange, as the balance will come from the ATM file "ViewBalance" method.

            // Act
            decimal result = ATM.ViewBalance();

            // Assert
            Assert.Equal(10.00m, result);
        }

        [Fact]
        public static void Withdraw_should_return_requested_amount()
        {
            // Arrange
            decimal withdrawal = 7.50m;

            // Act
            decimal result = ATM.Withdraw(withdrawal);
            decimal currentBalance = ATM.ViewBalance();

            // Assert
            Assert.Equal(7.50m, result);
            Assert.Equal(2.50m, currentBalance);
        }
    }
}
