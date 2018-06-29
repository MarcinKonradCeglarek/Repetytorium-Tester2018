using System;

namespace PracticalExam.Excercise3
{
    public static class Ex3
    {
        /*
         * Napisz metodę, która odwraca stringa (ze stringa może -> eżom)
         */
        public static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}