using System;
using System.Collections.Generic;
using System.Linq;

namespace Oceans.Exercise
{
    public class User
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user's chosen payment type
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// The user's subscriptions
        /// </summary>
        internal IEnumerable<Subscription> Subscriptions { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="subscriptions">The subscriptions the user has.</param>
        public User(IEnumerable<Subscription> subscriptions)
        {
            this.Subscriptions = subscriptions;
        }

        /// <summary>
        /// The number of expired subscriptions the user has
        /// </summary>
        public int ExpiredSubscriptions
        {
            get
            {
                //Use LINQ to get the right number
                return Subscriptions.Count(x => FilterByExpiratedSuscription(x));
            }
        }

        /// <summary>
        /// Rewrite this method using discard for output variable (Done)
        /// </summary>
        public void UpdateUserName()
        {
            const string strForExercise = "1";

            if (int.TryParse(strForExercise, out _))
            {
                Name = "Oceans Code Experts";
            }
        }

        /// <summary>
        /// Rewrite this method to return a tuple of Name, PaymentType and the local variable (Done)
        /// </summary>
        public Tuple<string, PaymentType, bool> UserInformation()
        {
            const bool codeExperts = true;
            return new Tuple<string, PaymentType, bool>(this.Name, this.PaymentType, codeExperts);
        }

        /// <summary>
        /// Update the local variables by deconstructing the tuple from UserInformation
        /// Follow the sugested logic to update the User Name
        /// </summary>
        public void UpdateUserInformation()
        {
            //deconstructing the tuple
            var (nameFromTuple, _, codeExpertsFromTuple) = UserInformation();

            if (codeExpertsFromTuple)
            {
                Name = $"Recruiting {nameFromTuple}";
            }
        }

        private bool FilterByExpiratedSuscription(Subscription suscription)
        {
            var currentYear = DateTime.Now.Year;

            // checking year of expiration date if it is greater than current year
            if (suscription.ExpirationYear < currentYear)
                return true;

            // checking month (if year is the same, check month too) otherwise return false
            if (suscription.ExpirationYear == currentYear && suscription.ExpirationMonth < DateTime.Now.Month)
                return true;

            return false;
        }
    }
}