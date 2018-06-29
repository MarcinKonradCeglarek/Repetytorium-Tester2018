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
        public void Test1()
        {
            var result = Ex1.IsPalindrome(20202);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test2()
        {
            var result = Ex1.IsPalindrome(2025);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test3()
        {
            var result = Ex1.IsPalindrome(0);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Test4()
        {
            var result = Ex1.IsPalindrome(45454545);
            Assert.AreEqual(false, result);
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

}
