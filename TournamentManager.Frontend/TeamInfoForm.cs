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
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Frontend
{
    public partial class TeamInfoForm : Form
    {
        private Team team;
        private BackendMain Backend;
        public TeamInfoForm(BackendMain Backend, Team team)
        {
            this.team = team;
            this.Backend = Backend;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.Text = $"Edit {this.team.City} {this.team.Name} info";
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = ShadeColor(team.GetBackColor(), 0.8);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label1.Text = $"{team.City}";
            label2.Text = $"{team.Name}";
            BackColorButton.BackColor = Color.FromArgb(team.Colors.BackGroundColor[0], team.Colors.BackGroundColor[1], team.Colors.BackGroundColor[2], team.Colors.BackGroundColor[3]);
            TopColoruButton.BackColor = Color.FromArgb(team.Colors.TopColor[0], team.Colors.TopColor[1], team.Colors.TopColor[2], team.Colors.TopColor[3]);
            BotColorButton.BackColor = Color.FromArgb(team.Colors.BottomColor[0], team.Colors.BottomColor[1], team.Colors.BottomColor[2], team.Colors.BottomColor[3]);
            NewNameEditTextBox.Text = team.Name;
            NewCityEditTextBox.Text = team.City;
            NewAbbEditTextBox.Text = team.Abbreviation;

            RepositionLabels();
            this.TeamPreviewButton.UpdateColorsByTeam(team);
            this.TeamPreviewButton.Text = team.Name;
            this.NewNameEditTextBox.TextChanged += NewNameEditTextBox_TextChanged;
            this.NewCityEditTextBox.TextChanged += NewCityEditTextBox_TextChanged;
            this.BackColorButton.Click += BackColorButton_Click;
            this.TopColoruButton.Click += TopColoruButton_Click;
            this.BotColorButton.Click += ButColorButton_Click;
        }

        private Color ShadeColor(Color originalColor, double shadeFactor)
        {
            int red = (int)(originalColor.R + (255 - originalColor.R) * shadeFactor);
            int green = (int)(originalColor.G + (255 - originalColor.G) * shadeFactor);
            int blue = (int)(originalColor.B + (255 - originalColor.B) * shadeFactor);

            return Color.FromArgb(red, green, blue);
        }

        private void BackColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColorButton.BackColor = colorDialog.Color;
            }
            UpdateAfter();
        }

        private void TopColoruButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TopColoruButton.BackColor = colorDialog.Color;
            }
            UpdateAfter();
        }

        private void ButColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BotColorButton.BackColor = colorDialog.Color;
            }
            UpdateAfter();
        }

        private void NewCityEditTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAfter();
        }

        private void NewNameEditTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateAfter();
        }

        private void RepositionLabels()
        {
            label2.Left = label1.Left + label1.Width;
        }

        private void TICancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TISaveButton_Click(object sender, EventArgs e)
        {

            TeamDataDto teamDataDto = new TeamDataDto
            {
                Name = NewNameEditTextBox.Text,
                City = NewCityEditTextBox.Text,
                Colors = new Colors
                {
                    TopColor = new int[] { TopColoruButton.BackColor.A, TopColoruButton.BackColor.R, TopColoruButton.BackColor.G, TopColoruButton.BackColor.B },
                    BackGroundColor = new int[] { BackColorButton.BackColor.A, BackColorButton.BackColor.R, BackColorButton.BackColor.G, BackColorButton.BackColor.B },
                    BottomColor = new int[] { BotColorButton.BackColor.A, BotColorButton.BackColor.R, BotColorButton.BackColor.G, BotColorButton.BackColor.B }
                },
                Abbrevation = NewAbbEditTextBox.Text.ToUpper(),
                Players = new List<Player>()
            };

            try
            {
                Backend.UpdateTeamInfo(teamDataDto, team);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update team: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAfter()
        {
            this.label1.Text = NewCityEditTextBox.Text;
            this.label2.Text = NewNameEditTextBox.Text;
            this.TeamPreviewButton.Text = NewNameEditTextBox.Text;
            this.TeamPreviewButton.SetButtonColors(BackColorButton.BackColor, TopColoruButton.BackColor, BotColorButton.BackColor); 
            RepositionLabels();
        }
    }
}
