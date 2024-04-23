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
        private string _previewTeamName = "";
        private string _previewTeamCity = "";
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
                Colors colors = new Colors();
                colors.TopColor = new int[] { TopColorButton.BackColor.A, TopColorButton.BackColor.R, TopColorButton.BackColor.G, TopColorButton.BackColor.B };
                colors.BackGroundColor = new int[] { BackColorButton.BackColor.A, BackColorButton.BackColor.R, BackColorButton.BackColor.G, BackColorButton.BackColor.B };
                colors.BottomColor = new int[] { ButColorButton.BackColor.A, ButColorButton.BackColor.R, ButColorButton.BackColor.G, ButColorButton.BackColor.B };
                bool success = this.Backend.RegisterNewTeam(teamName: NewTeamNameTextBox.Text, teamCity: NewTeamCityTextBox.Text, colors: colors);
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
                    MessageBox.Show($"Failed to import team: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TopColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TopColorButton.BackColor = colorDialog.Color;
                PreviewButton.TopBorderColor = colorDialog.Color;
            }
        }

        private void BackColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColorButton.BackColor = colorDialog.Color;
                PreviewButton.BackgroundColor = colorDialog.Color;
            }
        }

        private void ButColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ButColorButton.BackColor = colorDialog.Color;
                PreviewButton.BottomBorderColor = colorDialog.Color;
            }
        }

        private void NewTeamNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreviewButtonText(name: NewTeamNameTextBox.Text);
        }

        private void UpdatePreviewButtonText(string name="", string city="")
        {
            this._previewTeamName = name == "" ? this._previewTeamName : name;
            PreviewButton.Text = $"{this._previewTeamName}";
        }
    }
}
