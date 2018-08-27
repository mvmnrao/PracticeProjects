using System;
using System.Collections.Generic;
using System.Text;

namespace ImgToTextLambda
{
    /// <summary>
    /// The state passed between the step function executions.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Input value when starting the execution
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The message built through the step function execution.
        /// </summary>
        public string Key { get; set; }

        public int CaseId { get; set; }

        ///// <summary>
        ///// The number of seconds to wait between calling the Salutations task and TransformToText task.
        ///// </summary>
        //public int WaitInSeconds { get; set; } 
    }
}
