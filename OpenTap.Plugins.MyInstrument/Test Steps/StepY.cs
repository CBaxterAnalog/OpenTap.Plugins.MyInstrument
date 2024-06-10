using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("YAction", Group: "My Instrument Test Steps", Description: "Do Y")]
    public class StepY : TestStepBase
    {
        public StepY()
        {
            _requiredImplementations = new List<Type> { typeof(IY) };
        }

        public override void Run()
        {
            RunChildSteps();

            (MyInstrument as IY).YAction();
        }
    }
}
