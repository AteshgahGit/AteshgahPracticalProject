using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Aspects.PostSharp.PerformanceAspects
{
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private readonly int _interval;
        [NonSerialized]
        private Stopwatch _stopWatch;
        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopWatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopWatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopWatch.Stop();

            if (_stopWatch.Elapsed.TotalSeconds > _interval) 
                Debug.WriteLine($"Performance Terrible Result : {args.Method.DeclaringType.FullName}.{args.Method.DeclaringType.Name}.{args.Method.Name}() => Method Completed at : {_stopWatch.Elapsed.TotalSeconds} seconds /// it must be under of << {_interval} seconds >> ");

            _stopWatch.Reset();
            base.OnExit(args);
        }
    }
}
