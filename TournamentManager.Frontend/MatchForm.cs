using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class MatchForm : Form
    {
        private BackendMain Backend;
        private Team Team1;
        private Team Team2;

        public Team Winner { get; set; } = new Team();
        public MatchForm(BackendMain backend, Team team1, Team team2)
        {
            Backend = backend;
            Team1 = team1;
            Team2 = team2;
            Winner = Team1;
            InitializeComponent();
        }


    }
}
