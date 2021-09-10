using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    abstract class Tournament
    {
        List<Match> matches = new List<Match>();

        public List<Match> Matches { get {return matches; } }
        public string Name { get; set; }

        protected List<Team> Teams { get; }

        public Tournament(string name) {
            this.Name = name;
            Teams = new List<Team>();
        }

        public void AddTeam(Team team) {
            Teams.Add(team);      
        
        }

        public virtual void AddWinner(Team winner, Team loser) 
        {
           
            Match win = FindMach(winner, loser);
            win.WinningTeam = winner;
            
        }

        public Match FindMach(Team team1, Team team2) {

            for (int i = 0; i < Matches.Count  ; i++) {
                if (((Matches[i].Teams[0].Equals(team1)) && (Matches[i].Teams[1].Equals(team2))) || ((Matches[i].Teams[1].Equals(team1)) && (Matches[i].Teams[0].Equals(team2)))) 
                {
                    return Matches[i];
                }
            }

            return null;
        }

        public virtual void SetMatches() 
        {//sets matches in the tournament : Round-Robin or Knock Out
            
        }

        public override string ToString()
        {
            string allMatches="";
            foreach (Match mat in matches) 
            {
                allMatches += mat.ToString() + "\n";
            }

            return $"Name: {Name}" + allMatches;
        }



    }
}
