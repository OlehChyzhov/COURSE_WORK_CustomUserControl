using CustomControlsLibrary.RunTimeAdorners;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CustomControlsLibrary
{
    [System.Drawing.ToolboxBitmap(typeof(RadioButtonGroup), "CustomControlsLibrary.RadioButtonGroup.bmp")]
    public partial class RadioButtonGroup : UserControl
    {
        private Guid _groupId;
        public RadioButtonGroup()
        {
            InitializeComponent();
            _groupId = Guid.NewGuid();
            this.DataContext = this;
            RadioButtons.CollectionChanged += SubscribeAllButtons;
        }
        // Не впевнений, чи деструктор потрібен, але оскільки збирач сміття не може позбутись підписаних методів,
        // то вирішив написати.
        ~RadioButtonGroup()
        {
            foreach (RadioButton button in RadioButtons)
            {
                UnsubscribeTo(button);
            }
            RadioButtons.CollectionChanged -= SubscribeAllButtons;
        }

        #region Events
        [Category("Custom Events")]
        [Description("Executes when the radiobutton is selected.")]
        public event EventHandler<RadioButtonGroupEventArgs> RadioButtonChecked;
        #endregion

        #region Dependency Properties
        public static DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(int),
            typeof(RadioButtonGroup), new PropertyMetadata(1));

        public static DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string),
            typeof(RadioButtonGroup), new PropertyMetadata("RadioButton Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.Register(nameof(TitleVisibility), typeof(Visibility),
            typeof(RadioButtonGroup), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty TitleHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TitleHorizontalAlignment), typeof(HorizontalAlignment),
            typeof(RadioButtonGroup), new PropertyMetadata(HorizontalAlignment.Left));        
        
        public static DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight),
            typeof(RadioButtonGroup), new PropertyMetadata(FontWeights.Normal));
        #endregion

        #region Often Used Properties
        [Category("The Most Popular")]
        [Description("Number of columns for all radiobuttons.")]
        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        [Category("The Most Popular")]
        [Description("Text displayed at the top of radiobutton group.")]
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        [Category("The Most Popular")]
        [Description("Alignment of the title.")]
        public HorizontalAlignment TitleHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty);
            set => SetValue(TitleHorizontalAlignmentProperty, value);
        }
        [Category("The Most Popular")]
        [Description("Title font weight.")]
        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set => SetValue(TitleFontWeightProperty, value);
        }

        [Category("The Most Popular")]
        [Description("Visibility of the title.")]
        public Visibility TitleVisibility
        {
            get => (Visibility)GetValue(TitleVisibilityProperty);
            set => SetValue(TitleVisibilityProperty, value);
        }
        #endregion

        #region Custom Properties
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
        #endregion

        #region Important Methods
        // Коли користувач додає нову кнопку, то цей метод перезаписує метод Click усіх кнопок.
        private void SubscribeAllButtons(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (RadioButton button in e.OldItems)
                {
                    UnsubscribeTo(button);
                }
            }

            if (e.NewItems != null)
            {
                foreach (RadioButton button in e.NewItems)
                {
                    UpdateGroupName(button);
                    SubscribeTo(button);
                }
            }
        }

        // Викликає подію. Передає групу, яка викликала подію, і кнопку, яка була вибрана користувачем.
        private void RadioButtonCheckedResponce(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            selectedRadiobutton = button;

            RadioButtonChecked?.Invoke(this, new RadioButtonGroupEventArgs() { Button = button });
        }
        #endregion

        #region Private Methods

        private void SubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked += RadioButtonCheckedResponce;
        }

        private void UnsubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked -= RadioButtonCheckedResponce;
        }

        private void UpdateGroupName(RadioButton btn)
        {
            btn.GroupName = $"{_groupId}";
        }
        #endregion

        #region Public Methods
        [Category("Custom Methods")]
        [Description("Adds a radio button to the group.")]
        public void Add(RadioButton button)
        {
            SubscribeTo(button);
            UpdateGroupName(button);
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

        private void AttachAdorners(object sender, RoutedEventArgs e)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
            layer.Add(new HoverButtonsAdorner(this));
        }
    }
}
