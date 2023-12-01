using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.Back.Custom
{
    public class CustomPickerItem
    {
        public string DisplayText { get; set; }
        public string Value { get; set; }

        public CustomPickerItem(string displayText, string value) {

            DisplayText = displayText;
            Value = value;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
