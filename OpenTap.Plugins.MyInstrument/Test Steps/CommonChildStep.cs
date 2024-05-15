using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("Common Child Action", Group: "My Instrument Test Steps", Description: "Do common child action")]

    public class CommonChildStep : TestStepBase
    {

        public override void Run()
        {
            MyInstrument.CommonChildAction();
        }
    }
}
