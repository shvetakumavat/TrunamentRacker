﻿using System;
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
    public partial class TournamentViewerFrom : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerFrom(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

           // tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

            WireUpLists();

            LoadFormData();

            LoadRounds();
        }

        //private void Tournament_OnTournamentComplete(object sender, DateTime e)
        //{
        //    this.Close();
        //}

        private void LoadFormData()
        {
            TournamentNameLable.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            roundComboBox.DataSource = rounds;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();

            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }

            LoadMatchups(1);
        }

        private void LoadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.winner == null || !UnplayedOnlyCheackBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private string ValidateData()
        {
            string output = "";
            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(teamOneScoreTex.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamTwoScoreText.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The score one value is not a valid number";
            }
            else if (!scoreTwoValid)
            {
                output = "The score two value is not a valid number";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "You did not enter a score for either team";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties in this application";
            }

            return output;
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            string errorMessage = ValidateData();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show($"Input Error: { errorMessage }");
                return;
            }

            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            m.Entries[0].TeamCompeting.TeamName = teamOneLable.Text;

                            bool scoreValid = double.TryParse(teamOneScoreTex.Text, out teamOneScore);
                            if (scoreValid)
                            {
                                m.Entries[0].score = teamOneScore;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid score for team 1.");
                                return;
                            }

                        }
                        else
                        {
                            teamOneLable.Text = "Not Yet Set";
                            teamOneScoreTex.Text = "";
                        }
                    }

                    if (i == 1)
                    {
                        if (m.Entries[1].TeamCompeting != null)
                        {
                            bool scoreValid = double.TryParse(teamTwoScoreText.Text, out teamTwoScore);
                            if (scoreValid)
                            {
                                m.Entries[1].score = teamTwoScore;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid score for team 2.");
                                return;
                            }
                        }
                        else
                        {
                            teamTwoLable.Text = "Not Yet Set";
                            teamTwoScoreText.Text = "";
                        }
                    }
                }

                //try
                //{
                //    int currentRound = TournamentLogic.CheckCurrentRound(tournament);
                //    int lastRound = rounds.Last();

                //    TournamentLogic.UpdateTournamentResults(tournament);

                //    if (currentRound == lastRound)
                //    {
                //        TournamentResultForm form = new TournamentResultForm();
                //        form.Show();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"The application had the following error: {ex.Message }");
                //    return;
                //}

                LoadMatchups((int)roundComboBox.SelectedItem);
            }
        }

        private void roundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundComboBox.SelectedItem);
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamOneLable.Visible = isVisible;
            teamOneScoreLable.Visible = isVisible;
            teamOneScoreTex.Visible = isVisible;
            teamTwoLable.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreText.Visible = isVisible;
            VersusLable.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            teamOneLable.Text = m.Entries[0].TeamCompeting.TeamName;
                            teamOneScoreTex.Text = m.Entries[0].score.ToString();

                            teamTwoLable.Text = "<bye>";
                            teamTwoScoreText.Text = "0";
                        }
                        else
                        {
                            teamOneLable.Text = "Not Yet Set";
                            teamOneScoreTex.Text = "";
                        }
                    }

                    if (i == 1)
                    {
                        if (m.Entries[1].TeamCompeting != null)
                        {
                            teamTwoLable.Text = m.Entries[1].TeamCompeting.TeamName;
                            teamTwoScoreText.Text = m.Entries[1].score.ToString();
                        }
                        else
                        {
                            teamTwoLable.Text = "Not Yet Set";
                            teamTwoScoreText.Text = "";
                        }
                    }
                }
            }
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
        }

        private void UnplayedOnlyCheackBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundComboBox.SelectedItem);
        }
    }
}