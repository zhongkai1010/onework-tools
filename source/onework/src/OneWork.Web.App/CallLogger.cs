using System;
using System.Linq;
using Castle.DynamicProxy;

namespace OneWork.Web.App
{
    public class CallLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            if (invocation.Arguments.Length > 0)
            {
                object value1 = invocation.Arguments[0];


                if (typeof(WeatherForecast) == value1.GetType())
                    if (value1 is WeatherForecast weatherForecast)
                        weatherForecast.Summary = "Intercept";
            }


            invocation.Proceed();

            Console.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}