using System;
using System.Collections.Generic;

namespace Programming2_Assignment_2
{
    class Program
    {
        static Random random = new Random(1);



        static void Main(string[] args)
        {
            TeamRepository.Load();
            Team team1 = new Team("Team 100");
            Team team2 = new Team("Team 101");
            TeamRepository.AddTeam(team1);
            TeamRepository.AddTeam(team2);

            Player player1 = new Player("player", new DateTime(2001, 1, 1));
            Player player2 = new Player("player", new DateTime(2002, 2, 2));
            Player player3 = new Player("player3", new DateTime(2003, 3, 3));
            Player player4 = new Player("player4", new DateTime(2004, 4, 4));
            Player player5 = new Player("player5", new DateTime(2005, 5, 5));
            Player player6 = new Player("player6", new DateTime(2006, 6, 6), team1);
            Player player7 = new Player("player7", new DateTime(2007, 7, 7), team1);
            Player player8 = new Player("player8", new DateTime(2008, 8, 8), team2);

            team1.AddPlayer(player1);
            team1.AddPlayer(player2);
            team1.AddPlayer(player3);
            team2.AddPlayer(player4);
            team2.AddPlayer(player5);

            Player foundPlayer = TeamRepository.Teams[1].FindPlayer(TeamRepository.Teams[1].Players[0].Id);
            if (foundPlayer != null)
            {
                Console.WriteLine($"Player with id {foundPlayer.Id} is {foundPlayer}");

            }
            else
            {
                Console.WriteLine("Player is not found");
            }
            foundPlayer = team1.FindPlayer(200);
            if (foundPlayer != null)
            {
                Console.WriteLine($"Player with id 200 is {foundPlayer}");

            }
            else
            {
                Console.WriteLine("Player with id 200 is not found");
            }
            IEnumerable<Player> playersWithPlayerName = team1.GetPlayers("player");
            Console.WriteLine("Players with name: player");
            foreach (var item in playersWithPlayerName)
            {
                Console.WriteLine(item);
            }

            foreach (Team item in TeamRepository.Teams)
            {
                Console.WriteLine(item);
            }

            RounRobinTournament rrTournament1 = new RounRobinTournament("rrTournament1");
            RounRobinTournament rrTournament2 = new RounRobinTournament("rrTournament2");
            KnockoutTournament knTournament1 = new KnockoutTournament("knTurnament1");
            KnockoutTournament knTournament2 = new KnockoutTournament("knTurnament1");

            AddTeamsToTournament(rrTournament1, 0, 1);
            rrTournament1.SetMatches();
            Console.WriteLine(rrTournament1.ToString());
            Console.WriteLine();

            Match foundMatch = rrTournament1.FindMach(TeamRepository.Teams[1],
                                                     TeamRepository.Teams[0]);
            if (foundMatch != null)
            {
                Console.WriteLine($"Match found: {foundMatch}");
            }
            else
            {
                Console.WriteLine("Match not found");
            }

            AddWinner(rrTournament1, TeamRepository.Teams[1], TeamRepository.Teams[0]);
            AddWinner(rrTournament1, TeamRepository.Teams[0], TeamRepository.Teams[1]);
            Console.WriteLine(rrTournament1);
            Console.WriteLine();
        }

        public static void AddWinner(Tournament tournament, Team winner, Team looser)
        {
            tournament.AddWinner(winner, looser);
        }

        public static void AddTeamsToTournament(Tournament aTurnament, int startIndex, int endIndex)
        {
            int numberOfTeams = TeamRepository.Teams.Count;
            Console.WriteLine(numberOfTeams);
            Console.WriteLine($"Adding teams from index {startIndex} to {endIndex}");
            
            for (int i = startIndex; i <= endIndex; i++)
            {
                aTurnament.AddTeam(TeamRepository.Teams[i]);
            }
            
        }

    }
}
