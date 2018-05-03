using System;
using System.Net;

namespace HttpRequestTool
{
    class ComboboxItem
    {
        public string Text { get; set; }
        public SecurityProtocolType Value { get; set; }

        public ComboboxItem(String text, SecurityProtocolType value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

}
