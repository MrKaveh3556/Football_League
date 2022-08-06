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
        public void Add_Teams()
        {
            #region Add Teams to listbox
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                listBox1.Items.Clear();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select Team_Name From Table_Teams";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    listBox1.Items.Add(data_reader["Team_Name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            #endregion
        }
        public delegate void Add_TeamsDel();
        //----------------------//
        //update information
        public void Update_Information()
        {
            try
            {
                #region Update_Information
                string team_name = Team_Label.Text;
                int win = Convert.ToInt32(Win_Textbox.Text);
                int draw = Convert.ToInt32(Draw_Textbox.Text);
                int lose = Convert.ToInt32(Lose_Textbox.Text);
                int goal_zadeh = Convert.ToInt32(Goalzadeh_Textbox.Text);
                int goal_khordeh = Convert.ToInt32(Goalkhordeh_Textbox.Text);
                var data = new DataClasses1DataContext();
                data.Update_Team
                (team_name, win, draw, lose, goal_zadeh, goal_khordeh);
                data.Update_Information();
                MessageBox.Show($"Information of {team_name} updated successfully!!");
                #endregion
                #region String.Empty
                Team_Label.Text = string.Empty;
                Win_Textbox.Text = string.Empty;
                Draw_Textbox.Text = string.Empty;
                Lose_Textbox.Text = string.Empty;
                Goalzadeh_Textbox.Text = string.Empty;
                Goalkhordeh_Textbox.Text = string.Empty;
                Win_Before_Label.Text = string.Empty;
                Draw_Before_Label.Text = string.Empty;
                Lose_Before_Label.Text = string.Empty;
                Goalzadeh_Before_Label.Text = string.Empty;
                Goalkhordeh_Before_Label.Text = string.Empty;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        public delegate void Update_InformationDel();
        //------------------//
        //show information of teams
        public void Show_Information(string team_name)
        {
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                #region Show information of team
                Team_Label.Text = team_name;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * From Table_Teams Where Team_Name = N'{team_name}'";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    Win_Before_Label.Text = data_reader["Win"].ToString();
                    Draw_Before_Label.Text = data_reader["Draw"].ToString();
                    Lose_Before_Label.Text = data_reader["Lose"].ToString();
                    Goalzadeh_Before_Label.Text = data_reader["Goal_Zadeh"].ToString();
                    Goalkhordeh_Before_Label.Text = data_reader["Goal_Khordeh"].ToString();
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        public delegate void Show_InformationDel(string team_name);
        //---------------------------//
        private void Update_Form_Load(object sender, EventArgs e)
        {
            Add_TeamsDel add = new Add_TeamsDel(Add_Teams);
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
                    Update_InformationDel info = new Update_InformationDel(Update_Information);
                    info();
                }
                else
                    MessageBox.Show("Test");
                Add_TeamsDel add = new Add_TeamsDel(Add_Teams);
                add();
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string team_name = listBox1.SelectedItem.ToString();
            Show_InformationDel info = new Show_InformationDel(Show_Information);
            info(team_name);
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(Show_Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show($"Please Select team from list:((");
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                Show_InformationDel info = new Show_InformationDel(Show_Information);
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
