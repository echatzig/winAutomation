using SoftSrv.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftSrv
{
    public partial class Form1 : Form
    {
        static Form1 _this;
        List<List<WinAutoParams>> _scriptsList = new List<List<WinAutoParams>>();

        public Form1()
        {
            _this = this;
            InitializeComponent();
        }

        public static void SendAppleNotifications(string url)
        {
            // Running on the worker thread
            _this.lblClients.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                _this.lblClients.Items.Add(url);
            });
            // Back on the worker thread
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            string error = "";
            if (lblClients.SelectedIndex == -1)
                error = "Please select a registered client";
            
            if (lblScripts.SelectedIndex == -1)
                error += "\nPlease select an action script";

            if (error != "")
                MessageBox.Show(error,"ERROR", MessageBoxButtons.OK);
            else
            {
                string url = lblClients.SelectedItem.ToString();

                int idx = lblScripts.SelectedIndex;
                
                var response = RegisterClientController.DoExecuteScript(url, _scriptsList[idx]);

            }
        }

        private void brnLoadScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            var res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                string file = dlg.FileName;
                try
                {
                    string script = File.ReadAllText(file);
                    // TODO:: error handling
                    var parser = new ScriptParser(script);
                    var cmdList = parser._parms;
                    _scriptsList.Add(cmdList);
                    lblScripts.Items.Add(file);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK);
                }
            }

        }
    }
}
