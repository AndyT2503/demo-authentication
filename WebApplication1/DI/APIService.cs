using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DI
{
    public class APIService : IAPIService
    {
        public object GetInfo()
        {
            Console.WriteLine("API connected");
            return new
            {
                name = "test",
                code = "test"
            };
        }
    }
}
