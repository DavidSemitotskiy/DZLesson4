using System;

namespace DZLesson4
{
    public enum Alphabet
    {
        A = 1,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Неправельный размер!!");
                Console.Write("Повторите ввод: ");
            }

            Random rand = new Random();
            int[] arr = new int[size];
            int countEven = 0, countOdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 27);
                if (arr[i] % 2 == 0)
                {
                    countEven++;
                    continue;
                }

                countOdd++;
            }

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            char[] charEvenNumber = new char[countEven],
                charOddNumber = new char[countOdd];
            for (int i = 0, j = 0, n = 0; i < arr.Length; i++)
            {
                if (Enum.IsDefined(typeof(Alphabet), arr[i]))
                {
                    char addedChar = ((Alphabet)arr[i]).ToString()[0];
                    addedChar = addedChar == 'A' || addedChar == 'E' || addedChar == 'I' || addedChar == 'D'
                        || addedChar == 'H' || addedChar == 'J' ? addedChar : char.ToLower(addedChar);
                    if (arr[i] % 2 == 0)
                    {
                        charEvenNumber[j] = addedChar;
                        j++;
                        continue;
                    }

                    charOddNumber[n] = addedChar;
                    n++;
                }
            }

            (int countUpperCaseEven, int countUpperCaseOdd) tupleCounts = (0, 0);
            for (int i = 0; i < charEvenNumber.Length; i++)
            {
                Console.Write($"{charEvenNumber[i]} ");
                if (charEvenNumber[i] == char.ToUpper(charEvenNumber[i]))
                {
                    tupleCounts.countUpperCaseEven++;
                }
            }

            Console.WriteLine();
            for (int i = 0; i < charOddNumber.Length; i++)
            {
                Console.Write($"{charOddNumber[i]} ");
                if (charOddNumber[i] == char.ToUpper(charOddNumber[i]))
                {
                    tupleCounts.countUpperCaseOdd++;
                }
            }

            Console.WriteLine();
            Console.WriteLine(tupleCounts.countUpperCaseEven > tupleCounts.countUpperCaseOdd ? "В первом массиве больше" :
                tupleCounts.countUpperCaseEven == tupleCounts.countUpperCaseOdd ? "Количесво равно" : "Во втором больше");
        }
    }
}
