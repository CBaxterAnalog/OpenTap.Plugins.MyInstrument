using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using OpenTap;

namespace OpenTap.Plugins.MyInstrument
{
    [Display("C", Group: "MyInstrument", Description: "Type C")]
    public class MyInstrumentC : MyInstrumentBase, IZ 
    {
        #region Settings
        #endregion

        public MyInstrumentC()
        {
            Name = "C";
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

        public void ZAction()
        {
            Log.Info($"{Name} => Did z action");
        }

        public override void Close()
        {
            base.Close();
        }
    }
}