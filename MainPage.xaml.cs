// MainPage.xaml.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input; // ICommand を使うために必要
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UwpMaruBatu
{
    public sealed partial class MainPage : Page
    {
        // 5x5の盤面を表す二次元配列
        // 0: 空白, 1: 〇, 2: ×
        private int[,] BAN = {
            {0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 1, 2, 0},
            {0, 0, 2, 0, 0},
            {0, 0, 0, 0, 0}
        };

        // コマンドを公開するプロパティ
        public ICommand CellClickedCommand { get; private set; }

        public MainPage()
        {
            this.InitializeComponent(); // これでエラーが解消されるはず
            this.DataContext = this; // DataContext を自身に設定することで、XAMLからプロパティにバインドできるようになる

            // コマンドの初期化
            CellClickedCommand = new DelegateCommand(OnCellClicked);

            // ページがロードされたときに盤面を描画する
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // ページが完全にロードされた後に描画メソッドを呼び出す
            drawBan();
        }

        /// <summary>
        /// BAN配列の内容をUIのButtonに表示します。
        /// 0: 空白, 1: 〇, 2: ×
        /// </summary>
        private void drawBan()
        {
            // Buttonの名前とBAN配列のインデックスをマッピング
            SetCellText(t11, BAN[0, 0]); // t11も追加
            SetCellText(t12, BAN[0, 1]);
            SetCellText(t13, BAN[0, 2]);
            SetCellText(t14, BAN[0, 3]);
            SetCellText(t15, BAN[0, 4]);

            SetCellText(t21, BAN[1, 0]);
            SetCellText(t22, BAN[1, 1]);
            SetCellText(t23, BAN[1, 2]);
            SetCellText(t24, BAN[1, 3]);
            SetCellText(t25, BAN[1, 4]);

            SetCellText(t31, BAN[2, 0]);
            SetCellText(t32, BAN[2, 1]);
            SetCellText(t33, BAN[2, 2]);
            SetCellText(t34, BAN[2, 3]);
            SetCellText(t35, BAN[2, 4]);

            SetCellText(t41, BAN[3, 0]);
            SetCellText(t42, BAN[3, 1]);
            SetCellText(t43, BAN[3, 2]);
            SetCellText(t44, BAN[3, 3]);
            SetCellText(t45, BAN[3, 4]);

            SetCellText(t51, BAN[4, 0]);
            SetCellText(t52, BAN[4, 1]);
            SetCellText(t53, BAN[4, 2]);
            SetCellText(t54, BAN[4, 3]);
            SetCellText(t55, BAN[4, 4]);
        }

        /// <summary>
        /// セルのButtonに適切なテキストを設定します。
        /// </summary>
        /// <param name="button">設定対象のButton</param>
        /// <param name="value">BAN配列からの値 (0:空白, 1:〇, 2:×</param>
        public void SetCellText(Button button, int value) // TextBlock から Button に変更
        {
            switch (value)
            {
                case 0:
                    button.Content = " "; // 空白
                    break;
                case 1:
                    button.Content = "〇"; // 丸
                    break;
                case 2:
                    button.Content = "×"; // バツ
                    break;
                default:
                    button.Content = " "; // 空白
                    break;
            }
        }

        // ボタンがクリックされたときに呼び出されるメソッド
        private async void OnCellClicked(object parameter)
        {
            // parameter に CommandParameter で指定した値（例: "1,1", "1,2" など）が渡される
            if (parameter is string cellLocation)
            {
                var dialog = new ContentDialog
                {
                    Title = "ボタンクリック",
                    Content = $"クリックされました: {cellLocation}",
                    CloseButtonText = "OK"
                };
                await dialog.ShowAsync();
            }
        }

        public bool CanPlaceMark(int[,] BAN, int row, int col)
        {
            // CheckClass1 がない場合はこの行でエラーになります
            // その場合は、CheckClass1 の定義か、またはそのメソッドを直接ここに記述してください
            return CheckClass1.CanPlaceMark(BAN, row, col);
        }

        // DelegateCommand クラスは MainPage クラスの外（同じnamespace内）に配置することを推奨
        // ただし、このままでも動作はしますが、慣例としてファイル分割が望ましいです。
        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;

            public event EventHandler CanExecuteChanged;

            public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}