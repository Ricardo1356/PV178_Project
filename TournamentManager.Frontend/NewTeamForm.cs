﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentManager.Backend;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class NewTeamForm : Form
    {
        private BackendMain Backend;
        private string _previewTeamName = "";
        public NewTeamForm(BackendMain backend)
        {
            this.Backend = backend;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.ShowIcon = false;
            this.Text = "Add New Team";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                TeamDataDto newTeamDto = new TeamDataDto
                {
                    Name = NewTeamNameTextBox.Text,
                    City = NewTeamCityTextBox.Text,
                    Colors = new Colors
                    {
                        TopColor = new int[] { TopColorButton.BackColor.A, TopColorButton.BackColor.R, TopColorButton.BackColor.G, TopColorButton.BackColor.B },
                        BackGroundColor = new int[] { BackColorButton.BackColor.A, BackColorButton.BackColor.R, BackColorButton.BackColor.G, BackColorButton.BackColor.B },
                        BottomColor = new int[] { ButColorButton.BackColor.A, ButColorButton.BackColor.R, ButColorButton.BackColor.G, ButColorButton.BackColor.B }
                    },
                    Abbrevation = TeamAbbrevationTextBox.Text.ToUpper(),
                    Players = new List<Player>()
                };
                Backend.RegisterTeam(teamDataDto: newTeamDto);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create team: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportTeamButton_Click(object sender, EventArgs e)
        {
            ImportDialog<Team>();
        }

        private void MultipleTeamImportButton_Click(object sender, EventArgs e)
        {
            ImportDialog<List<Team>>();
        }

        private void ImportDialog<T>()
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
                    T? imported = JsonSerializer.Deserialize<T>(fileContent);
                    if (imported != null)
                    {
                        List<Team> teams = new List<Team>();
                        if (imported is Team team)
                        {
                            teams.Add(team);
                        }
                        else if (imported is List<Team> teamList)
                        {
                            teams = teamList;
                        }
                        else
                        {
                            throw new Exception();
                        }

                        AddImportedTeams(teams);
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

        private void AddImportedTeams(List<Team> teams)
        {
            foreach (var team in teams)
            {
                try
                {
                    Backend.RegisterTeam(team: team);
                    team.ConvertArgbToColors();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Failed to import team: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UpdatePreviewButtonText(string name = "", string city = "")
        {
            this._previewTeamName = name == "" ? this._previewTeamName : name;
            PreviewButton.Text = $"{this._previewTeamName}";
        }
    }
}
