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
            (MyInstrument as IZ).ZAction();
        }
    }
}
