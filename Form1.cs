using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //add teams to listbox
        public void Add_Teams()
        {
            #region Add_Teams_to_Listbox
            listBox1.Items.Clear();
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
        //---------------------//
        private void Form1_Load(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
            Add_TeamsDel add = new Add_TeamsDel(Add_Teams);
            add();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SabtNatijeh_Form sabt = new SabtNatijeh_Form();
            sabt.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add_Form add = new Add_Form();
            add.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Update_Form update = new Update_Form();
            update.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Form delete = new Delete_Form();
            delete.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowAll_Form showall = new ShowAll_Form();
            showall.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Add_TeamsDel add = new Add_TeamsDel(Add_Teams);
            add();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
        private void p_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("You Close Analog Clock Form!");
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            Process p = new Process();
            p.Exited += new System.EventHandler(p_Exited);
            p.EnableRaisingEvents = true;
            p.StartInfo.FileName = @"C:\Users\Main user\Desktop\Analog_Clock_On_Form\Analog_Clock_On_Form\bin\Debug\Analog_Clock_On_Form.exe";
            p.Start();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Digital_Clock digital = new Digital_Clock();
            digital.ShowDialog();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Esteghlal")
                pictureBox1.BackgroundImage = Properties.Resources.Esteghlal;
            if (listBox1.SelectedItem.ToString() == "Sepahan")
                pictureBox1.BackgroundImage = Properties.Resources.Sepahan;
            if (listBox1.SelectedItem.ToString() == "Perspolis")
                pictureBox1.BackgroundImage = Properties.Resources.Persepolis;
            if (listBox1.SelectedItem.ToString() == "Havadar")
                pictureBox1.BackgroundImage = Properties.Resources.Havadar;
            if (listBox1.SelectedItem.ToString() == "Naft")
                pictureBox1.BackgroundImage = Properties.Resources.Naft;
            if (listBox1.SelectedItem.ToString() == "Nassaji")
                pictureBox1.BackgroundImage = Properties.Resources.Nassaji;
            if (listBox1.SelectedItem.ToString() == "padideh")
                pictureBox1.BackgroundImage = Properties.Resources.Padideh;
            if (listBox1.SelectedItem.ToString() == "pas")
                pictureBox1.BackgroundImage = Properties.Resources.Pas;
            if (listBox1.SelectedItem.ToString() == "TractorSazi")
                pictureBox1.BackgroundImage = Properties.Resources.Tractorsazi;
            if (listBox1.SelectedItem.ToString() == "Zob Ahan")
                pictureBox1.BackgroundImage = Properties.Resources.Zob_Ahan;
        }
    }
}
