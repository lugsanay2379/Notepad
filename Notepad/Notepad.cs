using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        ToolStripStatusLabel statusLabel;
        public Notepad()
        {
            InitializeComponent();
            statusLabel = new ToolStripStatusLabel("Ready");
            statusStrip1.Items.Add(statusLabel);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog(); 
            op.Title = "open";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*"; 
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText); this.Text = op.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog(); op.Title = "Save";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*"; if (op.ShowDialog() == DialogResult.OK)
            richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText); this.Text = op.FileName;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message = "Do you want to close this window?"; string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; DialogResult result = MessageBox.Show(message, title, buttons); 
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Notepad", "Close Cancelled", MessageBoxButtons.OK);
            }


        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog op = new FontDialog(); 
            if (op.ShowDialog() == DialogResult.OK) richTextBox1.Font = op.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog op = new ColorDialog(); 
            if (op.ShowDialog() == DialogResult.OK) richTextBox1.ForeColor = op.Color;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string message = "Do you want to save changes before closing?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem.PerformClick();
                    e.Cancel = true;

                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                
            }

        }
    }
}

