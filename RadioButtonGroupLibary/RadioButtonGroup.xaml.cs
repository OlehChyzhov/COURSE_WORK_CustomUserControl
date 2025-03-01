using RadioButtonGroupLibary.Interfaces;
using RadioButtonGroupLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace RadioButtonGroupLibary
{
    [ToolboxBitmap(typeof(RadioButtonGroup), "RadioButtonGroupLibary.RadioButtonGroup.bmp")]
    public partial class RadioButtonGroup : UserControl, IRadiobuttonGroup
    {
        private Guid _groupId;
        public RadioButtonGroup()
        {
            InitializeComponent();
            DataContext = this;
            _groupId = Guid.NewGuid();
        }

        [Category("Custom Events")]
        [Description("Executes when the radiobutton is selected.")]
        public event EventHandler<RadioButtonGroupEventArgs> RadioButtonSelected;

        #region Dependency Properties
        public static DependencyProperty RadioButtonNamesProperty = DependencyProperty.Register(nameof(RadioButtonNames), typeof(string),
            typeof(RadioButtonGroup), new PropertyMetadata("", RadioButtonNamesPropertyChanged));

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

        #region Properties
        [Category("Custom Properties")]
        [Description("Collection of radio buttons.")]
        public ObservableCollection<RadioButton> RadioButtons { get; set; } = new ObservableCollection<RadioButton>();

        [Category("The Most Popular")]
        [Description("Names of the Radiobuttons.")]
        public string RadioButtonNames
        {
            get => (string)GetValue(RadioButtonNamesProperty);
            set => SetValue(RadioButtonNamesProperty, value);
        }
        public Dictionary<string, string> AdditionalInformation { get; } = new Dictionary<string, string>();

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
        [Description("Visibility of the title.")]
        public Visibility TitleVisibility
        {
            get => (Visibility)GetValue(TitleVisibilityProperty);
            set => SetValue(TitleVisibilityProperty, value);
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
        #endregion

        #region Public Methods
        [Category("Custom Methods")]
        [Description("Creates a radio button.")]
        public RadioButton CreateButton(string content)
        {
            RadioButton button = new RadioButton()
            {
                Content = content,
                GroupName = $"{_groupId}",
            };
            button.Checked += RadioButtonCheckedResponce;
            button.MouseEnter += RadioButton_MouseEnter;
            button.MouseLeave += RadioButton_MouseLeave;

            return button;
        }

        [Category("Custom Methods")]
        [Description("Adds a radio button to the group.")]
        public void DisplayButton(RadioButton button)
        {
            RadioButtons.Add(button);
        }

        [Category("Custom Methods")]
        [Description("Removes first radio button from the group based on the content.")]
        public void RemoveByContent(string buttonContent)
        {
            RadioButton button = RadioButtons.FirstOrDefault(btn => btn.Content.ToString() == buttonContent);
            if (button != null)
            {
                button.Checked -= RadioButtonCheckedResponce;
                button.MouseEnter -= RadioButton_MouseEnter;
                button.MouseLeave -= RadioButton_MouseLeave;
                RadioButtons.Remove(button);
            }
        }
        #endregion

        #region Callbacks
        private static void RadioButtonNamesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadioButtonGroup group = (RadioButtonGroup)d;

            string oldButtonString = e.OldValue.ToString();
            string newButtonString = e.NewValue.ToString();

            foreach (string btnContent in oldButtonString.Split(','))
            {
                group.RemoveByContent(btnContent);
            }

            foreach (string btnContent in newButtonString.Split(','))
            {
                RadioButton button = group.CreateButton(btnContent);
                group.DisplayButton(button);
            }
        }

        private void RadioButtonCheckedResponce(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            RadioButtonSelected?.Invoke(this, new RadioButtonGroupEventArgs() { Button = button });
        }
        #endregion

        #region Adorners
        private void RadioButton_MouseEnter(object sender, MouseEventArgs e)
        {
            string key = ((RadioButton)sender).Content.ToString();
            if (AdditionalInformation.ContainsKey(key) == false) return;

            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
            layer.Add(new AdditionalInformationAdorner(this, AdditionalInformation[key]));
        }
        private void RadioButton_MouseLeave(object sender, MouseEventArgs e)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);

            if (layer.GetAdorners(this) != null)
            {
                List<Adorner> adorners = layer.GetAdorners(this).ToList();
                foreach (Adorner adorner in adorners)
                {
                    layer.Remove(adorner);
                }
            }
        }
        #endregion
    }
}
