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
        private List<IMyInstrument> _availableInstruments = new List<IMyInstrument>();
        [Browsable(false)]
        public List<IMyInstrument> AvailableInstruments
        {
            get
            {
                return _availableInstruments;
            }
            set
            {
                _availableInstruments = value;
                OnPropertyChanged(nameof(AvailableInstruments));
            }
        }

        private IMyInstrument _myInstrument;
        [EnabledIf(nameof(IsControlledByParent), false, HideIfDisabled = false)]
        [Display("MyInstrument", Group: "Instrument Settings", Order: 1, Description: "Select the desired MyInstrument")]
        [AvailableValues(nameof(AvailableInstruments))]
        public IMyInstrument MyInstrument
        {
            get { return _myInstrument; }
            set
            {
                _myInstrument = value;
                foreach (var childStep in ChildTestSteps)
                {
                    switch (childStep)
                    {
                        case CommonChildStep s:
                            s.MyInstrument = _myInstrument;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void OnInstrumentListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in e.NewItems)
                    {
                        if (_requiredImplementations.All(item => newItem.GetType().GetInterfaces().Contains(item)))
                        {
                            _availableInstruments.Add(newItem as IMyInstrument);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        _ = _availableInstruments.Remove(oldItem as IMyInstrument);
                    }
                    break;
                default:
                    break;
            }
        }

        public TestStepBase()
        {
            InstrumentSettings.Current.CollectionChanged += OnInstrumentListChanged;
        }
    }
}
