using Avalonia.Controls;
using Avalonia.Interactivity;
using Lab_7.ViewModels;
using Lab_7.Models;

namespace Lab_7.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("OpenFileButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
            };

            this.FindControl<MenuItem>("SaveFileButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "SaveFile",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
            };

            this.FindControl<MenuItem>("ExitButton").Click += async delegate
            {
                this.Close();
            };

        }
        private async void ClickEventAboutDialog(object sender, RoutedEventArgs e)
        {
            await new AboutWindow().ShowDialog<string?>((Window)this.VisualRoot);
        }
        public async void EventEditEnding(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            if (box != null)
            {
                var student = box.DataContext as StudentData;
                student.CalculateAverage();
            }
        }
    }
}
