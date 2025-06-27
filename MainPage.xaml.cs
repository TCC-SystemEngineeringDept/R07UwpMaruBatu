using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace UwpMaruBatu
{
    public sealed partial class MainPage : Page
    {
        // 5x5の盤面を表す二次元配列
        // 0: 空白, 1: 〇, 2: ×
        private int[,] BAN = {
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}
        };

        public MainPage()
        {
            this.InitializeComponent();
            // ページがロードされたときに盤面を描画する
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // ページが完全にロードされた後に描画メソッドを呼び出す
            drawBan();
        }

        /// <summary>
        /// BAN配列の内容をUIのTextBlockに表示します。
        /// 0: 空白, 1: 〇, 2: ×
        /// </summary>
        private void drawBan()
        {
            // TextBlockの名前とBAN配列のインデックスをマッピング
            // この方法は冗長ですが、XAMLで各TextBlockにx:Nameを付けているため、直接アクセスします。
            // より動的な方法としては、GridにClickイベントを設定し、
            // クリックされたBorder/TextBlockのGrid.RowとGrid.Columnを取得する方法もあります。

            SetCellText(t11, BAN[0, 0]);
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
        /// セルのTextBlockに適切なテキストを設定します。
        /// </summary>
        /// <param name="textBlock">設定対象のTextBlock</param>
        /// <param name="value">BAN配列からの値 (0:空白, 1:〇, 2:×</param>
        public void SetCellText(TextBlock textBlock, int value)
        {
            switch (value)
            {
                case 0:
                    break;
                case 1:
                    textBlock.Text = "〇"; // 丸
                    break;
                case 2:
                    textBlock.Text = "×"; // バツ
                    break;
                default:
                    textBlock.Text = "  "; // 空白
                    break;
            }
        }
        public bool CanPlaceMark(int row, int col)
        {
            return false;
        }

    }
}
