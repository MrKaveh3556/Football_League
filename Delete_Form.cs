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
        //--------------------//
        //delete team
        public void Delete_Team()
        {
            #region Delete_Team
            string team_name = TeamName.Text;
            var data = new DataClasses1DataContext();
            data.Delete_Team(team_name);
            MessageBox.Show($"{team_name} Deleted successfully!!");
            #endregion
        }
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
        //show informations of teams in labels
        public void Information(string team_name)
        {
            #region Show information of selected team in labels
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * From Table_Teams Where Team_Name = N'{team_name}'";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    TeamName.Text = data_reader["Team_Name"].ToString();
                    Tedad_Bazi.Text = data_reader["Tedad_Bazi"].ToString();
                    Win.Text = data_reader["Win"].ToString();
                    Draw.Text = data_reader["Draw"].ToString();
                    Lose.Text = data_reader["Lose"].ToString();
                    Point.Text = data_reader["Point"].ToString();
                    Goalzadeh.Text = data_reader["Goal_Zadeh"].ToString();
                    Goalkhordeh.Text = data_reader["Goal_Khordeh"].ToString();
                    Tafazol.Text = data_reader["Tafazol"].ToString();
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
        public delegate void InformationDel(string team_name);
        //-------------------------------------//
        private void Delete_Form_Load(object sender, EventArgs e)
        {
            Add_TeamsDel add_team = new Add_TeamsDel(Add_Teams);
            add_team();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show($"Do you Want to Delete {TeamName.Text}?!",
            "Warning!",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);
            if (message == DialogResult.Yes)
            {
                try
                {
                    Delete_TeamDel delete = new Delete_TeamDel(Delete_Team);
                    delete();
                    Add_TeamsDel add_team = new Add_TeamsDel(Add_Teams);
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
            string team_name = listBox1.SelectedItem.ToString();
            InformationDel info = new InformationDel(Information);
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
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                InformationDel info = new InformationDel(Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show("Please select team from list :((");
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string team_name = listBox1.SelectedItem.ToString();
                InformationDel info = new InformationDel(Information);
                info(team_name);
            }
            catch
            {
                MessageBox.Show("Please select team from list :((");
            }
        }
    }
}
