using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    class Match
    {
        bool finished;
        private Team[] teams= new Team[2];
        private Team winningTeam=null;


        public bool Finished { get { return finished; }}
        int MatchNumber { get; set; }
        public Team[] Teams { get { return teams; } }
        public Team WinningTeam { get { return winningTeam; } set { winningTeam = value;} }


        public Match(int number, Team team1, Team team2) {

            this.MatchNumber = number;
            this.teams[0] = team1;
            this.teams[1] = team2;
            this.winningTeam = team1;
            this.finished = true;
        }

        public override string ToString()
        {
            string take = "";
                if (this.finished == true) {
                take = $"Team {MatchNumber}. {teams[0].Name}:{teams[1].Name}, Winner: {winningTeam.Name} ";
                return take;
            }
            return $"Team {MatchNumber}. {teams[0].Name}:{teams[1].Name} not finished, Winner: {winningTeam.Name} ";
        }
    }
}
