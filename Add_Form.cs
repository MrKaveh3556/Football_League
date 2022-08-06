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
    public partial class Add_Form : Form
    {
        public Add_Form()
        {
            InitializeComponent();
        }
        //delegates
        public delegate void Insert_TeamDel();
        //---------------------//
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8) && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8) && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8) && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8) && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8) && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
                && e.KeyChar < '0' || e.KeyChar > '9'
                && e.KeyChar < 'a' || e.KeyChar > 'z'
                    && e.KeyChar < 'A' || e.KeyChar > 'Z')
                e.Handled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region Error_Manage
            if (Team_Name.Text == string.Empty)
                errorProvider1.SetError(Team_Name, "Please Fill this field :(");
            if (Win.Text == string.Empty)
                errorProvider2.SetError(Win, "Please Fill this field :(");
            if (Draw.Text == string.Empty)
                errorProvider3.SetError(Draw, "Please Fill this field :(");
            if (Lose.Text == string.Empty)
                errorProvider4.SetError(Lose, "Please Fill this field :(");
            if (Goal_Zadeh.Text == string.Empty)
                errorProvider5.SetError(Goal_Zadeh, "Please Fill this field :(");
            if (Goal_Khordeh.Text == string.Empty)
                errorProvider6.SetError(Goal_Khordeh, "Please Fill this field :(");

            if (Team_Name.Text == string.Empty
            || Win.Text == string.Empty
            || Draw.Text == string.Empty
            || Lose.Text == string.Empty
            || Goal_Zadeh.Text == string.Empty
            || Goal_Khordeh.Text == string.Empty)
                MessageBox.Show("Please fill all field :((");
            #endregion
            else
            {
                DialogResult message = MessageBox.Show($"Do you Want to Add {Team_Name.Text}?!",
                "Warning!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
                if (message == DialogResult.Yes)
                {
                    try
                    {
                        AddClass add_class = new AddClass();
                        Insert_TeamDel insert_team = new Insert_TeamDel(add_class.Insert_Team);
                        insert_team();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }
                }
                else
                    MessageBox.Show("Operation canceled :)");
            }
        }
        private void Add_Form_FormClosing(object sender, FormClosingEventArgs e)
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
