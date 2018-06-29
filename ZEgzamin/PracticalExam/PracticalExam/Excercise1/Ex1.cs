using System.Globalization;
using NUnit.Framework;

/*
 * Napisz testy, które przetestują każde wywołane metody IsPalindrome (dla longa, doubla i stringa)
 */

namespace PracticalExam
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void X()
        {
            // Arrange

            // Act
            //Ex1.IsPalindrome();

            // Assert

        }
        [Test]
        public void IsPalindromeDoubleTrue()
        {
            var result = Ex1.IsPalindrome(123.321);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void IsPalindromeDoubleFalse()
        {
            var result = Ex1.IsPalindrome(123.3321);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void IsPalindromelongTrue()
        {
            var result = Ex1.IsPalindrome(1234567887654321);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void IsPalindromelongFalse()
        {
            var result = Ex1.IsPalindrome(12345678876543212);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void IsPalindromeStringTrue()
        {
            var result = Ex1.IsPalindrome("mozeezom");
            Assert.AreEqual(true, result);
        }
        [Test]
        public void IsPalindromeStringFalse()
        {
            var result = Ex1.IsPalindrome("mozeezom2");
            Assert.AreEqual(false, result);
        }
    }

    public class Ex1
    {
        public static bool IsPalindrome(double a)
        {
            return IsPalindrome(a.ToString(CultureInfo.InvariantCulture));
        }

        public static bool IsPalindrome(long a)
        {
            return IsPalindrome(a.ToString());
        }

        public static bool IsPalindrome(string s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }


}
