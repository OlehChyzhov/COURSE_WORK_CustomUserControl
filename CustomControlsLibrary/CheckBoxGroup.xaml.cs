using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
    [System.Drawing.ToolboxBitmap(typeof(CheckBoxGroup), "CustomControlsLibrary.CheckBoxGroup.bmp")]
    public partial class CheckBoxGroup : UserControl
    {
        public CheckBoxGroup()
        {
            InitializeComponent();
            this.DataContext = this;
            CheckBoxes.CollectionChanged += SubscribeAllCheckboxes;
        }
        ~CheckBoxGroup()
        {
            foreach (CheckBox checkBox in CheckBoxes)
            {
                UnsubscribeTo(checkBox);
            }
            CheckBoxes.CollectionChanged -= SubscribeAllCheckboxes;
        }

        #region Events
        [Category("Custom Events")]
        [Description("Executes when the checkbox is selected.")]
        public event EventHandler<CheckboxGroupEventArgs> CheckBoxSelected;
        public event EventHandler<CheckboxGroupEventArgs> CheckBoxUnselected;
        #endregion

        #region Dependency Properties
        public static DependencyProperty ColumnsCheckBProperty = DependencyProperty.Register(nameof(Columns), typeof(int),
            typeof(CheckBoxGroup), new PropertyMetadata(1));

        public static DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string),
            typeof(CheckBoxGroup), new PropertyMetadata("Checkbox Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.Register(nameof(TitleVisibility), typeof(Visibility),
            typeof(CheckBoxGroup), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty TitleHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TitleHorizontalAlignment), typeof(HorizontalAlignment),
            typeof(CheckBoxGroup), new PropertyMetadata(HorizontalAlignment.Left));

        public static DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight),
            typeof(CheckBoxGroup), new PropertyMetadata(FontWeights.Normal));
        #endregion

        #region Often Used Properties
        [Category("The Most Popular")]
        [Description("Number of columns for all checkboxes.")]
        public int Columns
        {
            get => (int)GetValue(ColumnsCheckBProperty);
            set => SetValue(ColumnsCheckBProperty, value);
        }

        [Category("The Most Popular")]
        [Description("Text displayed at the top of checkbox group.")]
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
        private CheckBox selectedCheckbox;

        [Category("Custom Properties")]
        [Description("Index of the selected checkbox.")]
        public int SelectedCheckboxIndex
        {
            get => CheckBoxes.IndexOf(selectedCheckbox);
        }

        [Category("Custom Properties")]
        [Description("Collection of checkboxes.")]
        public ObservableCollection<CheckBox> CheckBoxes { get; } = new ObservableCollection<CheckBox>();
        #endregion

        #region Important Methods
        private void SubscribeAllCheckboxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (CheckBox checkBox in e.OldItems)
                {
                    UnsubscribeTo(checkBox);
                }
            }

            if (e.NewItems != null)
            {
                foreach (CheckBox checkBox in e.NewItems)
                {
                    SubscribeTo(checkBox);
                }
            }
        }
        private void CheckBoxSelectedResponce(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            selectedCheckbox = checkbox;

            CheckBoxSelected?.Invoke(this, new CheckboxGroupEventArgs() { CheckBox = checkbox });
        }
        private void CheckBoxUnselectedResponce(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            selectedCheckbox = checkbox;

            CheckBoxUnselected?.Invoke(this, new CheckboxGroupEventArgs() { CheckBox = checkbox });
        }
        #endregion

        #region Private Methods
        private void SubscribeTo(CheckBox checkbox)
        {
            checkbox.Checked += CheckBoxSelectedResponce;
            checkbox.Unchecked += CheckBoxUnselectedResponce;
        }
        private void UnsubscribeTo(CheckBox checkbox)
        {
            checkbox.Checked -= CheckBoxSelectedResponce;
            checkbox.Unchecked -= CheckBoxUnselectedResponce;
        }
        #endregion

        #region Public Methods
        [Category("Custom Methods")]
        [Description("Adds a checkbox to the group.")]
        public void Add(CheckBox checkbox)
        {
            SubscribeTo(checkbox);
            CheckBoxes.Add(checkbox);
        }

        [Category("Custom Methods")]
        [Description("Removes checkbox matching a given filter.")]
        public void RemoveButtons(Func<CheckBox, bool> filter)
        {
            foreach (CheckBox checkbox in CheckBoxes.Where(filter))
            {
                UnsubscribeTo(checkbox);
                CheckBoxes.Remove(checkbox);
            }
        }
        #endregion
    }
}
