using System;
using System.Windows.Forms;
using System.Net;
using System.Drawing;

namespace IPAddressChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // IPアドレスを取得してテキストボックスへ表示
            textBox1.Text = get_ip_address();

            // このフォームを常に手前または解除します。
            TopMost = checkBox1.Checked;

            // 通知領域アイコンにWindows規定アイコンを設定する
            notifyIcon1.Icon = SystemIcons.Application;

            // タスクバーに表示しない
            ShowInTaskbar = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // このフォームを常に手前または解除します。
            TopMost = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // IPアドレスを取得してテキストボックスへ表示
            textBox1.Text = get_ip_address();
        }

        private string get_ip_address()
        {
            string ip_adr = "";
            try
            {
                // ホスト名を取得
                string hostname = Dns.GetHostName();
                //ホスト名からIPアドレスを取得
                IPAddress[] ip_list = Dns.GetHostAddresses(hostname);
                foreach (IPAddress ip in ip_list)
                {
                    ip_adr = ip.ToString();
                    //IPv4 && localhostでない
                    if (ip_adr.IndexOf(".") > 0 && !ip_adr.StartsWith("127."))
                    {
                        break;
                    }
                }
            }
            catch
            {
                ip_adr = "Fault";
            }

            return ip_adr;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 通知領域アイコンを右クリック
            // 終了
            Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            // 通知領域アイコンをクリック
            // Formをアクティブにする
            Activate();
        }
    }
}
