using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspfromscratch
{
    public class RandomNumberService
    {
        private Random rng;
        public RandomNumberService()
        {
            rng = new Random();
        }

        public int GetNext()
        {
            return rng.Next();
        }
    }
}
