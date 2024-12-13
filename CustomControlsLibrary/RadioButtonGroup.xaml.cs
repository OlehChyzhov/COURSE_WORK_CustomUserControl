using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
    [ToolboxBitmap(typeof(RadioButtonGroup), "Assets.RadioButtonGroup.bmp")] // Не змінює іконку
    public partial class RadioButtonGroup : UserControl
    {
        public RadioButtonGroup()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        // TODO: підписати всі кнопки до події.
        [Category("Custom Events")]
        [Description("Executes when the radiobutton is selected.")]
        public event EventHandler<RadioButtonGroupEventArgs>? RadioButtonSelected;

        #region Dependency Properties
        public static DependencyProperty TitleProperty = DependencyProperty.RegisterAttached(nameof(Title), typeof(string), 
            typeof(RadioButtonGroup), new PropertyMetadata("RadioButton Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.RegisterAttached(nameof(TitleVisibility), typeof(Visibility),
            typeof(RadioButtonGroup), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached(nameof(Columns), typeof(int),
            typeof(RadioButtonGroup), new PropertyMetadata(1));
        #endregion

        #region Properties
        [Category("Custom Properties")]
        [Description("Collection of radio buttons.")]
        public ObservableCollection<RadioButton> RadioButtons { get; } = new();

        [Category("Appearance")]
        [Description("Text displayed at the top of radiobutton group.")]
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        [Category("Appearance")]
        [Description("Visibility of the title.")]
        public Visibility TitleVisibility
        {
            get => (Visibility)GetValue(TitleVisibilityProperty);
            set => SetValue(TitleVisibilityProperty, value);
        }

        [Category("Layout")]
        [Description("Number of columns for all radiobuttons.")]
        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
        #endregion

        #region Methods
        private void OnRadioButtonChecked(object sender, EventArgs? e)
        {
            RadioButton button = (RadioButton)sender;
            RadioButtonSelected?.Invoke(this, new RadioButtonGroupEventArgs() { Button = button });
        }

        [Category("Custom Methods")]
        [Description("Adds a radio button to the group.")]
        public void Add(RadioButton button)
        {
            button.Checked += OnRadioButtonChecked;
            button.GroupName = Title;
            RadioButtons.Add(button);
        }

        [Category("Custom Methods")]
        [Description("Removes radio buttons matching a given filter.")]
        public void Remove(Func<RadioButton, bool> filter)
        {
            foreach (RadioButton button in RadioButtons.Where(filter))
            {
                RadioButtons.Remove(button);
            }
        }
        #endregion
    }
}
