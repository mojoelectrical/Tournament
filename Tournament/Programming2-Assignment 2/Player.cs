using System;
using System.Collections.Generic;
using System.Text;

namespace Programming2_Assignment_2
{
    class Player
    {

        DateTime DateOfBirth {get;set;}
        public uint Id { get; }

        public string Name { get; set; }


        public Player() {
            this.Id = IdGenerator.GetId();
        }

        public Player(string name, DateTime dob):this() {
            this.Name = name;
            this.DateOfBirth = dob;
            //this.Id = IdGenerator.GetId();
        }

        public Player(string name, DateTime dob, Team team):this() {
            this.Name = name;
            this.DateOfBirth = dob;
            Player newplayer = new Player(name, dob);
            team.AddPlayer(newplayer);
        }

        public override string ToString()
        {
            return $"Name: {Name},Id: {Id}, Date of Birth:{DateOfBirth}";
        }
    }
}