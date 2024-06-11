// Author: MyName
// Copyright:   Copyright 2024 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using OpenTap;

namespace OpenTap.Plugins.MyInstrument
{
    [Browsable(false)]
    [AllowChildrenOfType(typeof(CommonChildStep))]
    public abstract class TestStepBase : TestStep
    {
        [Browsable(false)]
        public bool IsControlledByParent { get; set; } = false;

        protected List<Type> _requiredImplementations = new List<Type>();

        public IEnumerable<IMyInstrument> AvailableInstruments
        {
            get
            {
                List<IMyInstrument> instrumentsWithAction = new List<IMyInstrument>();
                foreach (var instrument in InstrumentSettings.Current)
                {
                    if (_requiredImplementations.All(item => instrument.GetType().GetInterfaces().Contains(item)))
                    {
                        instrumentsWithAction.Add(instrument as IMyInstrument);
                    }
                }
                return instrumentsWithAction;
            }
        }

        protected IMyInstrument _MyInstrument;
        [EnabledIf(nameof(IsControlledByParent), false, HideIfDisabled = false)]
        [Display("MyInstrument", Group: "Instrument Settings", Order: 1, Description: "Select the desired MyInstrument")]
        [AvailableValues("AvailableInstruments")]
        public IMyInstrument MyInstrument
        {
            get
            {
                return _MyInstrument;
            }
            set
            {
                _MyInstrument = value;

                foreach (var a in ChildTestSteps)
                {
                    if (a is CommonChildStep)
                    {
                        (a as CommonChildStep).MyInstrument = this.MyInstrument;
                    }
                }
            }
        }

        [Browsable(true)]
        [Display("Add Common Child", Group: "Instrument Settings", Order: 2, Description: "Adds a common child")]
        public void AddCommonChild()
        {
            CommonChildStep commonChildStep = new CommonChildStep() { MyInstrument = this.MyInstrument, IsControlledByParent = true };
            this.ChildTestSteps.Add(commonChildStep);
        }
    }
}
