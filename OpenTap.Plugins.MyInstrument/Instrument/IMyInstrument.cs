using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTap.Plugins.MyInstrument
{
    public interface IMyInstrument : IInstrument
    {
        void CommonAction();
        void CommonChildAction();
    }
}
