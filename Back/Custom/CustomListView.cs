using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS.Back.Custom
{
    class CustomListView
    {

        public string Text { get; set; }

        public CustomListView(string title)
        {

            Text = title;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
