namespace GrzegorzKozub.LogitechK290FnKeySwap
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static string[] resetArguments = new string[] { "/reset", "/r" };

        internal static void Main(string[] arguments)
        {
            try
            {
                ValidateArguments(arguments);

                if (ResetRequested(arguments))
                {
                    KeyboardService.ResetFnKey();
                }
                else
                {
                    KeyboardService.SwapFnKey();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Environment.Exit(1);
            }
        }

        private static void ValidateArguments(string[] arguments)
        {
            if (arguments.Any(argument => resetArguments.Contains(argument) == false))
            {
                throw new ApplicationException("Supply the /reset or /r argument to put the Fn key to its default behavior.");
            }
        }

        private static bool ResetRequested(string[] arguments)
        {
            return arguments.Any(argument => resetArguments.Contains(argument));
        }
    }
}
