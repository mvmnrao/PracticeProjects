﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    public class ValidationException: Exception
    {
        public ValidationException(string message): base(message)
        {
            
        }
    }
}
