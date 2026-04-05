using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBall_CPT236_LabDBState
{
    public partial class DetailsForm : Form
    {
        public DetailsForm(string name, string abbrev, string capital, long population, string flagDesc, string flower, string bird, 
                           string colors, int medianIncome, double percentCompJobs)
        {
            InitializeComponent();

            lblName.Text = name;
            lblAbbrv.Text = abbrev;
            lblCapital.Text = capital;
            lblPop.Text = population.ToString("N0");
            lblFlag.Text = flagDesc;
            lblFlower.Text = flower;
            lblBird.Text = bird;
            lblColors.Text = colors;
            lblIncome.Text = medianIncome.ToString("N0");
            lblPercentJobs.Text = (percentCompJobs * 100).ToString("0.##") + "%";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
