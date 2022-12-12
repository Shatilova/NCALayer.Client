using NCALayer.Client;
using NCALayer.Client.CommonUtils;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"{
  ""name"": ""Ivan"",
  ""iin"": ""123456789012""
}";
            btnSaveWithoutTS.Enabled = false;
            btnSaveWithTS.Enabled = false;
            btnApplyTS.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new NCACommonUtilsClient();
            client.CreateCAdESFromBase64(NCAStorage.PKCS12, NCAKey.Signature, textBox1.Text, CreateCAdESFromBase64Callback, CreateCAdESFromBase64Option.AttachContent);
        }

        Task CreateCAdESFromBase64Callback(CreateCAdESFromBase64Response response)
        {
            if (response.ResponseState != NCAResponseState.Success)
            {
                MessageBox.Show($"CreateCAdESFromBase64 error: {response.ResponseState}");
                return Task.CompletedTask;
            }

            SignCompleted(response.SignedCms);
            return Task.CompletedTask;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "signWithoutTS.cms";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            File.WriteAllBytes(filename, Convert.FromBase64String(textBox2.Text));
        }

        private void btnApplyTS_Click(object sender, EventArgs e)
        {
            var client = new NCACommonUtilsClient();
            client.ApplyCAdEST(NCAStorage.PKCS12, NCAKey.Signature, textBox2.Text, ApplyCAdESTCallback);
        }

        Task ApplyCAdESTCallback(ApplyCAdESTResponse response)
        {
            if (response.ResponseState != NCAResponseState.Success)
            {
                MessageBox.Show($"ApplyCAdEST error: {response.ResponseState}");
                return Task.CompletedTask;
            }

            ApplyTSCompleted(response.SignedCms);
            return Task.CompletedTask;
        }

        private void btnSaveWithTS_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "signWithTS.cms";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            File.WriteAllBytes(filename, Convert.FromBase64String(textBox3.Text));
        }

        // from https://stackoverflow.com/a/10775421
        delegate void SignCompletedCallback(string text);
        void SignCompleted(string text)
        {
            if (textBox2.InvokeRequired || btnSaveWithoutTS.InvokeRequired || btnApplyTS.InvokeRequired)
            {
                SignCompletedCallback d = new SignCompletedCallback(SignCompleted);
                Invoke(d, new object[] { text });
            }
            else
            {
                textBox2.Text = text;
                btnSaveWithoutTS.Enabled = true;
                btnApplyTS.Enabled = true;
            }
        }

        delegate void ApplyTSCompletedCallback(string text);
        void ApplyTSCompleted(string text)
        {
            if (textBox3.InvokeRequired || btnSaveWithTS.InvokeRequired)
            {
                ApplyTSCompletedCallback d = new ApplyTSCompletedCallback(ApplyTSCompleted);
                Invoke(d, new object[] { text });
            }
            else
            {
                textBox3.Text = text;
                btnSaveWithTS.Enabled = true;
            }
        }
    }
}
