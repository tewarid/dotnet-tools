using System;

namespace Common
{
    public class ComboboxItem<T>
    {
        public string Text { get; set; }
        public T Value { get; set; }

        public ComboboxItem(String text, T value)
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
