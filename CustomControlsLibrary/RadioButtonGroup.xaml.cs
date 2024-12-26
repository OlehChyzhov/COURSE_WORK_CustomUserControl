using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
    [ToolboxBitmap(typeof(RadioButtonGroup), "CustomControlsLibrary.RadioButtonGroup.bmp")]
    [Designer(typeof(RadiobuttonGroupDesigner))]
    public partial class RadioButtonGroup : UserControl
    {
        public RadioButtonGroup()
        {
            InitializeComponent();
            this.DataContext = this;
            RadioButtons.CollectionChanged += SubscribeAllButtons;
        }

        [Category("Custom Events")]
        [Description("Executes when the radiobutton is selected.")]
        public event EventHandler<RadioButtonGroupEventArgs> RadioButtonChecked;

        #region Dependency Properties
        public static DependencyProperty TitleProperty = DependencyProperty.RegisterAttached(nameof(Title), typeof(string),
            typeof(RadioButtonGroup), new PropertyMetadata("RadioButton Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.RegisterAttached(nameof(TitleVisibility), typeof(Visibility),
            typeof(RadioButtonGroup), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached(nameof(Columns), typeof(int),
            typeof(RadioButtonGroup), new PropertyMetadata(1));
        #endregion

        #region Properties
        private RadioButton selectedRadiobutton;

        [Category("Custom Properties")]
        [Description("Index of the selected radiobutton.")]
        public int SelectedRadiobuttonIndex
        {
            get => RadioButtons.IndexOf(selectedRadiobutton);
        }

        [Category("Custom Properties")]
        [Description("Collection of radio buttons.")]
        public ObservableCollection<RadioButton> RadioButtons { get; } = new ObservableCollection<RadioButton>();

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
        // Викликає подію. Передає групу, яка викликала подію, і кнопку, яка була вибрана користувачем.
        private void OnRadioButtonChecked(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            selectedRadiobutton = button;

            RadioButtonChecked.Invoke(this, new RadioButtonGroupEventArgs() { Button = button });
        }

        // Коли користувач додає нову кнопку, то цей метод перезаписує метод Click усіх кнопок.
        private void SubscribeAllButtons(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (RadioButton button in RadioButtons)
            {
                button.GroupName = Title;
                UnsubscribeTo(button);
                SubscribeTo(button);
            }
        }

        private void SubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked += OnRadioButtonChecked;
        }
        private void UnsubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked -= OnRadioButtonChecked;
        }

        [Category("Custom Methods")]
        [Description("Adds a radio button to the group.")]
        public void Add(RadioButton button)
        {
            SubscribeTo(button);
            button.GroupName = Title;
            RadioButtons.Add(button);
        }

        [Category("Custom Methods")]
        [Description("Removes radio buttons matching a given filter.")]
        public void RemoveButtons(Func<RadioButton, bool> filter)
        {
            foreach (RadioButton button in RadioButtons.Where(filter))
            {
                UnsubscribeTo(button);
                RadioButtons.Remove(button);
            }
        }
        #endregion
    }
}
