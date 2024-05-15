using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    public interface IX : IMyInstrument
    {
        void XAction();
    }
}
