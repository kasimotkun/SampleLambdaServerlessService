using System;
using System.Collections.Generic;


namespace DemoServerlessService
{
    public class Ackermann
    {

        public Ackermann()
        {

        }

        public long AckRecursive(long m, long n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if ((m > 0) && (n == 0))
            {
                return AckRecursive(m - 1, 1);
            }
            else if ((m > 0) && (n > 0))
            {
                return AckRecursive(m - 1, AckRecursive(m, n - 1));
            }
            else
                return n + 1;
        }

        /* This Ackermann method runs iteratively ( push and pop) to reach out the outcome. */
        public long AckIterative(long m, long n)
        {
            Stack<long> s = new Stack<long>();
            s.Push(m);
            while (s.Count != 0)
            {
                m = s.Pop();
                if (m == 0) { n += m + 1; }
                else if (n == 0)
                {
                    n += 1;
                    s.Push(--m);
                }
                else
                {
                    s.Push(--m);
                    s.Push(++m);
                    n--;
                }
            }
            return n;
        }
    }
}