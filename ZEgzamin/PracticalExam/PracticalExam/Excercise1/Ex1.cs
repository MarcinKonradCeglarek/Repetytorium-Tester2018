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
        public void xxx1()
        {


            var result = Ex1.IsPalindrome(31313);

            Assert.AreEqual(true, result);

        }

        [Test]
        public void xxx2()
        {


            var result = Ex1.IsPalindrome(9393);

            Assert.AreEqual(false, result);

        }



        [Test]

        public void xx3()

        {

            var result = Ex1.IsPalindrome(0);

            Assert.AreEqual(true, result);

        }

        [Test]

        public void xxx4()

        {

            var result = Ex1.IsPalindrome(22222222222222222);

            Assert.AreEqual(false, result);

            // Arrange

            // Act
            //Ex1.IsPalindrome();

            // Assert
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
