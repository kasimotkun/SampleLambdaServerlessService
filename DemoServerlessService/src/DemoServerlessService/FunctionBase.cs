using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Core;

namespace DemoServerlessService
{
    public abstract class FunctionBase:ILogger
    {

      
      public void Log(string value) 
        {
             LambdaLogger.Log(value);
        }
    }
}