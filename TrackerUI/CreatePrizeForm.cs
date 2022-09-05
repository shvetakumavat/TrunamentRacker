using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IprizeRequester callingForm;
        public CreatePrizeForm(IprizeRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
        }

       

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameText.Text,
                    placeNumberText.Text,
                    prizeAmountText.Text,
                    prizePercentageText.Text);

                GlobalConfig.Connections.CreatePrize(model);
                callingForm.PrizeCompute(model);
                placeNameText.Text = " ";
                placeNumberText.Text = " ";
                prizeAmountText.Text = "0";
                prizePercentageText.Text = "0";
                this.Close();

            }
            else
            {
                MessageBox.Show("this form has invalid information. Please check it and try again");
            }
        }
        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidateNumber = int.TryParse(placeNumberText.Text, out placeNumber);
            if (placeNumberValidateNumber == false)
            {
                output = false;
            }
            if (placeNumber < 1)
            {
                output = false;
            }
            if (placeNameText.Text.Length == 0)
            {
                output = false;
            }
            decimal prizeAmount = 0;
            double prizePercentage = 0;
            bool prizeAmountValideNumber = decimal.TryParse(prizeAmountText.Text, out prizeAmount);
            bool prizePercentageValidNumber = double.TryParse(prizePercentageText.Text, out prizePercentage);

            if (prizeAmountValideNumber == false || prizePercentageValidNumber ==false)
            {
                output = false;
            }
            if (prizeAmount <= 0 || prizePercentage <= 0)
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            return output;
        }
    }
}
