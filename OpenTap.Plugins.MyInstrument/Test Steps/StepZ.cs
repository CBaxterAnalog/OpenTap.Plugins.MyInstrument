using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("ZAction", Group: "My Instrument Test Steps", Description: "Do Z")]
    public class StepZ : TestStepBase
    {
        public StepZ()
        {
            _requiredImplementations = new List<Type> { typeof(IZ) };
        }

        public override void Run()
        {
            RunChildSteps();

            (MyInstrument as IZ).ZAction();
        }
    }
}
