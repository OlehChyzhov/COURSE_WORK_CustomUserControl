using CustomUserControl.Chapter5;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace CustomUserControl.Chapter6
{
    public partial class RBtnGroupChapter6 : UserControl
    {
        private Guid _groupId;
        public RBtnGroupChapter6()
        {
            InitializeComponent();
            DataContext = this;
            _groupId = Guid.NewGuid();
            RadioButtons.CollectionChanged += RadioButtonsChanged;
        }
        [Category("Custom Events")]
        [Description("Executes when the radiobutton is selected.")]
        public event EventHandler<RadioButtonGroupEventArgs> RadioButtonSelected;

        #region Dependency Properties
        public static DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(int),
            typeof(RBtnGroupChapter6), new PropertyMetadata(1));

        public static DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string),
            typeof(RBtnGroupChapter6), new PropertyMetadata("RadioButton Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.Register(nameof(TitleVisibility), typeof(Visibility),
            typeof(RBtnGroupChapter6), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty TitleHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TitleHorizontalAlignment), typeof(HorizontalAlignment),
            typeof(RBtnGroupChapter6), new PropertyMetadata(HorizontalAlignment.Left));

        public static DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight),
            typeof(RBtnGroupChapter6), new PropertyMetadata(FontWeights.Normal));
        #endregion

        #region Properties
        [Category("Custom Properties")]
        [Description("Collection of radio buttons.")]
        public ObservableCollection<RadioButton> RadioButtons { get; } = new ObservableCollection<RadioButton>();
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

        #region Callbacks
        private void RadioButtonsChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        private void RadioButtonCheckedResponce(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            RadioButtonSelected?.Invoke(this, new RadioButtonGroupEventArgs() { Button = button });
        }
        #endregion

        #region Private Methods
        private void SubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked += RadioButtonCheckedResponce;
            radioButton.MouseEnter += RadioButton_MouseEnter;
            radioButton.MouseLeave += RadioButton_MouseLeave;
        }

        private void UnsubscribeTo(RadioButton radioButton)
        {
            radioButton.Checked -= RadioButtonCheckedResponce;
            radioButton.MouseEnter -= RadioButton_MouseEnter;
            radioButton.MouseLeave -= RadioButton_MouseLeave;
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
    }
}
