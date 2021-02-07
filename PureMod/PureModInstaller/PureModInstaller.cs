using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace PureModInstaller
{
    public partial class PureModInstaller : Form
    {
        private bool isVRChatGame = false;

        public PureModInstaller() =>
            InitializeComponent();

        #region Drag

        private Point lastPoint;

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                lastPoint = new Point(e.X, e.Y);
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        #endregion

        #region Close & Minimize

        private void CloseAppButton_Click(object sender, EventArgs e) =>
            Application.Exit();

        private void MinimizeAppButton_Click(object sender, EventArgs e) =>
            WindowState = FormWindowState.Minimized;


        #endregion

        #region Links

        private void DiscordButton_Click(object sender, EventArgs e) =>
            Process.Start("https://discord.gg/VCbeWNW");

        private void GithubButton_Click(object sender, EventArgs e) =>
            Process.Start("https://github.com/PureFoxCore/PureMod");


        #endregion

        private void SelectPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select VRChat exe";
            fileDialog.Filter = "VRChat|*.exe";
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = Application.ExecutablePath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPathBox.Text = fileDialog.FileName;
                isVRChatGame = Path.GetFileName(fileDialog.FileName) == "VRChat.exe";
            }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (isVRChatGame)
            {
                string dir = SelectedPathBox.Text.Replace("VRChat.exe", "Mods");

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);


            }
            else
                MessageBox.Show("Please select VRChat.exe", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
