﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace Mercator.BenchmarkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MercatorVsSitecoreApi>();
            //var test = new MercatorVsSitecoreApi();
            //test.Setup();
            //test.Mercator();
            //test.Cleanup();
        }
    }
}
