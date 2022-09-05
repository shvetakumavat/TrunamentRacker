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
    public partial class CreateTournamentForm : Form,IprizeRequester,ITeamRequester
    {

        List<TeamModel> availableTeams = GlobalConfig.Connections.GetAllTeams();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> prizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireupList();
        }

        private void WireupList()
        {
            selectTeamcomboBox.DataSource = null;
            selectTeamcomboBox.DataSource = availableTeams;
            selectTeamcomboBox.DisplayMember = "TeamName";

            tournamentPlayersListBox.DataSource = null;
            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";

            prizeslistBox.DataSource = null;
            prizeslistBox.DataSource = prizes;
            prizeslistBox.DisplayMember = "PlaceName";



        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)selectTeamcomboBox.SelectedItem;
            if (team != null)
            {
                availableTeams.Remove(team);
                selectedTeams.Add(team);
                WireupList();
            }
        }

        private void deleteSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel P = (PrizeModel)prizeslistBox.SelectedItem;
            if (P != null)
            {
                prizes.Remove(P);
                WireupList();
            }
        }

        private void deleteSelectedPlayersButton_Click(object sender, EventArgs e)
        {

            TeamModel team = (TeamModel)tournamentPlayersListBox.SelectedItem;
            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);
                WireupList();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //call creatprize from
            //get back from the form a prize model 
            // tack prize model and put it into selected prize list box
            CreatePrizeForm prizefrm = new CreatePrizeForm(this);
            prizefrm.Show();

        }

        public void PrizeCompute(PrizeModel model)
        {
            prizes.Add(model);
            WireupList();
        }

        private void createTeamlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamfrm = new CreateTeamForm(this);
            teamfrm.Show();
        }

        public void TeamCompute(TeamModel model)
        {
            selectedTeams.Add(model);
            WireupList();
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal entryFee = 0;
            bool validfee = decimal.TryParse(entryFeeText.Text, out entryFee);
            if (!validfee)
            {
                MessageBox.Show("you nee to enter the valid entry fee");
                return;
            }
            // create tournament model

            TournamentModel model = new TournamentModel();
            model.TournamentName = tournamentNameText.Text;
            model.EntryFee = entryFee;
            model.EnteredTeams = selectedTeams;
            model.Prizes = prizes;
            TournamentLogic.CreateRound(model);
            GlobalConfig.Connections.CreateTournament(model);
            //create tournament Entry
            //create prize entries 
            //create team entries
            //create matchup entries
        }
    }
}
