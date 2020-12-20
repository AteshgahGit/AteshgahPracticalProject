using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net;
using AteshgahPracticalProject.Core.Utilities.Files;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private readonly Type _loggerType;
        [NonSerialized]
        private LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService)) throw new Exception("Wrong Logger Type Injected!");

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);

            //FileManagerHelper.CreateDirectoryIfNotExists("C:/Logs/AteshgahPracticalProject");

            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled) return;

            try
            {
                var logParameters = args.Method.GetParameters().Select((type, iterator) => new LogParameter
                {
                    Name = type.Name,
                    Type = type.ParameterType.Name,
                    Value = args.Arguments.GetArgument(iterator)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }
        }
    }
}
