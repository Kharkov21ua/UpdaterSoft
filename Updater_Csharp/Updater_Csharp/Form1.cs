using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater_Csharp
{
    public partial class Form1 : Form
    {
        string localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        string exename = AppDomain.CurrentDomain.FriendlyName;
        string exepach = Assembly.GetExecutingAssembly().Location;
        public Form1()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string localVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            label1.Text = "Version: " + localVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                if (Internet.OK())
                {
                    string redver = wc.DownloadString("https://pastebin.com/raw/Ncw7wwZM");
                    //MessageBox.Show("Версия: " + redver);
                    if (Convert.ToDouble(localVersion, CultureInfo.InvariantCulture) == Convert.ToDouble(redver, CultureInfo.InvariantCulture))
                    {
                        MessageBox.Show("Последняя версия софта");
                    }
                    else
                    {
                        if (MessageBox.Show("Доступна новая версия", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            wc.DownloadFile("Адресс загрузки Екзе", "New.exe");
                            Cmd($"taskkill /f /im \"{exename}\" && timeout /t 2 && del \"{exepach}\" && ren new.exe \"{exename}\" && \"{exepach}\"");
                        }
                        else
                        {
                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Нет Интернета...");
                }
            }
            
        }
        public void Cmd(string line)
        {
           Process.Start(new ProcessStartInfo
           {
               FileName = "cmd",
               Arguments = $"/c {line}",
               WindowStyle = ProcessWindowStyle.Hidden,
           });
        }
    }
}
