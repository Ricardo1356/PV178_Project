﻿using System.Runtime.CompilerServices;

namespace TournamentManager.Backend.Structures
{
    public class Tournament
    {
        public TournamentType Type { get; private set; }
        public int TeamCount { get; private set; }
        public List<Team> ParticipatingTeams { get; private set; }
        public Tournament(TournamentType type, int teamCount, List<Team> teams)
        {
            this.Type = type;
            this.TeamCount = teamCount;
            this.ParticipatingTeams = teams;
        }

        public void ShuffleTeams()
        {
            Random random = new Random();
            this.ParticipatingTeams = this.ParticipatingTeams.OrderBy(item => random.Next()).ToList();
        }
    }
}
