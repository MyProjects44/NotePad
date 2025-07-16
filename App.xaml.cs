using System;
using System.Windows;
using Forms = System.Windows.Forms;

namespace NotePad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;
        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _notifyIcon.Icon = new System.Drawing.Icon(@"icon\icon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick!;
            _notifyIcon.Text = "NotePad";
            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Öffnen", null, OnStatusOpen!);
            _notifyIcon.ContextMenuStrip.Items.Add("Beenden", null, OnStatusClicked!);

            base.OnStartup(e);
        }

        private void OnStatusClicked(object sender, EventArgs e)
        {
            Shutdown();
        }

        //private void OnMinimized(Shut)
        private void OnStatusOpen(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();

            base.OnExit(e);
        }
    }
}
