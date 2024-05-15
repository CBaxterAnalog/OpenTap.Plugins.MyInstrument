using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using OpenTap;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("B", Group: "MyInstrument", Description: "Type B")]
    public class MyInstrumentB : MyInstrumentBase, IY
    {
        #region Settings
        #endregion

        public MyInstrumentB()
        {
            Name = "B";
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

        public void YAction()
        {
            Log.Info($"{Name} => Did y action");
        }

        public override void Close()
        {
            base.Close();
        }
    }
}