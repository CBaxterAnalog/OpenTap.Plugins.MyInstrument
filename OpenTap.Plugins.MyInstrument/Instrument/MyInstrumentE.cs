using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using OpenTap;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("E", Group: "MyInstrument", Description: "Type E")]
    public class MyInstrumentE : MyInstrumentBase, IX, IY, IZ
    {
        #region Settings
        #endregion

        public MyInstrumentE()
        {
            Name = "E";
        }

        public override void Open()
        {
            base.Open();
        }

        public override void CommonAction()
        {
            Log.Info($"{Name} => Did some common action");
        }

        public override void CommonChildAction()
        {
            Log.Info($"{Name} => Did some common child action");
        }

        public void XAction()
        {
            Log.Info($"{Name} => Did x action");
        }

        public void YAction()
        {
            Log.Info($"{Name} => Did y action");
        }

        public void ZAction()
        {
            Log.Info($"{Name} => did z action");
        }

        public override void Close()
        {
            base.Close();
        }
    }
}