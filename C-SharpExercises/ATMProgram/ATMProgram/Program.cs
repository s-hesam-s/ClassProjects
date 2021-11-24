using System;

namespace ATMProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Services services = new Services();

            var banks = services.AddBank();
            services.AtmOperations(banks, banks);
        }
    }
}
