using System;
using System.Security.Cryptography;
using NUnit.Framework;
using XamarinCommunityToolkit.Validations;

namespace XamarinCommunityToolkitTests
{
    [TestFixture]
    public class ValidationRuleTests
    {
        public ValidatableObject<string> Email { get; set; }

        [SetUp]
        public void Init()
        {
            Email = new ValidatableObject<string>();
        }

        [Test]
        public void IsValidEmail()
        {
            string[] validEmails = { "david.jones@proseware.com",
                                    "j@proseware.com9",
                                    "js#internal@proseware.com",
                                    "jones@ms1.proseware.com",
                                    "j_9@[129.126.118.1]",
                                    "js@proseware.com9",
                                    "j.s@server1.proseware.com",
                                    "\"j\\\"s\\\"\"@proseware.com"};

            Email.Validations.Clear();
            Email.Validations.Add(new EmailRule<string>());

            foreach (string email in validEmails)
            {
                Email.Value = email;
                Email.Validate();

                if (!Email.IsValid)
                    break;
            }

            Assert.AreEqual(true, Email.IsValid);
        }

        [Test]
        public void IsInvalidEmail()
        {
            string[] invalidEmails = { "j.@server1.proseware.com",
                                    "j..s@proseware.com",
                                    "js@proseware..com",
                                    "js*@proseware.com", 
                                    "js@contoso.中国" };

            Email.Validations.Clear();
            Email.Validations.Add(new EmailRule<string>());

            foreach (string email in invalidEmails)
            {
                Email.Value = email;
                Email.Validate();

                if (Email.IsValid)
                    break;
            }

            Assert.AreEqual(false, Email.IsValid);
        }

        [TearDown]
        public void Dispose()
        {
            Email = null;
        }
    }
}
