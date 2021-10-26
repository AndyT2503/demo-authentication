using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DI
{
    public class MockService : IAPIService
    {
        public object GetInfo()
        {
            Console.WriteLine("Mock Service connected");
            return new
            {
                name = "test",
                code = "test"
            };
        }
    }
}
