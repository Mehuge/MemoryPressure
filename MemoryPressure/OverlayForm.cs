// OverlayForm.cs
// This file contains the logic for the new overlay window.
// Updated to position the settings dialog below itself.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryPressure
{
    public partial class OverlayForm : Form
    {
        private Form1 mainForm;
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public OverlayForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Black;

            if (IsOnScreen(Properties.Settings.Default.OverlayFormLocation))
            {
                this.Location = Properties.Settings.Default.OverlayFormLocation;
            }
        }

        public void UpdateStats(string percent, string usedRam, string topProcessName, string topProcessMemory)
        {
            lblOverlayPercent.Text = percent;
            lblOverlayUsedRam.Text = usedRam;

            if (!string.IsNullOrEmpty(topProcessName))
            {
                lblTopProcess.Text = $"Top: {topProcessName} ({topProcessMemory})";
            }
            else
            {
                lblTopProcess.Text = "Top: (no process found)";
            }
        }

        #region Form Dragging Logic
        private void DraggableControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        private void DraggableControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int xDiff = Cursor.Position.X - lastCursor.X;
                int yDiff = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastForm.X + xDiff, lastForm.Y + yDiff);
            }
        }

        private void DraggableControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        #endregion

        #region Context Menu Logic
        private void showMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.ShowMainWindow();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // **THE FIX**: Temporarily disable TopMost so the settings dialog can appear on top.
            this.TopMost = false;
            mainForm.ShowSettingsDialog(this); // Pass this form as the owner for positioning.
            this.TopMost = true; // Re-enable TopMost after the dialog is closed.
        }
        #endregion

        private bool IsOnScreen(Point location)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Contains(location))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
