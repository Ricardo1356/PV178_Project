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

namespace TournamentManager.Frontend
{
    public partial class NewTeamForm : Form
    {
        private BackendMain Backend;
        public NewTeamForm(BackendMain backend)
        {
            this.Backend = backend;
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (NewTeamNameTextBox.Text == "")
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NewTeamCityTextBox.Text == "")
            {
                MessageBox.Show("City cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool success = this.Backend.RegisterNewTeam(NewTeamNameTextBox.Text, NewTeamCityTextBox.Text);
                if (!success)
                {
                    MessageBox.Show("Team already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
