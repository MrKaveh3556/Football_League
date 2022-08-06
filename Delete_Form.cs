using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    public partial class Delete_Form : Form
    {
        public Delete_Form()
        {
            InitializeComponent();
        }
        //add teams to listbox
        public delegate void Add_TeamsDel();
        //--------------------//
        //delete team
        public delegate void Delete_TeamDel();
        //------------//
        //empty the controls
        public void Empty()
        {
            #region String.Empty
            TeamName.Text = string.Empty;
            Tedad_Bazi.Text = string.Empty;
            Win.Text = string.Empty;
            Draw.Text = string.Empty;
            Lose.Text = string.Empty;
            Point.Text = string.Empty;
            Goalzadeh.Text = string.Empty;
            Goalkhordeh.Text = string.Empty;
            Tafazol.Text = string.Empty;
            #endregion
        }
        public delegate void EmptyDel();
        //-------------------//
        public delegate void InformationDel(string team_name);
        //-------------------------------------//
        private void Delete_Form_Load(object sender, EventArgs e)
        {
            DeleteClass delete_class = new DeleteClass();
            Add_TeamsDel add_team = new Add_TeamsDel(delete_class.Add_Teams);
            add_team();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteClass delete_class = new DeleteClass();
            DialogResult message = MessageBox.Show($"Do you Want to Delete {TeamName.Text}?!",
            "Warning!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);
            if (message == DialogResult.Yes)
            {
                try
                {
                    Delete_TeamDel delete = new Delete_TeamDel(delete_class.Delete_Team);
                    delete();
                    Add_TeamsDel add_team = new Add_TeamsDel(delete_class.Add_Teams);
                    add_team();
                    EmptyDel empty = new EmptyDel(Empty);
                    empty();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
            else
                MessageBox.Show("Operation canceled :)");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteClass delete_class = new DeleteClass();
            string team_name = listBox1.SelectedItem.ToString();
            InformationDel info = new InformationDel(delete_class.Information);
            info(team_name);
        }
        private void Delete_Form_FormClosing(object sender, FormClosingEventArgs e)
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
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            DeleteClass delete_class = new DeleteClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                InformationDel info = new InformationDel(delete_class.Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show("Please select team from list :((");
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeleteClass delete_clas = new DeleteClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                InformationDel info = new InformationDel(delete_clas.Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show("Please select team from list :((");
            }
        }
    }
}
