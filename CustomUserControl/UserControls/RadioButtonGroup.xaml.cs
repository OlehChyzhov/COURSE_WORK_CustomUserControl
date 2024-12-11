using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomUserControl.UserControls
{
    public partial class RadioButtonGroup : UserControl
    {
        /// <summary> Виконується коли певна кнопка (Radiobutton) була вибрана. </summary>
        public event EventHandler<RadiobuttonGroupEventArgs>? RadioButtonChecked;

        public RadioButtonGroup()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #region Properties
        /// <summary> Набір усіх існуючих кнопок. </summary>
        private ObservableCollection<RadioButton> _allRadioButtons { get; set; } = new();

        /// <summary> Набір кнопок, рівномірно розподілених між групами. </summary>
        public ObservableCollection<ObservableCollection<RadioButton>> RadioButtonGroups { get; } = new ObservableCollection<ObservableCollection<RadioButton>>();

        // Dependency Properties необхідні для динамічного змінення RadioButtonGroup. Якщо їх не використовувати, 
        // для відображення змін у файлі .xaml потрібно буде перебудовувати проєкт.

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached(nameof(Columns), typeof(int), typeof(RadioButtonGroup), new PropertyMetadata(1, OnColumnsChanged));
        
        public static readonly DependencyProperty AllRadioButtonsProperty = DependencyProperty.RegisterAttached(nameof(RadioButtons), typeof(string), typeof(RadioButtonGroup), new PropertyMetadata("RadioButton", OnRadioButtonsChanged));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached(nameof(Title), typeof(string), typeof(RadioButtonGroup), new PropertyMetadata("Radiobutton group", null));

        public static readonly new DependencyProperty FontWeightProperty = DependencyProperty.RegisterAttached(nameof(FontWeight), typeof(FontWeight), typeof(RadioButtonGroup), new PropertyMetadata(FontWeights.Normal, null));

        public static readonly new DependencyProperty ForegroundProperty = DependencyProperty.RegisterAttached(nameof(Foreground), typeof(Brush), typeof(RadioButtonGroup), new PropertyMetadata(Brushes.Black, null));

        public static readonly new DependencyProperty FontSizeProperty = DependencyProperty.RegisterAttached(nameof(FontSize), typeof(int), typeof(RadioButtonGroup), new PropertyMetadata(12, null));

        public static readonly DependencyProperty ButtonsForegroundProperty = DependencyProperty.RegisterAttached(nameof(ButtonsForeground), typeof(Brush), typeof(RadioButtonGroup), new PropertyMetadata(Brushes.Black, OnRadioButtonsChanged));

        public static readonly DependencyProperty ButtonsFontWeightProperty = DependencyProperty.RegisterAttached(nameof(ButtonsFontWeight), typeof(FontWeight), typeof(RadioButtonGroup), new PropertyMetadata(FontWeights.Normal, OnRadioButtonsChanged));
        
        public static readonly DependencyProperty ButtonsFontSizeProperty = DependencyProperty.RegisterAttached(nameof(ButtonsFontSize), typeof(int), typeof(RadioButtonGroup), new PropertyMetadata(12, OnRadioButtonsChanged));

        // Оскільки Dependency Properties неможливо безпосередньо побачити в .xaml файлі, звичайні Properties використовуються для зв'язку з ним.
        /// <summary> Кількість колонок для розподілу кнопок. Якщо кнопки неможливо розподілити, автоматично вибирається найближче значення. </summary>
        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        /// <summary> Назви кнопок. Необхідно записати через ',' без пробілів. </summary>
        public string RadioButtons
        {
            get => (string)GetValue(AllRadioButtonsProperty);
            set => SetValue(AllRadioButtonsProperty, value);
        }

        /// <summary> Назва групи. </summary>
        public string Title 
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public new FontWeight FontWeight
        {
            get => (FontWeight)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        public new Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public new int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public Brush ButtonsForeground
        {
            get => (Brush)GetValue(ButtonsForegroundProperty);
            set => SetValue(ButtonsForegroundProperty, value);
        }

        public FontWeight ButtonsFontWeight
        {
            get => (FontWeight)GetValue(ButtonsFontWeightProperty);
            set => SetValue(ButtonsFontWeightProperty, value);
        }

        public int ButtonsFontSize
        {
            get => (int)GetValue(ButtonsFontSizeProperty);
            set => SetValue(ButtonsFontSizeProperty, value);
        }

        #endregion

        #region Dependency Property Changed Callbacks

        // Під час змінення Dependency Properties ці методи викликають відповідний функціонал для кожного конкретного екземпляра RadioButtonGroup.
        // Методи оголошені як static, оскільки вони керують поведінкою класу.
        private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((RadioButtonGroup)d).UpdateRadioButtonGroups();
        }
        private static void OnRadioButtonsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((RadioButtonGroup)d).UpdateAllRadioButtons();
        }
        #endregion

        #region Methods
        /// <summary> Під час зміни кількості колонок користувачем цей метод перепорядковує кнопки між групами. </summary>
        private void UpdateRadioButtonGroups()
        {
            RadioButtonGroups.Clear();
            if (Columns <= 0) return;

            int groupSize = (int)Math.Ceiling((double)_allRadioButtons.Count / Columns);

            var groups = _allRadioButtons.Select((rb, index) => new { rb, index }).GroupBy(x => x.index / groupSize)
                .Select(g => new ObservableCollection<RadioButton>(g.Select(x => x.rb)));

            foreach (var group in groups)
            {
                RadioButtonGroups.Add(group);
            }
        }
        /// <summary> Кожного разу, коли користувач модифікує будь-яку властивість, пов'язану з кнопками, цей метод очищає всі кнопки і заповнює їх заново. </summary>
        private void UpdateAllRadioButtons()
        {
            _allRadioButtons.Clear();

            foreach (string name in RadioButtons.Split(","))
            {
                RadioButton button = new RadioButton() 
                { 
                    Content = name, GroupName = Title, 
                    Foreground = ButtonsForeground, FontWeight = ButtonsFontWeight, 
                    FontSize = ButtonsFontSize
                };
                button.Checked += OnRadioButtonChecked;
                _allRadioButtons.Add(button);
            }
            UpdateRadioButtonGroups();
        }
        #endregion

        /// <summary> Виконується, коли вибрано кнопку. Передає групу, в якій розташована кнопка, і саму кнопку. </summary>
        private void OnRadioButtonChecked(object sender, EventArgs? e)
        {
            RadioButton button = (RadioButton)sender;
            RadioButtonChecked?.Invoke(this, new RadiobuttonGroupEventArgs() { Button = button });
        }
    }

    public class RadiobuttonGroupEventArgs : EventArgs
    {
        public required RadioButton Button { get; init; }
    }
}
