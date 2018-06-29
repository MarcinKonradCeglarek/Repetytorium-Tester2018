using System;


namespace PracticalExam.Excercise3
{
    public static class Ex3
    {
        /*
         * Napisz metodę, która odwraca stringa (ze stringa może -> eżom)
         */
        
            public static string Reverse(string awd)


        {
            char[] charArray = awd.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);

        }
    }
}