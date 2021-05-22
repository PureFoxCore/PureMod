﻿using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace PureModInstaller
{
    public partial class PureModInstaller : Form
    {
        #region Init & Variables

        private WebClient client = new WebClient();
        private bool isVRChatGame = false;

        public PureModInstaller() =>
            InitializeComponent();

        #endregion

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

        #region Select & Install

        private void SelectPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select VRChat exe";
            fileDialog.Filter = "VRChat|*.exe";
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = Application.ExecutablePath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
                if (File.Exists(fileDialog.FileName))
                {
                    SelectedPathBox.Text = fileDialog.FileName;
                    isVRChatGame = Path.GetFileName(fileDialog.FileName) == "VRChat.exe";
                }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            if (isVRChatGame)
            {
                string loaderDir = SelectedPathBox.Text.Replace("VRChat.exe", "Mods"); // VRChat/Mods directory
                string modsDir = SelectedPathBox.Text.Replace("VRChat.exe", "PureMod") + "\\Mods"; // VRChat/PureMod/Mods directory
                string loaderFile = $"{loaderDir}\\PureModLoader.dll";
                string modFile = $"{modsDir}\\PureMod.dll";

                if (!Directory.Exists(loaderDir))
                    Directory.CreateDirectory(loaderDir);

                if (FrechInstallCBox.Checked)
                {
                    DirectoryInfo di = new DirectoryInfo(loaderDir);
                    foreach (FileInfo files in di.GetFiles())
                        files.Delete();
                    foreach (DirectoryInfo dirs in di.GetDirectories())
                        dirs.Delete(true);

                    DirectoryInfo dim = new DirectoryInfo(modsDir);
                    foreach (FileInfo files in dim.GetFiles())
                        files.Delete();
                    foreach (DirectoryInfo dirs in dim.GetDirectories())
                        dirs.Delete(true);
                }
                else if (File.Exists(loaderFile)) // Remove old Loader
                    File.Delete(loaderFile);

                // Remove old mod
                if (File.Exists(modFile))
                    File.Delete(modFile);

                client.DownloadFileCompleted += (object cs, System.ComponentModel.AsyncCompletedEventArgs ce) =>
                {
                    if (ce.Cancelled)
                        MessageBox.Show("Download cancelled", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Download completed successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                client.DownloadFileAsync(new Uri("https://github.com/PureFoxCore/PureMod/releases/latest/download/PureModLoader.dll"), loaderFile);
                client.DownloadFileAsync(new Uri("https://github.com/PureFoxCore/PureMod/releases/latest/download/PureMod.dll"), modFile);
            }
            else
                MessageBox.Show("Selected .exe file is not VRChat.exe\nPlease select VRChat.exe", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
