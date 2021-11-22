using aejw.Network;
using CBR_ADMIN;
using CBR_ADMIN.Properties;
using CBR_ADMIN.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_VPN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string host = "177.231.253.170";
        public string recep;
        public static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
           "\\VPN");
        private void Form2_Load(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            else
            {
                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;
            }
            txtUsrname.Text = Settings.Default.user.Trim();
            txtPassword.Text = Settings.Default.pass.Trim();
            if (host != "" && txtPassword.Text !="" && txtUsrname.Text!="" )
            {  if( recep == "1") { coneca(); }
                else { recep = "2"; }
               // this.WindowState = FormWindowState.Minimized;
               
              
                this.WindowState = FormWindowState.Minimized;
                notificacion();
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            }
            else { }
         
        }
       public void  notificacion()
        {
            notifyIcon1.Text = "CBR VPN";
            notifyIcon1.BalloonTipTitle = "notifyIcon";
            notifyIcon1.BalloonTipText = "notifyIcon";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Visible = true;
            this.Hide();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {

            NetworkDrive oNetDrive1 = new NetworkDrive();
            try
            {
                oNetDrive1.Force = true;
                oNetDrive1.LocalDrive = "G";
                oNetDrive1.UnMapDrive();

                //update status
            }
            catch (Exception err)
            {
                //report error



            }
            Settings.Default.user = txtUsrname.Text;
            Settings.Default.pass = txtPassword.Text;
            Settings.Default.Save();

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + host);

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + txtUsrname.Text + " " + txtPassword.Text + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat"
        
                     
        }
            };
           

            newProcess.Start();
            newProcess.WaitForExit();

            if (newProcess.HasExited)
            {
                AutoClosingMessageBox.Show("Conexion Exitosa actualize navegador", "Conexion Exitosa ", 4000);
            }
            else
            {
               
            }


            btnConnect.Enabled = false;
           
        
            txtUsrname.Text = Settings.Default.user.Trim();
            this.WindowState = FormWindowState.Minimized;

         
            Notificacion1 apertura = new Notificacion1();
            apertura.Show();
            apertura.BringToFront();
            apertura.WindowState = FormWindowState.Normal;
            NetworkDrive oNetDrive = new NetworkDrive();

            try
            {
                //set propertys

                oNetDrive.LocalDrive = "G";
                oNetDrive.ShareName = url.Text;
                //match call to options provided

                oNetDrive.MapDrive();


                //update status

            }
            catch (Exception err)
            {
                //report error

                MessageBox.Show(this, "Error en conexion volviendo a conectar en segundo intento ... " + err.Message);

                oNetDrive.LocalDrive = "G";
                oNetDrive.ShareName = url.Text;
                //match call to options provided

                oNetDrive.MapDrive();

            }
            oNetDrive = null;

        }
        public void coneca()
        {
            
            Settings.Default.user = txtUsrname.Text;
            Settings.Default.pass = txtPassword.Text;
            Settings.Default.Save();

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
        sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + host);

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
        sb.AppendLine("rasdial \"VPN\" " + txtUsrname.Text + " " + txtPassword.Text + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                       WindowStyle = ProcessWindowStyle.Hidden

        }
            };
        AutoClosingMessageBox.Show("Conexion Exitosa", "CBred", 2000);

            newProcess.Start();
            newProcess.WaitForExit();
         
            btnConnect.Enabled = false;
         
        
            txtUsrname.Text = Settings.Default.user.Trim();

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
         public void desconectaVPN() {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Minimized
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;

            this.Hide();
            Close();
            Application.Exit();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Minimized
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;
            txtPassword.Text = "";
            txtUsrname.Text = "";
          
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;
          
            this.Hide();
            Close();
          
        }

        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;
         
           
        }

    



    }
}
