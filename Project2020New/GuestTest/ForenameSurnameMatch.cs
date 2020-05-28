using System;
using NUnit.Framework;
using Project2020.Models;
using Project2020.Utilities;
using Project2020.ViewModels;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class AddGuestTests
        {
            [TestCase]
            public void When_GuestAdded_expect_ForenameEqualSurName()
            {
                Guest newguest = new Guest
                {
                    Forename = "test",
                    Surname = "nottest",

                };

                Assert.AreNotEqual(newguest.Forename, newguest.Surname);

            }
        }
    }
}