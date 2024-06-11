using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{

    [Display("XYAction", Group: "My Instrument Test Steps", Description: "Do X and Y")]
    public class StepXY : TestStepBase
    {
        public StepXY()
        {
            _requiredImplementations = new List<Type> { typeof(IX), typeof(IY) };
        }

        public override void Run()
        {
            RunChildSteps();

            (MyInstrument as IX).XAction();
            (MyInstrument as IY).YAction();
        }
    }
}
