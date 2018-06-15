using NUnit.Framework;
using PasswordValidator;
using System;

namespace EulerLibrary2.PasswordValidator
{
    [TestFixture]
    class PasswordValidatorTests
    {
        /*
         * 
         * A minimum 15 characters
         * At least 2 digits have to be present
         * At least 2 upper case characterws have to be present
         * At least one special character needs to be present
         * Can not have consecutive characters (same character twice, ie. x22xd)
         * 
         * */

        private IPasswordValidator validator = new ExternalPasswordValidator();

        [Test]
        public void IsABCInvalid()
        {
            var password = "ABCabcabc123#@!";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }

        [Test]
        public void IsPasswordValid_OneCharacterPassword_ThrowsTooShort()
        {
            var password = "A";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password is too short. It needs to be at least 15 characters long";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_OnlyOneDigit_ThrowsNeedsMinimumTwoDigits()
        {
            var password = "HiMyNameIsPiotr1";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Password require at least 2 digits, but got 1";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_NoSpecialChar_ThrowsNeedSpecialChar()
        {
            var password = "HiMyNameIsPiotr12";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Special characters are missing";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_NotEnoughUpperCase_ThrowsNeedMinimumTwoUpperCaseLetters()
        {
            var password = "#Himynameispiotr12";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "At least 2 upper case letters needs to be present";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid_ConsecutiveCharacters_ThrowsCannotHaveConsecutiveCharacters()
        {
            var password = "#HiMyNameIsPiotrr12";
            var exception = Assert.Throws<ApplicationException>(
                () => this.validator.IsPasswordValid(password));
            var expectedMessage = "Duplicated character: rr";
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void IsPasswordValid()
        {
            var password = "%ążźćńśęćńżśęóńó98";
            var isPasswordValid = this.validator.IsPasswordValid(password);
            Assert.IsTrue(isPasswordValid);
        }
    }
}
