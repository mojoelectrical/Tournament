using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    class Team
    {
        List<Player> players;
        
        public string Name { get; set; }
        public Region Region { get; set; }

        public uint Id { get; }

        public List<Player> Players { get { return players; }}
            

        public void AddPlayer(Player aPlayer) {

            players.Add(aPlayer);
            TeamRepository.Save();
            }

        public Player FindPlayer(uint id) {
            foreach (Player element in players)
            {
                if (element.Id == id)
                {
                    return element;
                }
            }
            return null;
        }
       
        public IEnumerable<Player> GetPlayers(string name){

            foreach (Player player in players) {
                if (player.Name.Equals(name))
                {
                    yield return player;
                }
            }
        }

        public Team() {
            Id = IdGenerator.GetId();
            players = new List<Player>();
        }

        public Team(string name):this() {
            Name = name;
            
        }

        public Team(string name, Region region):this() {
            Name = name;
            Region = region;

        }

        public override string ToString()
        {
            string allplayers="";
            foreach (Player a in players) {
                allplayers += a.ToString() + "\n";
            }
            
                return $"Team: {Name}, ID: {Id}, Region: {Region}, Players:{allplayers}";
            }
        }

    }

    



