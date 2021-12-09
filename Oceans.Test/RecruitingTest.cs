using FluentAssertions;
using Oceans.Exercise;
using System;
using System.Collections.Generic;
using Xunit;

namespace Oceans.Test
{
    public class RecruitingTest
    {
        [Fact]
        public void SubscriptionsExpiredLastMonth()
        {
            var date = DateTime.Now.AddMonths(-1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            Assert.True(user.ExpiredSubscriptions == 2, $"Expected expired subscriptions: 2 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void SubscriptionsExpiringNextMonth()
        {
            var date = DateTime.Now.AddMonths(1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            Assert.True(user.ExpiredSubscriptions == 0, $"Expected expired subscriptions: 0 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void SubscriptionsExpiredLastYear()
        {
            var date = DateTime.Now.AddYears(-1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            Assert.True(user.ExpiredSubscriptions == 2, $"Expected expired subscriptions: 2 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void SubscriptionsExpiredLastYearPreviousMonth()
        {
            var date = DateTime.Now.AddYears(-1).AddMonths(-1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            Assert.True(user.ExpiredSubscriptions == 2, $"Expected expired subscriptions: 2 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void SubscriptionsExpiringNextYearNextMonth()
        {
            var date = DateTime.Now.AddYears(1).AddMonths(1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            Assert.True(user.ExpiredSubscriptions == 0, $"Expected expired subscriptions: 0 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void SubscriptionsExpiredLastMonth_UsingFluentAssertions()
        {
            var date = DateTime.Now.AddMonths(-1);

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            user.ExpiredSubscriptions.Should().Be(2, because: $"Expected expired subscriptions: 2 - Your code returns: {user.ExpiredSubscriptions}");
        }

        [Fact]
        public void UserInformationUpdates()
        {
            var date = DateTime.Now;

            var subscriptions = new List<Subscription>
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };

            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            user.UpdateUserName();

            Assert.True(user.Name == "Oceans Code Experts", "User name updated successfully");

            user.UpdateUserInformation();

            Assert.True(user.Name == "Recruiting Oceans Code Experts", "User name updated successfully after tuple management");
        }
    }
}