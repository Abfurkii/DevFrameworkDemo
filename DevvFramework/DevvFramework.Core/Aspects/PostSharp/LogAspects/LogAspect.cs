using DevvFramework.Core.CrossCuttingConcerns.Logging;
using DevvFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _type;
        private LoggerService _loggerService;
        public LogAspect(Type type)
        {
            _type = type;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(LoggerService).IsAssignableFrom(_type))
            {
                throw new Exception("Wrong logger type!");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_type);
            base.RuntimeInitialize(method);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }
            try
            {
                var paramaters = args.Method.GetParameters().Select((t, i) => new LogParamater
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logDetails = new LogDetails
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Paramaters = paramaters
                };

                _loggerService.Info(logDetails);
            }
            catch (Exception)
            {
                throw new Exception("Loglamada bir şeyler ters gitti!");
            }
        }
    }
}
