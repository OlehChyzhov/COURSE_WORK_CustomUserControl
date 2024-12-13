using System.Windows.Controls;

namespace CustomControlsLibrary
{
    public class RadioButtonGroupEventArgs : EventArgs
    {
        public required RadioButton Button { get; init; }
    }
}
