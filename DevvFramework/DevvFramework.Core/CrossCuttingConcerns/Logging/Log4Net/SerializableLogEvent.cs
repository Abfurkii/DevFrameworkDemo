using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    /// <summary>
    /// Biz bu işlemi, json formatında log alabilmek için yazdık.
    /// </summary>
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName => _loggingEvent.UserName;
        public object ObjectMassage => _loggingEvent.MessageObject;
    }
}
