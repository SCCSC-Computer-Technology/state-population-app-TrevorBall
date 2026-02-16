using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBall_CPT236_LabDBState.Library;

namespace TBall_CPT236_LabDBState
{
    public partial class TBall_StateDB_Lab3 : Form
    {

        //Library Object
        private StateService _service;

        public TBall_StateDB_Lab3()
        {
            InitializeComponent();
        }

        private void stateDBTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stateDBTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stateDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _service = new StateService(this.stateDBTableTableAdapter);
            _service.LoadAll(this.stateDBDataSet.StateDBTable);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using the program!!");
            //closes program
            this.Close();
        }

        private void btnNameAsc_Click(object sender, EventArgs e)
        {
            //sort by name ascending
            try
            {
                _service.SortNameAsc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnPopAsc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by population ascending
                _service.SortPopAsc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnNameDesc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by Name Descending
                _service.SortNameDesc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnPopDesc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by population descending
                _service.SortPopDesc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnCapAsc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by Capitol ascending
                _service.SortCapAsc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnCapDesc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by sorts by Capitol Descending
                _service.SortCapDesc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnIncAsc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by income ascending
                _service.SortIncAsc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnIncDesc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by income Descending
                _service.SortIncDesc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnPercAsc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by Percent Computer Jobs ascending
                _service.SortPercAsc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnPercDesc_Click(object sender, EventArgs e)
        {
            try
            {
                //sorts by Percent Computer Jobs Descending
                _service.SortPercDesc(this.stateDBDataSet.StateDBTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sorted data: " + ex.Message);
            }
        }

        private void btnTotalPop_Click(object sender, EventArgs e)
        {
            try
            {
                long total = _service.GetTotalPop();
                MessageBox.Show("Total population: " + total.ToString("N0"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting total population: " + ex.Message);
            }
        }

        private void btnAveragePop_Click(object sender, EventArgs e)
        {
            try
            {
                long avg = _service.GetAveragePop();
                MessageBox.Show("Average population: " + avg.ToString("N0"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting average population: " + ex.Message);
            }
        }

        private void btnMaxPop_Click(object sender, EventArgs e)
        {
            try
            {
                double? max = _service.GetMaxPop();
                if (max.HasValue)
                    MessageBox.Show("Maximum population: " + max.Value.ToString("N0"));
                else
                    MessageBox.Show("No max population found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting max population: " + ex.Message);
            }
        }

        private void btnMinPop_Click(object sender, EventArgs e)
        {
            try
            {
                double? min = _service.GetMinPop();
                if (min.HasValue)
                    MessageBox.Show("Minimum population: " + min.Value.ToString("N0"));
                else
                    MessageBox.Show("No min population found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting min population: " + ex.Message);
            }
        }

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            if (comboStates.SelectedItem == null)
            {
                MessageBox.Show("Select a state first.");
                return;
            }

            DataRowView State = comboStates.SelectedItem as DataRowView;
            if (State == null)
            {
                MessageBox.Show("Selection error.");
                return;
            }

            string name = State["Name"].ToString();
            string abbrev = State["Abbreviation"].ToString();
            string capital = State["Capitol"].ToString();
            long population = Convert.ToInt64(State["Population"]);
            string flagDesc = State["FlagDescription"].ToString();
            string flower = State["StateFlower"].ToString();
            string bird = State["StateBird"].ToString();
            string colors = State["Colors"].ToString();
            int medianIncome = Convert.ToInt32(State["MedianIncome"]);
            double percentJobs = Convert.ToDouble(State["PercentCompJobs"]);

            using (DetailsForm newForm = new DetailsForm(name, abbrev, capital, population,
                                           flagDesc, flower, bird, colors,
                                           medianIncome, percentJobs))
            {
                newForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //calls apply filter method below
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string text = tbSearchBox.Text.Trim();

            try
            {

                // If nothing typed it shows all records again
                if (text.Length == 0)
                {
                    stateDBTableBindingSource.RemoveFilter();
                    return;
                }

                // Filters by Name, Abbreviation, or Capitol
                stateDBTableBindingSource.Filter = $"Name LIKE '%{text}%' OR Abbreviation LIKE '%{text}%' OR Capitol LIKE '%{text}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred: {ex}.  Make sure to not include a single quote, double quote, or a bracket!");
            }

        }

    }
}
