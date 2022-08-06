using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

                        
/*	     proudly powered by : Md.ImAmUdDiN

       _ +-------------------------------------------+ _
      /o)|      https://www.facebook.com/imamcu07    |(o\
     / / |      https://about.me/imamcu07            | \ \
    ( (_ |  _           HeLpLine=01815-682307     _  | _) )
   ((\ \)+-/o)-----------------------------------(o\-+(/ /))
   (\\\ \_/ /                                     \ \_/ ///)
    \      /                  __                   \      /
     \____/                  |  |                   \____/
              +++++++++++++++++++++++++++++++++++
              +               **                +
              +        Md.ImAmUdDiN             +
              +        Assistant Officer        +
              +       Youngone Group.           +
              +          Korean EPZ             +
              +      Dhaka, Bangladesh.         +
              +++++++++++++++++++++++++++++++++++ 
      ***********************************************************/

namespace Analog_Clock_On_Form
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClockTime obj = new ClockTime();
            panel1.Controls.Add(obj);
        }
    }
}
