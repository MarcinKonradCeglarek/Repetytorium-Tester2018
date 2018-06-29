using System;

namespace PracticalExam.Excercise3
{
    public static class Ex3
    {
        /*
         * Napisz metodę, która odwraca stringa (ze stringa może -> eżom)
         */
        public static string Reverse(string s)
        {
            string reverse = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                reverse += s[i];
            }

            return reverse;
        }
    }
}