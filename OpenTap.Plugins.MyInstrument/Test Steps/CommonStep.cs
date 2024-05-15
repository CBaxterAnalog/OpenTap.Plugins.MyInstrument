using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    
    [Display("Common Step", Group: "My Instrument Test Steps", Description: "Do common action")]

    public class CommonStep : TestStepBase
    {
        public CommonStep()
        {
            CommonChildStep commonChildStep = new CommonChildStep() { IsControlledByParent = true };

            ChildTestSteps.Add(commonChildStep);
        }
        
        public override void Run()
        {
            MyInstrument.CommonAction();
        }
    }
}
