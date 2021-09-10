using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    class RounRobinTournament : Tournament
    {
        public RounRobinTournament(string Name) : base(Name) {

        }
        
        /*
        This method will create all matches that will be played in the roundrobin
        tournament. In round-robin tournament every team plays all other teams once.
        */

        public override void SetMatches() {
            int count = 1;

            if (Teams.Count > 1) {
                for (int i = 0; i < Teams.Count -1; i++)
                {
                    for (int j = i + 1; j < Teams.Count; j++)
                    {
                        Match a = new Match(count, Teams[i], Teams[j]);
                        Matches.Add(a);
                        count++;
                    }
                }

            }
        }
        
    } 
}

