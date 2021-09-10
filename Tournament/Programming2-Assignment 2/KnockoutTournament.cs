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
        
        
        /*
        The method will set the winner of the match with  the provided teams. The winning team is then added to avalableTeams list. If all  available matches in the tournament are 
        finished and there are more rounds that need to be played, the new round of matches is set by calling the SetMatches method.
        */
        
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
        /*
        The method sets the new round of matches. It randomly matches the teams. If there is an odd number of available teams for the round the team that is left
        after all other available teams are matched up will automatically advance to the next round.
        */
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
