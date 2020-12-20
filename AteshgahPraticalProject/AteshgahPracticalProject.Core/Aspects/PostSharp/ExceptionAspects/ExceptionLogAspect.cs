﻿using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net;
using AteshgahPracticalProject.Core.Utilities.Files;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Aspects.PostSharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public ExceptionLogAspect(Type loggerType = null)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType != null)
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                {
                    throw new Exception("Wrong Logger Type Settled");
                }

                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }

            //FileManagerHelper.CreateDirectoryIfNotExists("C:/Logs/AteshgahPracticalProject");

            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService != null)
            {
                _loggerService.Error(args.Exception);
            }
        }

    }
}
