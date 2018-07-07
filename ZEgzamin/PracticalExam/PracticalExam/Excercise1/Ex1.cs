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
        [TestCase (true, "1221", TestName = "Test 1 true")]
        [TestCase(true, "ala", TestName = "Test 2 true")]
        [TestCase(false, "", TestName = "Test 3 false")]
        [TestCase(false, "12344567234", TestName = "Test 4 false")]
        [TestCase(false, "11111112222222222333333333333555555555555555555", TestName = "Test 5 false")]
        public void X(bool expected, string data)
        {
            // Arrange
            var result = Ex1.IsPalindrome(data);
            // Act
            //Ex1.IsPalindrome();
            Assert.AreEqual(expected,result);
            // Assert
        }

        [TestCase(true, 1221, TestName = "Test 6 true")]
        [TestCase(false, 12344567234, TestName = "Test 7 false")]
        
        public void X(bool expected, long data)
        {
            // Arrange
            var result = Ex1.IsPalindrome(data);
            // Act
            //Ex1.IsPalindrome();
            Assert.AreEqual(expected, result);
            // Assert
        }

        [TestCase(true, 1221, TestName = "Test 8 true")]
        [TestCase(false, 12344567234, TestName = "Test 9 false")]
        
        public void X(bool expected, double data)
        {
            // Arrange
            var result = Ex1.IsPalindrome(data);
            // Act
            //Ex1.IsPalindrome();
            Assert.AreEqual(expected, result);
            // Assert
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
