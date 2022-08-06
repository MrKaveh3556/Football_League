using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    internal class DeleteClass
    {
        #region add teams
        //add teams
        public void Add_Teams()
        {
            Delete_Form delete_form = new Delete_Form();
            #region Add Teams to listbox
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                delete_form.listBox1.Items.Clear();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select Team_Name From Table_Teams";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    delete_form.listBox1.Items.Add(data_reader["Team_Name"]);
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
        //---------------//
        #endregion
        #region delete team
        //delete team
        public void Delete_Team()
        {
            Delete_Form delete_form = new Delete_Form();
            #region Delete_Team
            string team_name = delete_form.TeamName.Text;
            var data = new DataClasses1DataContext();
            data.Delete_Team(team_name);
            MessageBox.Show($"{team_name} Deleted successfully!!");
            #endregion
        }
        //---------------------//
        #endregion
        #region show information
        //show informations of teams in labels
        public void Information(string team_name)
        {
            Delete_Form delete_form = new Delete_Form();
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
                    delete_form.TeamName.Text = data_reader["Team_Name"].ToString();
                    delete_form.Tedad_Bazi.Text = data_reader["Tedad_Bazi"].ToString();
                    delete_form.Win.Text = data_reader["Win"].ToString();
                    delete_form.Draw.Text = data_reader["Draw"].ToString();
                    delete_form.Lose.Text = data_reader["Lose"].ToString();
                    delete_form.Point.Text = data_reader["Point"].ToString();
                    delete_form.Goalzadeh.Text = data_reader["Goal_Zadeh"].ToString();
                    delete_form.Goalkhordeh.Text = data_reader["Goal_Khordeh"].ToString();
                    delete_form.Tafazol.Text = data_reader["Tafazol"].ToString();
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
        //--------------------------------------------//
        #endregion
    }
}
