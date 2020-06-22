using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DemoServerlessService
{
    public class DemoServerlessService:FunctionBase
    {

        public static DateTime my_time;

        Dictionary<String, String> returnList = new Dictionary<string, string>();


        public Dictionary<String, String> ServiceHandler(IDictionary<String, long> input, ILambdaContext context)
        {

            long nFib, mAck, nAck, nFact;

            returnList.Clear();

            try
            {
                /* convert  input values */
                nFib = input["nValueforFib"];
                mAck = input["mValueforAck"];
                nAck = input["nValueforAck"];
                nFact = input["nValueforFact"];
            }
            catch (Exception e)
            {
                returnList["Error"] = "Your json format is wrong. Please use correct key/value pairs";
                return returnList;
            }

            try
            {
                /*Run three functions in parallel. Each function has more than one algorithm to reach out the outcome.
                Fibonacci Functions has 3, Ackermann has 2 and Factorial has 3 algorithms. */


                Thread threadFib = new Thread(() => calcFibFunctions(nFib));
                threadFib.Start();

                Thread threadAck = new Thread(() => calcAckFunctions(mAck, nAck));
                threadAck.Start();

                Thread threadFact = new Thread(() => calcFactFunctions(nFact));
                threadFact.Start();

                threadAck.Join();
                threadFib.Join();
                threadFact.Join();


                return returnList;

            }

            catch (Exception e)
            {
                returnList["Exception"] = e.Message;
                 Log("EXCEPTION: " + e.ToString() + "   ");
                return returnList;
            }

        }

        /* This Fibonacci method sequentially runs three algoriths to reach out the outcome */
        private void calcFibFunctions(long nFib)
        {   
            Fibonacci fib = new Fibonacci(nFib);
           
           
             Log("FIBONACCI_INPUT_VALUE: " + nFib + "   ");
            my_time = DateTime.Now;
            long recValue = fib.Fibonacci_Recursive(nFib);
             Log("RECURSIVE_FIB_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");

            returnList["RecursiveFibResult"] = recValue.ToString();

            my_time = DateTime.Now;

            long IterativeValue = fib.Fibonacci_Iterative(nFib);
            Log("ITERATIVE_FIB_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
            returnList["IterativeFibResult"] = IterativeValue.ToString();

            my_time = DateTime.Now;

            long withMemoValue = fib.FibWithMemo(nFib);
            Log("WITHMEMO_FIB_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
            returnList["WithMemoFibResult"] = withMemoValue.ToString();

        }

        /* This Ackermann method sequentially runs two algoriths to reach out the outcome */
        private void calcAckFunctions(long mAck, long nAck)
        {
            Ackermann ack = new Ackermann();
            Log("ACK_INPUT_VALUES: (" + mAck + "," + nAck + ")   ");
            my_time = DateTime.Now;

            long ackRecursiveValue = ack.AckRecursive(mAck, nAck);
            Log("RECURSIVE_ACK_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
            returnList["RecursiveAckResult"] = ackRecursiveValue.ToString();

            my_time = DateTime.Now;

            long AckIterativeValue = ack.AckIterative(mAck, nAck);
            Log("ITERATIVE_ACK_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
            returnList["IterativeAckResult"] = AckIterativeValue.ToString();


        }

        /* This Factorial method sequentially runs three algoriths to reach out the outcome */
        private void calcFactFunctions(long nFact)
        {
            Factorial fact = new Factorial(nFact);

            if (nFact < 21)
            {
                 Log("FACTORIAL_INPUT_VALUE: " + nFact + "   ");
                my_time = DateTime.Now;

                long FactRecursiveValue = fact.FactRecursive(nFact);
                Log("RECURSIVE_FACT_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
                returnList["RecursiveFactResult"] = FactRecursiveValue.ToString();


                my_time = DateTime.Now;

                long FactIterativeValue = fact.FactIterative(nFact);
                Log("ITERATIVE_FACT_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
                returnList["IterativeFactResult"] = FactIterativeValue.ToString();

                my_time = DateTime.Now;

                long FactWithMemoValue = fact.FactWithMemo(nFact);
                Log("WITHMEMO_FACT_PROCESSING_TIME: " + (DateTime.Now - my_time).ToString() + "   ");
                returnList["WithMemoFactResult"] = FactWithMemoValue.ToString();
            }
            else
            {
                returnList["FactResult"] = "Max factorial input value must be 20 ";
            }
        }




     

    }
}
