namespace DemoServerlessService
{
    public class Fibonacci
    {
        public static long[] my_fibmemo;

        public Fibonacci(long nFib)
        {
           my_fibmemo= new long[nFib + 1];
        }

           /* This Fibonacci method runs recursively to reach out the outcome. */
        public  long Fibonacci_Recursive(long n)
        {


            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fibonacci_Recursive(n - 1) + Fibonacci_Recursive(n - 2);
            }
        }

        /* This Fibonacci method runs iteratively (bottom to up) to reach out the outcome. */
        public long Fibonacci_Iterative(long n)
        {
            long a = 0, b = 1, c = 0;
            for (long i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        /* This Fibonacci method memorizes the old calculations (bottom to up) to reach out the outcome. */
        public long FibWithMemo(long n, bool with_memo = true)
        {
            if (with_memo)
            {
                if (my_fibmemo[n] != 0) return my_fibmemo[n];
            }

            if (n == 0) return 0;
            if (n == 1) return 1;
            my_fibmemo[n] = FibWithMemo(n - 1, with_memo) + FibWithMemo(n - 2, with_memo);
            return my_fibmemo[n];
        }

    }
    
}