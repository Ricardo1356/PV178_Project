using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentManager.Backend.DTOs;
using TournamentManager.Backend.Structures;

namespace TournamentManager.Backend
{
    public class DataValidationService
    {
        public void ValidatePlayerdata(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name)) throw new ArgumentException("Player name is empty");
            if (string.IsNullOrWhiteSpace(player.Position)) throw new ArgumentException("Player position is empty");
            if (player.Age < 18 || player.Age > 60) throw new ArgumentException("Player age must be between 18 and 60");
            if (player.Height < 150 || player.Height > 220) throw new ArgumentException("Player height must be between 150 and 220");
            if (player.Weight < 50 || player.Weight > 150) throw new ArgumentException("Player weight must be between 50 and 150");
        }

        public void ValidateTeamDataDto(TeamDataDto team)
        {
            if (string.IsNullOrWhiteSpace(team.Name)) throw new ArgumentException("Team name is empty");
            if (string.IsNullOrWhiteSpace(team.City)) throw new ArgumentException("Team city is empty");
            if (string.IsNullOrWhiteSpace(team.Abbrevation)) throw new ArgumentException("Team abbreviation is empty");
            if (team.Abbrevation.Length != 3) throw new ArgumentException("Team abbreviation must be 3 characters long");
            if (team.Colors == null) throw new ArgumentException("Team colors are empty");
            if (team.Colors.TopColor[0] < 0 || team.Colors.TopColor[0] > 255 ||
                team.Colors.TopColor[1] < 0 || team.Colors.TopColor[1] > 255 ||
                team.Colors.TopColor[2] < 0 || team.Colors.TopColor[2] > 255 ||
                team.Colors.TopColor[3] < 0 || team.Colors.TopColor[3] > 255) throw new ArgumentException("Top color values must be within 0 - 255");
            if (team.Colors.BackGroundColor[0] < 0 || team.Colors.BackGroundColor[0] > 255 ||
                team.Colors.BackGroundColor[1] < 0 || team.Colors.BackGroundColor[1] > 255 ||
                team.Colors.BackGroundColor[2] < 0 || team.Colors.BackGroundColor[2] > 255 ||
                team.Colors.BackGroundColor[3] < 0 || team.Colors.BackGroundColor[3] > 255) throw new ArgumentException("Background color values must be within 0 - 255");
            if (team.Colors.BottomColor[0] < 0 || team.Colors.BottomColor[0] > 255 ||
                team.Colors.BottomColor[1] < 0 || team.Colors.BottomColor[1] > 255 ||
                team.Colors.BottomColor[2] < 0 || team.Colors.BottomColor[2] > 255 ||
                team.Colors.BottomColor[3] < 0 || team.Colors.BottomColor[3] > 255) throw new ArgumentException("Bottom color values must be within 0 - 255");

            foreach (var player in team.Players)
            {
                ValidatePlayerdata(player);
            }
        }

        public void ValidateTeamData(Team team)
        {
            ValidateTeamDataDto(new TeamDataDto
            {
                Name = team.Name,
                City = team.City,
                Abbrevation = team.Abbreviation,
                Colors = team.Colors,
                Players = team.Players
            });
        }
    }
}