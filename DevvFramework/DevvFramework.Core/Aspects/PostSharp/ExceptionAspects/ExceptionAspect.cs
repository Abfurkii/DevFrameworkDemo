using DevvFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.Aspects.PostSharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private Type _loggerType;

        public ExceptionAspect(Type loggerService=null)
        {
            _loggerType = loggerService;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType!=null)
            {
                if (typeof(LoggerService).IsAssignableFrom(_loggerType))
                {
                    throw new Exception("Wrong logger type!");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
        }
        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService!=null)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
