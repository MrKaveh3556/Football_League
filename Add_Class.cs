using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_League
{
    internal class AddClass
    {
        //insert team
        public void Insert_Team()
        {
            Add_Form add_form = new Add_Form();
            #region Insert_Team
            string team_name = add_form.Team_Name.Text;
            int win = Convert.ToInt32(add_form.Win.Text);
            int draw = Convert.ToInt32(add_form.Draw.Text);
            int lose = Convert.ToInt32(add_form.Lose.Text);
            int goal_zadeh = Convert.ToInt32(add_form.Goal_Zadeh.Text);
            int goal_khordeh = Convert.ToInt32(add_form.Goal_Khordeh.Text);
            var data = new DataClasses1DataContext();
            data.Insert_Team(team_name);
            data.Update_Team(team_name, win, draw, lose, goal_zadeh, goal_khordeh);
            data.Update_Information();
            MessageBox.Show($"{team_name} added successfully!!");
            #endregion
            #region String.Empty
            add_form.Team_Name.Text = string.Empty;
            add_form.Win.Text = string.Empty;
            add_form.Draw.Text = string.Empty;
            add_form.Lose.Text = string.Empty;
            add_form.Goal_Zadeh.Text = string.Empty;
            add_form.Goal_Khordeh.Text = string.Empty;
            #endregion
        }
        //-----------//
    }
}
