using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    class KnockoutTournament:Tournament
    {

        List<Team> availableTeams;
        int noOfMatches = 0;
        Random random = new Random(1);
        public KnockoutTournament(string Name) : base(Name) { }
        public override void AddWinner(Team winner, Team loser) {
            if (Matches.Count >= 1)
            {
                Match win = FindMach(winner, loser);
                win.Teams[0] = winner;
                win.WinningTeam = winner;
                win.Teams[1] = loser;
                availableTeams.Add(winner);
                Matches.Remove(win);
                // resets matches function there are no more matches
                if (Matches.Count == 0)
                {
                    SetMatches();
                }
            }
        }
        public override void SetMatches()
        {
            Matches.Clear();
            int matchNum = 1; 
            if (noOfMatches == 0)
            {
                availableTeams = Teams;
            }

            while (availableTeams.Count >= 2) {
              
                int randV = random.Next(0, availableTeams.Count -1);
                Team tempTeam1 = availableTeams[randV];
                availableTeams.RemoveAt(randV);
                randV = random.Next(0, availableTeams.Count - 1);
                Team tempTeam2 = availableTeams[randV];
                availableTeams.RemoveAt(randV);
                Match temp = new Match(matchNum, tempTeam1, tempTeam2);
                Matches.Add(temp);
                matchNum++; //increase size of matches
            }
            noOfMatches++;
        }
    }
}
