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
    public partial class TournamentDashboardForm : Form
    {

        List<TournamentModel> TournamentList = GlobalConfig.Connections.GetAllTournaments();

        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpList();
        }

        private void WireUpList()
        {
            loadExistingTournamentcomboBox.DataSource = null;
            loadExistingTournamentcomboBox.DataSource = TournamentList;
            loadExistingTournamentcomboBox.DisplayMember = "TournamentName";
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentcomboBox.SelectedItem;
            TournamentViewerFrom frm = new TournamentViewerFrom(tm);
            frm.Show();

        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        private void TournamentDashboardForm_Load(object sender, EventArgs e)
        {

        }
    }

    
}
