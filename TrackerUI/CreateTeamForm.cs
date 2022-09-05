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
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {

        List<PersonModel> availableTeamMembers =  GlobalConfig.Connections.GetAllPersone();
        List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        ITeamRequester callingForm;
        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            //  CreateList();
            callingForm = caller;
            WireupList();

        }
        //private void CreateList()
        //{
        //    availableTeamMembers.Add(new PersonModel { FristName="shweta" , LastName="kumavat"});
        //    availableTeamMembers.Add(new PersonModel { FristName = "jksdj", LastName = "kdjf" });
        //}
        private void WireupList() {

            selectTeamMembercomboBox.DataSource = null;
            teamMembersListBox.DataSource = null;
            selectTeamMembercomboBox.DataSource = availableTeamMembers;
            selectTeamMembercomboBox.DisplayMember = "FullName";
            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }
        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel();
                model.FirstName = firstNameText.Text;
                model.LastName = lastNameText.Text;
                model.EmailAddress = emailText.Text;
                model.CellPhoneNumber = cellPhoneText.Text;
               model= GlobalConfig.Connections.CreatePersone(model);
                selectedTeamMembers.Add(model);
                WireupList();
                firstNameText.Text = " ";
                lastNameText.Text = " ";
                cellPhoneText.Text = " ";
                emailText.Text = " ";

            }
            else
            {
                MessageBox.Show("Enter the information");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameText.Text.Length == 0)
            {
                return false;
            }
            if (lastNameText.Text.Length == 0)
            {
                return false;
            }
            if (emailText.Text.Length == 0)
            {
                return false;
            }
            if (cellPhoneText.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void addTeamMemberButton_Click(object sender, EventArgs e)
        {
            

            
            PersonModel p = (PersonModel)selectTeamMembercomboBox.SelectedItem;
            if (p!=null)
            {

                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                WireupList(); 
            }

        }

        private void deleteSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireupList();
            }


        }

        private void createTeamtButton_Click(object sender, EventArgs e)
        {
           
                TeamModel model = new TeamModel();
                model.TeamName = teamNameText.Text;
                model.TeamMembers = selectedTeamMembers;
                GlobalConfig.Connections.CreateTeamModel(model);
            callingForm.TeamCompute(model);
            this.Close();
               
            
        }

       
    }
}
