using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LivetApp1.Views
{
   

    /// <summary>
    /// jirei.xaml の相互作用ロジック
    /// </summary>
    public partial class jirei : Window
    {
        public jirei()
        {
            InitializeComponent();
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)　//行番号を取得
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void Button1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button2(object sender, RoutedEventArgs e)
        {
         
         
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}