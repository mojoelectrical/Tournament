using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Programming2_Assignment_2
{
    [Serializable]
    static class TeamRepository
    {
        static List<Team> teams = new List<Team>();
        const string PATH = @"C:\A2\teams.json";

        public static List<Team> Teams { get { return teams; } }

        public static void AddTeam(Team team) {
            //this method adds a team that is provided as the argument to the repository.
            //Every time a team is added to the repository the repository is saved as JSON
            Teams.Add(team);
            TeamRepository.Save();

        }

        public static void Load()
        {
            FileStream fileIn = new FileStream(PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileIn);
            string stringFromFile = reader.ReadToEnd();
            List<Team> result = JsonSerializer.Deserialize<List<Team>>(stringFromFile);

            reader.Close();
            fileIn.Close();
        }

        public static void Save() {

            FileStream fileOut = new FileStream(PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileOut);

            string jsonString = JsonSerializer.Serialize(teams);
            writer.WriteLine(jsonString);
            writer.Close();
            fileOut.Close();

        }
    } 
}
