using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    internal class MainClass
    {
        #region add teams
        public void Add_Teams()
        {
            Main_Form main = new Main_Form();
            #region Add_Teams_to_Listbox
            main.listBox1.Items.Clear();
            string connection_string = "Server = DESKTOP-P6H6MF5; Database = Football_League; User Id = MrKaveh; Password = Breaking355662Bad;";
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
                    main.listBox1.Items.Add(data_reader["Team_Name"]);
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
    }
}
