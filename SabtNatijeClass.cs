using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    internal class SabtNatijehClass
    {
        #region add teams
        //add teams
        public void Add_Teams()
        {
            SabtNatijeh_Form sabt = new SabtNatijeh_Form();
            #region add teams
            sabt.Mizban_Listbox.Items.Clear();
            sabt.Mehman_Listbox.Items.Clear();
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
                    sabt.Mizban_Listbox.Items.Add(data_reader["Team_Name"]);
                    sabt.Mehman_Listbox.Items.Add(data_reader["Team_Name"]);
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
        //-----------------------//
        #endregion
        #region mizban win
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
        //-------------------//
        #endregion
        #region mehman win
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
        //------------------//
        #endregion
        #region draw teams
        //draw teams
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
        //--------------//
        #endregion
    }
}
