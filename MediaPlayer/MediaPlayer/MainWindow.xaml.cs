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
            //檔案開啟物件
            var fd = new Microsoft.Win32.OpenFileDialog();
            //設定檔案過濾
            fd.Filter = "音訊檔案(*.mp3,*.3gp,*.wma)|*.mp3; *.3gp; *.wma|影片檔案(*.mp4, *.avi, *.mpeg, *.wmv)|*.mp4; *.avi; *.mpeg; *.wmv|所有檔案(*.*)|*.*";
            //fd.Filter = "MP3(*.mp3)|*.mp3|MP4(*.mp4)|*.mp4|3GP(*.3gp)|*.3gp|WMA(*.wma)|*.wma|MOV(*.mov)|*.mov|AVI(*.avi)|*.avi|WMV(*.wmv)|*.wmv|MPEG(*.mpeg)|*.mpeg|所有檔案(*.*)|*.*";
            //設定預設開啟檔案位置，設定為桌面
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //開啟對話框
            fd.ShowDialog();
            //如果使用者有選取檔案，就把檔案位置與檔名儲存到filename中
            string filename = fd.FileName;
            if (filename != "")
            {
                //將檔案位置與檔名顯示在輸入文字框裡面
                txtFilePath.Text = filename;
                //將檔案位置與檔名轉化成URI，一種用來設定檔案資源定位的位置資料 
                Uri u = new Uri(filename);
                //將URI放進影音元件中
                MedShow.Source = u;
                //設定這個影音的聲音大小（可有可無）
                MedShow.Volume = 0.5f;
                //將影音進行播放
                MedShow.LoadedBehavior = MediaState.Play;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //設定影音播放狀態為「Play」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Play;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            //設定影音播放狀態為「Pause」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Pause;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //設定影音播放狀態為「Stop」，將狀態設定到目前的讀取行為
            MedShow.LoadedBehavior = MediaState.Stop;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //關閉整個程式的指令
            Environment.Exit(0);
        }

        private void sliVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MedShow.Volume = sliVolume.Value;
            //設定聲音大小
            //txtFilePath.Text = MedShow.Volume.ToString();
        }

        TimeSpan TimePosition;
        //宣告一個時間間格
        DispatcherTimer timer = null;
        //宣告一個「空的」計時器

        private void MedShow_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimePosition = MedShow.NaturalDuration.TimeSpan;
            //取得所開啟的影片時間長度
            sliProgress.Minimum = 0;
            //重新設定影片播放滑桿
            sliProgress.Maximum = TimePosition.TotalMilliseconds;
            //最大值設定為影片的總毫秒數

            timer = new DispatcherTimer();
            //設定計時器
            timer.Interval = TimeSpan.FromSeconds(1);
            //這個計時器設定每一個刻度為1秒
            timer.Tick += new EventHandler(timer_tick);
            //每一個時間刻度設定一個小程序timer_tick
            timer.Start();
            //啟動這個計時器
        }

        private void timer_tick(object sender, EventArgs e)
        {
            //小程序，更新目前影片播放進度
            sliProgress.Value = MedShow.Position.TotalMilliseconds;
            txtTime.Text = MedShow.Position.ToString("h'h 'm'm 's's'");
        }

        private void sliProgress_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int SliderValue = (int)sliProgress.Value;
            //還記得轉型嗎？

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            //將滑桿的數值改變成時間間格的資料形式
            MedShow.Position = ts;
            //調整影片播放進度到新的時間
        }
    }
}
