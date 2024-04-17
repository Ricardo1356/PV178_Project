using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.Structures;

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
                bool success = this.Backend.RegisterNewTeam(teamName: NewTeamNameTextBox.Text, teamCity: NewTeamCityTextBox.Text);
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

        private void ImportTeamButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Import Team";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    Team importedTeam = JsonSerializer.Deserialize<Team>(fileContent);
                    MessageBox.Show($"{importedTeam.Players.Count()}");

                    if (importedTeam != null)
                    {
                        bool success = Backend.RegisterNewTeam(team: importedTeam);
                        if (!success)
                        {
                            MessageBox.Show("Team already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        { 
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file is not a valid team JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle potential errors, such as invalid JSON format
                    MessageBox.Show($"Failed to import team: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
