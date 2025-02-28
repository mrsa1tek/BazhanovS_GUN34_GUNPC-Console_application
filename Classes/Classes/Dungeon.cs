using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Dungeon
    {
        public Room[] rooms;
        public Dungeon()
        {
            new Room(new Unit("Human"), new Weapon("Knife"));
            new Room(new Unit("Zombie"), new Weapon("Teeth"));
            new Room(new Unit("Mage"), new Weapon("The Magic Staff"));
            new Room(new Unit("Goblin"), new Weapon("Explosive"));
        }
        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine("Unit of room " + room.Unit);
                Console.WriteLine("Weapon of room " + room.Weapon);
                Console.WriteLine("-");
            }
        }
    }
}
