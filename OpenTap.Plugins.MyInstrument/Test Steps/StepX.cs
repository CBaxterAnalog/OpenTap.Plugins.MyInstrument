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
            (MyInstrument as IX).XAction();
        }
    }
}
