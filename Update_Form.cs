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
    public partial class Update_Form : Form
    {
        public Update_Form()
        {
            InitializeComponent();
        }
        //add teams to listbox
        public delegate void Add_TeamsDel();
        //----------------------//
        //update information
        public delegate void Update_InformationDel();
        //------------------//
        //show information of teams
        public delegate void Show_InformationDel(string team_name);
        //---------------------------//
        private void Update_Form_Load(object sender, EventArgs e)
        {
            UpdateClass update = new UpdateClass();
            Add_TeamsDel add = new Add_TeamsDel(update.Add_Teams);
            add();
        }
        private void Update_Form_FormClosing(object sender, FormClosingEventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateClass update = new UpdateClass();
            #region Error_Manage
            if (Win_Textbox.Text == string.Empty)
                errorProvider1.SetError(Win_Textbox, "Please Fill this field :(");
            if (Draw_Textbox.Text == string.Empty)
                errorProvider2.SetError(Draw_Textbox, "Please Fill this field :(");
            if (Lose_Textbox.Text == string.Empty)
                errorProvider3.SetError(Lose_Textbox, "Please Fill this field :(");
            if (Goalzadeh_Textbox.Text == string.Empty)
                errorProvider4.SetError(Goalzadeh_Textbox, "Please Fill this field :(");
            if (Goalkhordeh_Textbox.Text == string.Empty)
                errorProvider5.SetError(Goalkhordeh_Textbox, "Please Fill this field :(");

            if (Win_Textbox.Text == string.Empty
            || Draw_Textbox.Text == string.Empty
            || Lose_Textbox.Text == string.Empty
            || Goalzadeh_Textbox.Text == string.Empty
            || Goalkhordeh_Textbox.Text == string.Empty)
                MessageBox.Show("Please fill all field :((");
            #endregion
            else
            {
                DialogResult message = MessageBox.Show($"Do you Want to update information of {Team_Label.Text}?!",
            "Warning!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);
                if (message == DialogResult.Yes)
                {
                    Update_InformationDel info = new Update_InformationDel(update.Update_Information);
                    info();
                }
                else
                    MessageBox.Show("Test");
                Add_TeamsDel add = new Add_TeamsDel(update.Add_Teams);
                add();
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClass update = new UpdateClass();
            string team_name = listBox1.SelectedItem.ToString();
            Show_InformationDel info = new Show_InformationDel(update.Show_Information);
            info(team_name);
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            UpdateClass update = new UpdateClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(update.Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            UpdateClass uppdate = new UpdateClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(uppdate.Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateClass update = new UpdateClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(update.Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateClass Update = new UpdateClass();
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(Update.Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
    }
}
