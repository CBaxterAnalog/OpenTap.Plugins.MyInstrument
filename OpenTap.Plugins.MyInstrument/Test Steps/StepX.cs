using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("XAction", Group: "My Instrument Test Steps", Description: "Do X")]
    public class StepX : TestStepBase
    {

        public StepX()
        {
            _requiredImplementations = new List<Type> { typeof(IX) };
        }

        public override void Run()
        {
            RunChildSteps();

            (MyInstrument as IX).XAction();
        }
    }
}
