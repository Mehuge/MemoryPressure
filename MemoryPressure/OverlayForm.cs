// OverlayForm.cs
// This file contains the logic for the new overlay window.
// It is a borderless, always-on-top, draggable form.

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryPressure
{
    public partial class OverlayForm : Form
    {
        // Reference to the main form to communicate back.
        private Form1 mainForm;

        // For dragging the borderless form.
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
            // Set properties for the overlay window.
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.75; // Semi-transparent
        }

        // Public method for the main form to update the stats on this overlay.
        public void UpdateStats(string percent, string usedRam, string topProcessName, string topProcessMemory)
        {
            lblOverlayPercent.Text = percent;
            lblOverlayUsedRam.Text = usedRam;

            // **NEW**: Update the top process label.
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
        // This makes all controls on the form draggable.
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
        #endregion
    }
}
