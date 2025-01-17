using CustomUserControl.Chapter4;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter5
{
    public partial class RBtnGroupChapter5 : UserControl
    {
        public RBtnGroupChapter5()
        {
            InitializeComponent();
            DataContext = this;
        }
        #region Dependency Properties
        public static DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(int),
            typeof(RBtnGroupChapter5), new PropertyMetadata(1));

        public static DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string),
            typeof(RBtnGroupChapter5), new PropertyMetadata("RadioButton Group"));

        public static DependencyProperty TitleVisibilityProperty = DependencyProperty.Register(nameof(TitleVisibility), typeof(Visibility),
            typeof(RBtnGroupChapter5), new PropertyMetadata(Visibility.Visible));

        public static DependencyProperty TitleHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TitleHorizontalAlignment), typeof(HorizontalAlignment),
            typeof(RBtnGroupChapter5), new PropertyMetadata(HorizontalAlignment.Left));

        public static DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(nameof(TitleFontWeight), typeof(FontWeight),
            typeof(RBtnGroupChapter5), new PropertyMetadata(FontWeights.Normal));
        #endregion

        #region Properties
        public ObservableCollection<RadioButton> RadioButtons { get; } = new ObservableCollection<RadioButton>();
        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public Visibility TitleVisibility
        {
            get => (Visibility)GetValue(TitleVisibilityProperty);
            set => SetValue(TitleVisibilityProperty, value);
        }
        public HorizontalAlignment TitleHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty);
            set => SetValue(TitleHorizontalAlignmentProperty, value);
        }
        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set => SetValue(TitleFontWeightProperty, value);
        }
        #endregion
    }
}