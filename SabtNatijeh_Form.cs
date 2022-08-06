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
    public partial class SabtNatijeh_Form : Form
    {
        public SabtNatijeh_Form()
        {
            InitializeComponent();
        }
        //add teams to listbox
        public void Add_Teams()
        {
            #region add teams
            Mizban_Listbox.Items.Clear();
            Mehman_Listbox.Items.Clear();
            string connection_string =
            "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select Team_Name From Table_Teams";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    Mizban_Listbox.Items.Add(data_reader["Team_Name"]);
                    Mehman_Listbox.Items.Add(data_reader["Team_Name"]);
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
        //-----------------------//
        //mizban win
        public void Mizban(string mizban_team, string mehman_team, int mizban_goal, int mehman_goal)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            #region mizban
            try
            {
                data.Mizban_Win(mizban_team, mizban_goal, mehman_goal);
                data.Mehman_Lose(mehman_team, mehman_goal, mizban_goal);
                data.Update_Information();
                MessageBox.Show
                ($"Win for {mizban_team}!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            #endregion            
        }
        public delegate void MizbanDel(string mizban_team, string mehman_team, int mizban_goal, int mehman_goal);
        //----------//
        //mehman win
        public void Mehman(string mizban_team, string mehman_team, int mizban_goal, int mehman_goal)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            #region mehman
            try
            {
                data.Mehman_Win(mehman_team, mehman_goal, mizban_goal);
                data.Mizban_Lose(mizban_team, mizban_goal, mehman_goal);
                data.Update_Information();
                MessageBox.Show
                ($"Win for {mehman_team}!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            #endregion
        }
        public delegate void MehmanDel(string mizban_team, string mehman_team, int mizban_goal, int mehman_goal);
        //----------//
        //draw
        public void Draw(string mizban_team, string mehman_team, int mizban_goal)
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            #region draw
            try
            {
                data.Draw_Teams(mizban_team, mehman_team, mizban_goal);
                data.Update_Information();
                MessageBox.Show
                ($"The game had no winner:(");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            #endregion
        }
        public delegate void DrawDel(string mizban_team, string mehman_team, int mizban_goal);
        //----------//
        //empty controls
        public void Empty()
        {
            #region Empty
            Mizban_Label.Text = string.Empty;
            Mehman_Label.Text = string.Empty;
            Mizban_Textbox.Text = string.Empty;
            Mehman_Textbox.Text = string.Empty;
            Mizban_Listbox.SelectedIndex = -1;
            Mehman_Listbox.SelectedIndex = -1;
            #endregion
        }
        public delegate void EmptyDel();
        //----------------//
        private void SabtNatijeh_Form_Load(object sender, EventArgs e)
        {
            Add_TeamsDel add = new Add_TeamsDel(Add_Teams);
            add();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(8)
            && e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            #region Error Manage
            if (Mizban_Label.Text == Mehman_Label.Text)
                MessageBox.Show("Please do not select same teams:(");

            else if (Mizban_Label.Text == string.Empty
            || Mehman_Label.Text == string.Empty)
                MessageBox.Show("Please select team from both lists:(");

            else if (Mizban_Textbox.Text == string.Empty
            || Mehman_Textbox.Text == string.Empty)
                MessageBox.Show("Please Enter score for both Teams:((");
            #endregion
            else
            {
                string mizban_team = Mizban_Label.Text;
                string mehman_team = Mehman_Label.Text;
                int mizban_goal = Convert.ToInt32(Mizban_Textbox.Text);
                int mehman_goal = Convert.ToInt32(Mehman_Textbox.Text);
                DialogResult message = MessageBox.Show($"Do you Want to confirm scores?! ?!",
                "Warning!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
                if (message == DialogResult.Yes)
                {
                    #region Mizban_Win
                    if (mizban_goal > mehman_goal)
                    {
                        MizbanDel mizban = new MizbanDel(Mizban);
                        mizban(mizban_team, mehman_team, mizban_goal, mehman_goal);
                    }
                    #endregion
                    #region Mehman_Win
                    if (mizban_goal < mehman_goal)
                    {
                        MehmanDel mehman = new MehmanDel(Mehman);
                        mehman(mizban_team, mehman_team, mizban_goal, mehman_goal);
                    }
                    #endregion
                    #region Draw
                    if (mizban_goal == mehman_goal)
                    {
                        DrawDel draw = new DrawDel(Draw);
                        draw(mizban_team, mehman_team, mizban_goal);
                    }
                    #endregion
                    EmptyDel empty = new EmptyDel(Empty);
                    empty();
                }
                else
                    MessageBox.Show("Operation canceled :)");
            }
        }
        private void Mizban_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Mizban_Listbox.SelectedIndex != -1)
                    Mizban_Label.Text = Mizban_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mehman_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Mehman_Listbox.SelectedIndex != -1)
                    Mehman_Label.Text = Mehman_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mizban_Listbox_Click(object sender, EventArgs e)
        {
            try
            {
                Mizban_Label.Text = Mizban_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mizban_Listbox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Mizban_Label.Text = Mizban_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mehman_Listbox_Click(object sender, EventArgs e)
        {
            try
            {
                Mehman_Label.Text = Mehman_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mehman_Listbox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Mehman_Label.Text = Mehman_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mehman_Listbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Mehman_Label.Text = Mehman_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void Mizban_Listbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Mizban_Label.Text = Mizban_Listbox.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select the team :((");
            }
        }
        private void SabtNatijeh_Form_FormClosing(object sender, FormClosingEventArgs e)
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
