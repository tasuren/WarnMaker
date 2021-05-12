using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WarnMaker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("WarnMaker by tasuren");
            InitializeComponent();
            // モードセレクターを初期値のなしにする。
            IconModeSelector.SelectedIndex = 4;
            ButtonModeSelector.SelectedIndex = 0;
        }

        private MessageBoxImage ExtractIconMode()
        {
            // どのアイコンにするか調べる。
            switch (IconModeSelector.Text)
            {
                case "エラー":
                    return MessageBoxImage.Error;
                case "警告":
                    return MessageBoxImage.Warning;
                case "質問":
                    return MessageBoxImage.Question;
                case "情報":
                    return MessageBoxImage.Information;
                default:
                    return MessageBoxImage.None;
            }
        }

        private MessageBoxButton ExtractButtonMode()
        {
            // どのボタンにするか調べる。
            switch (ButtonModeSelector.Text)
            {
                case "OK":
                    return MessageBoxButton.OK;
                case "OK/Cancel":
                    return MessageBoxButton.OKCancel;
                case "Yes/No":
                    return MessageBoxButton.YesNo;
                case "Yes/No/Cancel":
                    return MessageBoxButton.YesNoCancel;
                default:
                    return MessageBoxButton.OK;
            }
        }

        private void Make_Message_Box(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Making MessageBox!");
            MessageBox.Show(Description.Text, Title.Text, ExtractButtonMode(), ExtractIconMode());
        }

        private void Description_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Enter)
            {
                Make_Message_Box(this, null);
            }
        }
    }
}
