using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using OpenTap;
using static System.Net.Mime.MediaTypeNames;

//Note this template assumes that you have a SCPI based instrument, and accordingly
//extends the ScpiInstrument base class.

//If you do NOT have a SCPI based instrument, you should modify this instance to extend
//the (less powerful) Instrument base class.

namespace OpenTap.Plugins.MyInstrument
{
    // TODO: Edit display settings
    [Browsable(false)]
    [Display("InstrumentTemplateBase", Group: "(Instrument Type)", Description: "Insert a description here")]
    public class MyInstrumentBase : ScpiInstrument, IMyInstrument
    {
        #region Settings
        // TODO: Add properties for which all instruments of this type should have
        #endregion
        public string Model;

        public MyInstrumentBase()
        {
            Name = "MyINST";

            // TODO: Set any default values for properties / settings.
        }

        /// <summary>
        /// Open procedure for the instrument.
        /// </summary>
        public override void Open()
        {

            base.Open();
            // TODO:  Open the connection to the instrument here
            Model = ScpiQuery("*IDN?\n").Split(',')[1];

            //if (!IdnString.Contains("Instrument ID"))
            //{
            //    Log.Error("This instrument driver does not support the connected instrument.");
            //    throw new ArgumentException("Wrong instrument type.");
            // }

        }

        /// <summary>
        /// Close procedure for the instrument.
        /// </summary>
        public override void Close()
        {
            // TODO:  Shut down the connection to the instrument here.
            base.Close();
        }

        // TODO: Implement base virtual functions
        public virtual void CommonAction()
        {
            throw new NotImplementedException();
        }

        public virtual void CommonChildAction()
        {
            throw new NotImplementedException();
        }

        public override void ScpiCommand(string command)
        {
            base.ScpiCommand(command);

            WaitForOperationComplete();
            List<ScpiError> errors = base.QueryErrors();

            if (errors.Count > 0)
            {
                String errorString = String.Join(",", errors.ToArray());
                throw new Exception($"Error: {errorString} while sending command: {command}");
            }
        }

        public override string ScpiQuery(string query, bool isSilent = false)
        {
            String strRet = base.ScpiQuery(query, isSilent);
            strRet = strRet.Replace("\n", "");
            return strRet;
        }
    }
}
