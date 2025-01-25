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
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // 檔案開啟物件
            var fd = new Microsoft.Win32.OpenFileDialog();
            
            // 設定檔案過濾，格式：說明文字|*.副檔名
            fd.Filter = "音訊檔案(*.mp3,*.3gp,*.wma)|*.mp3; *.3gp; *.wma|影片檔案(*.mp4, *.avi, *.mpeg, *.wmv)|*.mp4; *.avi; *.mpeg; *.wmv|所有檔案(*.*)|*.*";
            // 設定預設開啟檔案位置，設定為桌面
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // 開啟對話框
            fd.ShowDialog();
            // 如果使用者有選取檔案，就把檔案與檔案位置儲存到filename中
            string filename = fd.FileName;
            if (filename != "")
            {
                // 將檔案與檔案位置顯示在輸入文字框裡面
                txtFilePath.Text = filename;
                // 將檔案與檔案位置轉化成URI，一種用來設定檔案資源定位的位置資料 
                Uri u = new Uri(filename);
                // 將URI放進影音元件中
                MedShow.Source = u;
                // 設定這個影音的聲音大小（可有可無）
                MedShow.Volume = 0.5f;
                // 將影音進行播放
                MedShow.LoadedBehavior = MediaState.Play;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            // 設定影音播放狀態為「Play」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Play;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            // 設定影音播放狀態為「Pause」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Pause;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            // 設定影音播放狀態為「Stop」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Stop;
        }        
    }
}
