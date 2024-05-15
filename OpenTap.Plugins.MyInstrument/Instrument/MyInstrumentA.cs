using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using OpenTap;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("A", Group: "MyInstrument", Description: "Type A")]
    public class MyInstrumentA : MyInstrumentBase, IX
    {
        #region Settings
        #endregion

        public MyInstrumentA()
        {
            Name = "A";
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

        public override void Close()
        {
            base.Close();
        }
    }
}
