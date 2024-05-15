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

            AvailableInstruments.Clear();
            foreach (var instrument in InstrumentSettings.Current)
            {
                if (_requiredImplementations.All(item => instrument.GetType().GetInterfaces().Contains(item)))
                {
                    AvailableInstruments.Add(instrument as IMyInstrument);
                }
            }
        }

        public override void Run()
        {
            (MyInstrument as IY).YAction();
        }
    }
}
