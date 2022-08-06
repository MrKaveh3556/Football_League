using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    internal class UpdateClass
    {
        #region add teams
        public void Add_Teams()
        {
            Update_Form update = new Update_Form();
            #region Add Teams to listbox
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                update.listBox1.Items.Clear();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select Team_Name From Table_Teams";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    update.listBox1.Items.Add(data_reader["Team_Name"]);
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
        #endregion
        #region update information
        public void Update_Information()
        {
            Update_Form update = new Update_Form();
            try
            {
                #region Update_Information
                string team_name = update.Team_Label.Text;
                int win = Convert.ToInt32(update.Win_Textbox.Text);
                int draw = Convert.ToInt32(update.Draw_Textbox.Text);
                int lose = Convert.ToInt32(update.Lose_Textbox.Text);
                int goal_zadeh = Convert.ToInt32(update.Goalzadeh_Textbox.Text);
                int goal_khordeh = Convert.ToInt32(update.Goalkhordeh_Textbox.Text);
                var data = new DataClasses1DataContext();
                data.Update_Team
                (team_name, win, draw, lose, goal_zadeh, goal_khordeh);
                data.Update_Information();
                MessageBox.Show($"Information of {team_name} updated successfully!!");
                #endregion
                #region String.Empty
                update.Team_Label.Text = string.Empty;
                update.Win_Textbox.Text = string.Empty;
                update.Draw_Textbox.Text = string.Empty;
                update.Lose_Textbox.Text = string.Empty;
                update.Goalzadeh_Textbox.Text = string.Empty;
                update.Goalkhordeh_Textbox.Text = string.Empty;
                update.Win_Before_Label.Text = string.Empty;
                update.Draw_Before_Label.Text = string.Empty;
                update.Lose_Before_Label.Text = string.Empty;
                update.Goalzadeh_Before_Label.Text = string.Empty;
                update.Goalkhordeh_Before_Label.Text = string.Empty;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion
        #region show information
        public void Show_Information(string team_name)
        {
            Update_Form update = new Update_Form();
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            try
            {
                #region Show information of team
                update.Team_Label.Text = team_name;
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"Select * From Table_Teams Where Team_Name = N'{team_name}'";
                SqlDataReader data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    update.Win_Before_Label.Text = data_reader["Win"].ToString();
                    update.Draw_Before_Label.Text = data_reader["Draw"].ToString();
                    update.Lose_Before_Label.Text = data_reader["Lose"].ToString();
                    update.Goalzadeh_Before_Label.Text = data_reader["Goal_Zadeh"].ToString();
                    update.Goalkhordeh_Before_Label.Text = data_reader["Goal_Khordeh"].ToString();
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
        #endregion
    }
}
