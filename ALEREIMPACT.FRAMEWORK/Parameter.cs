using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.FRAMEWORK
{
    public class Parameters
    {
        private string _textName = string.Empty;

        public string TextName
        {
            get { return _textName; }
            set { _textName = value; }
        }
        private string _textValue = string.Empty;

        public string TextValue
        {
            get { return _textValue; }
            set { _textValue = value; }
        }

        public Parameters()
        {

        }

        public Parameters(string textName, string textValue)
        {
            this._textName = textName;
            this._textValue = textValue;
        }

        //public string TextName
        //{
        //    get
        //    {
        //        return _textName;
        //    }

        //}

        //public string TextValue
        //{
        //    get
        //    {
        //        return _textValue;
        //    }
        //}
    }
}
