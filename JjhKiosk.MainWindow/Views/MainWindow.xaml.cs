using System.Windows;
using System.Windows.Input;

namespace JjhKiosk.MainWindow.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 눌린 키가 ESC이면
            if (e.Key == Key.Escape)
            {
                // 창을 닫습니다.
                this.Close();
            }
        }
    }
}
