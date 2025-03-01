using System.Windows;
using RadioButtonGroupLibary;
using RadioButtonGroupLibrary;

namespace CustomUserControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dough_Selection(object sender, RadioButtonGroupEventArgs e)
        {
            RadioButtonGroup group = ((RadioButtonGroup)sender);
            
        }

        private void Filling_Selection(object sender, RadioButtonGroupEventArgs e)
        {

        }

        private void Pineapples_Selection(object sender, RadioButtonGroupEventArgs e)
        {
            if (e.Button.Content.ToString() == "Так")
            {
                MessageBox.Show("Збоченців не обслуговуємо!", "Вийшов звідси!", MessageBoxButton.OK, MessageBoxImage.Hand);
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Супер, їх в будь-якому випадку немає", "Молодець", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Drink_Selection(object sender, RadioButtonGroupEventArgs e)
        {
            switch (e.Button.Content.ToString())
            {
                case "Енергетик":
                    MessageBox.Show("На жаль, енергетики закінчились. Виберіть щось інше", "О ні! Як так сталось?", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    ((RadioButtonGroup)sender).RemoveByContent("Енергетик");
                    break;
                case "Чай":
                    MessageBox.Show("Чаю нема!", "Вибачте", MessageBoxButton.OK, MessageBoxImage.Information);    
                    ((RadioButtonGroup)sender).RemoveByContent("Чай");
                    break;
                case "Кава":
                    MessageBox.Show("На жаль, кава закінчилась. Виберіть щось інше", "О ні! Як так сталось?", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    ((RadioButtonGroup)sender).RemoveByContent("Кава");
                    break;
                case "В мене з собою є":
                    MessageBox.Show("Зі своїм не можна. Все ж щось візьміть", "А ти на що розраховував?", MessageBoxButton.OK, MessageBoxImage.Hand);
                    ((RadioButtonGroup)sender).RemoveByContent("В мене з собою є");
                    break;
                case "Вода":
                    MessageBox.Show("Хороший вибір!", "Вода в нас платна", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case "Алкоголь":
                    MessageBox.Show("Алкоголь не продаєм!", "Ми студентів не травимо!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    ((RadioButtonGroup)sender).RemoveByContent("Алкоголь");
                    break;
            }
        }

        private void Have_Money(object sender, RadioButtonGroupEventArgs e)
        {

        }

        private void Criminal_Record(object sender, RadioButtonGroupEventArgs e)
        {

        }

        private void Make_Order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("На жаль, ви довго думали. Столова завершила свою роботу", "Ну ти і гальмо!", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
    }
}
