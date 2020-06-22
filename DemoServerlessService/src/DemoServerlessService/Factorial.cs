namespace DemoServerlessService
{
    public class Factorial
    {
        public static long[] my_factmemo;

        public Factorial(long nFact)
        {
             my_factmemo = new long[nFact + 1];
        }

    
        /* This Factorial method runs recursively to reach out the outcome. */
        public long FactRecursive(long n)
        {
            if (n == 0)
                return 1;

            return n * FactRecursive(n - 1);
        }

        /* This Factorial method runs iteratively (bottom to up) to reach out the outcome. */
        public long FactIterative(long n)
        {
            long val = 1, i;

            for (i = 2; i <= n; i++)
                val *= i;
            return val;
        }

        /* This Factorial method memorizes the old calculations (bottom to up) to reach out the outcome. */
        public long FactWithMemo(long n, bool with_memo = true)
        {
            if (with_memo)
            {
                if (my_factmemo[n] != 0) return my_factmemo[n];
            }

            if (n == 0) return 1;
            my_factmemo[n] = n * FactWithMemo(n - 1, with_memo);
            return my_factmemo[n];
        }

    }
}