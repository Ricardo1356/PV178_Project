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
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class NewPlayerForm : Form
    {
        private BackendMain Backend;
        private Team team;
        public NewPlayerForm(BackendMain backend, Team team)
        {
            this.team = team;
            this.Backend = backend;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            this.ShowIcon = false;
            this.Text = "Add New Player";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void SaveAndExitButton_Click(object sender, EventArgs e)
        {
            this.AddPlayer(false);
        }

        private void AddNotherPlayerButton_Click(object sender, EventArgs e)
        {
            this.AddPlayer(true);
            this.Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateStatsButton_Click(object sender, EventArgs e)
        {
            PlayerDataDto stats = Backend.GeneratePlayerStats();

            this.PlayerNameTextBox.Text = stats.Name;
            this.PlayerAgeTextBox.Text = stats.Age;
            this.PlayerHeightTextBox.Text = stats.Height;
            this.PlayerWeightTextBox.Text = stats.Weight;
            this.PlayerPositionComboBox.SelectedIndex = stats.Position;
        }

        private void AddPlayer(bool another)
        {
            try
            {
                Player player = new Player(this.PlayerNameTextBox.Text,
                                           int.Parse(this.PlayerAgeTextBox.Text),
                                           int.Parse(this.PlayerHeightTextBox.Text),
                                           int.Parse(this.PlayerWeightTextBox.Text),
                                           this.PlayerPositionComboBox.SelectedItem.ToString());

                Backend.AddPlayerToTeam(this.team, player);
                if (!another)
                {
                    this.Close();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in all fields correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            this.PlayerNameTextBox.Text = "";
            this.PlayerAgeTextBox.Text = "";
            this.PlayerHeightTextBox.Text = "";
            this.PlayerWeightTextBox.Text = "";
            this.PlayerPositionComboBox.SelectedItem = null;
        }

        private void ImportMultiplePlayersButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Import Players";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    List<Player>? players = JsonSerializer.Deserialize<List<Player>>(fileContent);

                    if (players != null)
                    {
                        foreach (var player in players)
                        {
                            try
                            {
                                Backend.AddPlayerToTeam(this.team, player);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to import players: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The file is not a valid team JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Failed to parse the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
