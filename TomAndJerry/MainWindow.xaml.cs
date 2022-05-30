using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TomAndJerry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           

            
        }
        private void OpenImg(object Sender, RoutedEventArgs E)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор избражения",
                CheckFileExists = true

            };

            if (dialog.ShowDialog(this) != true) return;
            var fileName = dialog.FileName;
            ImageView.Source= new BitmapImage(new Uri(fileName, UriKind.RelativeOrAbsolute));
            // Create single instance of sample data from first line of dataset for model input
            TomJarryClassificator.ModelInput sampleData = new TomJarryClassificator.ModelInput()
            {
                ImageSource = fileName,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = TomJarryClassificator.Predict(sampleData);
            InitializeComponent();
            Result.Text = $"{predictionResult.Prediction} - {predictionResult.Score.Max():p0}";

        }
    }
}
