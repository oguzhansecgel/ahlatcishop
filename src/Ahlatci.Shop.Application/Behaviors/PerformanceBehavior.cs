﻿using ArxOne.MrAdvice.Advice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Application.Behaviors
{
    internal class PerformanceBehavior : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            Stopwatch watch = new Stopwatch();
            //Kronometreyi başlat
            watch.Start();

            context.Proceed();

            //Kronometreyi durdur
            watch.Stop();

            var totalDuration = watch.Elapsed.TotalSeconds;

        }
    }
}
