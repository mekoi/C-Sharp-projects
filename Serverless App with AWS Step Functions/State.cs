using System;
using System.Collections.Generic;
using System.Text;

namespace IrisiMekoLab4
{
    //The state passed between the step function executions.
    public class State
    {
        public string bucketName { get; set; }

        public string key { get; set; }

        public float MinConfidence { get; set; } = 90f;
    }
}
