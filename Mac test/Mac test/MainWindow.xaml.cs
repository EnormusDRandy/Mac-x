using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using KrnlAPI;
namespace Mac_test
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        KrnlApi FugmeLol = new KrnlApi();
        public MainWindow()
        {
            InitializeComponent();
            text();
            FugmeLol.Initialize();
        }
        private void text()
        {
            textEditor.TextArea.TextView.LinkTextBackgroundBrush = Brushes.Transparent;
            textEditor.TextArea.TextView.LinkTextForegroundBrush = Brushes.LightBlue;
            textEditor.TextArea.TextView.LinkTextUnderline = false;
            Stream stream = File.OpenRead("./Bin/highlighter.xshd");
            XmlTextReader reader = new XmlTextReader(stream);
            textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);

         

        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Ellipse_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("This is just for an astetic porpuse");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e)
        {
            textEditor.Clear();
        }

        private void OpnFilBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog2.Title = "Mac X | Open file";
            openFileDialog2.Filter = ".txt Files (*.txt)|*.txt|.lua Files (*.lua)|*.lua";
            Microsoft.Win32.OpenFileDialog openFileDialog3 = openFileDialog2;
            bool? nullable = openFileDialog3.ShowDialog();
            bool flag2 = true;
            if (!(nullable.GetValueOrDefault() == flag2 & nullable.HasValue))
                return;
            textEditor.Text = System.IO.File.ReadAllText(openFileDialog3.FileName);
        }

        private void Save_file_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Title = "Mac X | Save file";
                saveFileDialog.Filter = ".txt Files (*.txt)|*.txt|.lua Files (*.lua)|*.lua";
                saveFileDialog.FileName = "";
                Microsoft.Win32.SaveFileDialog SaveDialog = saveFileDialog;
                SaveDialog.ShowDialog();


                string getscript = textEditor.Text;
                System.IO.File.WriteAllText(SaveDialog.FileName, getscript);
                getscript = (string)null;

                SaveDialog = (Microsoft.Win32.SaveFileDialog)null;
            }
            catch
            {
                MessageBox.Show("Operation canceled");
            }
           
        }

        private void ExecFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
                Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
                openFileDialog2.Title = "Mac X | Execute File";
                openFileDialog2.Filter = ".txt Files (*.txt)|*.txt|.lua Files (*.lua)|*.lua";
                Microsoft.Win32.OpenFileDialog openFileDialog3 = openFileDialog2;
                bool? nullable = openFileDialog3.ShowDialog();
                bool flag2 = true;
                if (!(nullable.GetValueOrDefault() == flag2 & nullable.HasValue))
                    return;
               FugmeLol.Execute(System.IO.File.ReadAllText(openFileDialog3.FileName));
            }
            catch (Exception)
            {
                MessageBox.Show("Operation canceled");
            }
        }

        private void ExecuteBtn_Click(object sender, RoutedEventArgs e)
        {
            string script = textEditor.Text;
            FugmeLol.Execute(script);
        }

        private void InBtn_Click(object sender, RoutedEventArgs e)
        {
            FugmeLol.Inject();
        }

        private void UH_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The exploit was made as a joke so if you want add it by yourself");
        }

        private void UH_Copy1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The exploit was made as a joke so if you want add it by yourself");
        }
    }
}
