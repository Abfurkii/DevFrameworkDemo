﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevvFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogDetails
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParamater> Paramaters { get; set; }
    }
}
