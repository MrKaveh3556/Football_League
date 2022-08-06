using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    public partial class ShowAll_Form : Form
    {
        public ShowAll_Form()
        {
            InitializeComponent();
        }
        private void ShowAll_Form_Load(object sender, EventArgs e)
        {
            //This line of code loads data into the 'footBall_LeagueDataSet.Table_Teams' table. You can move, or remove it, as needed.
            this.table_TeamsTableAdapter.Fill(this.footBall_LeagueDataSet.Table_Teams);
        }
        private void ShowAll_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closing = MessageBox.Show("Do you want to close the form?!",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);
            if (closing == DialogResult.No)
            {
                MessageBox.Show("Form not closed :))");
                e.Cancel = true;
            }
        }
    }
}
