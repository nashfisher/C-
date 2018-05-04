using System;

namespace human
{

    public class Human {

        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string val) {
            name = val;
        }

        public Human(string val, int set_strength, int set_intelligence, int set_dexterity, int set_health) {
            name = val;
            strength = set_strength;
            intelligence = set_intelligence;
            dexterity = set_dexterity;
            health = set_health;
        }

        public void attack(object val) {

            if (val is Human) {
                Human person = val as Human; 
                int damage = this.strength * 5;
                person.health -= damage;
            }
            else {
                Console.WriteLine("You are unable to attack the target");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Human Creed = new Human("Creed");

            Human Kelsey = new Human("Kelsey", 5, 6, 7, 150);

            Creed.attack(Kelsey);
            Creed.attack(Kelsey);
            Console.WriteLine(Kelsey.health);
        }
    }
}
