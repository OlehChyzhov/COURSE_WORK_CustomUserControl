using System;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
    public class RadioButtonGroupEventArgs : EventArgs
    {
        public RadioButton Button { get; set; }
    }

    public class CheckboxGroupEventArgs : EventArgs
    {
        public CheckBox CheckBox { get; set; }
    }
}
