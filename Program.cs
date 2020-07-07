using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

/* foundation for homework */
namespace A2_TextAdventure
{
    class ExampleEndlessLoop
    {
        const string Entrance_Hall = "There is a door to the north";
        const string Living_Room = "There are doors to the north, south, east, and west. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.";
        const string Kitchen = "There is a door to the west. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.";
        const string Painting_Room = "There is a door to the east. There is a harpsichord, and a large medieval oil painting. The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.";
        const string Fancy_Bedroom = "There is a door to the south. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.";

        static int Value = 0;
        static int ReverseValue;

        static string Room;
        static string Direction;
        static string Description;

        static int[] ApprovedValues = new int[] { 0, 1, -2, 2, 4 };

    static void Main()
        {
            InputLoop();
        }

        static void InputLoop()
        {
            while (true)
            {
                RoomAssignment();
                Talker();
                Console.Write(">"); 
                string input = Console.ReadLine();
                if (input == "quit")
                { 
                    break; 
                }

                Console.WriteLine(input);

                Direction = input;
                Calculator();
                RoomErrorChecker();
            }
            Console.WriteLine("Goodbye.");
        }

        static void Calculator()
        {
            ReverseValue = Value;

            if (Direction == "north")
            {
                Value = Value + 1;
            }
            else if (Direction == "south")
            {
                Value = Value - 1;
            }
            else if (Direction == "east")
            {
                Value = Value + 3;
            }
            else if (Direction == "west")
            {
                Value = Value - 3;
            }

        }

        static void RoomErrorChecker()
        {
            if (ApprovedValues.Contains(Value) == false)
            {
                Console.WriteLine("Cannot move in that direction, try again.\n");
                Value = ReverseValue;
            }
        }

        static void RoomAssignment()
        {
            if (Value == 0)
            {
                Room = "Entrance Hall";
                Description = Entrance_Hall;
            }

            else if (Value == 1)
            {
                Room = "Living Room";
                Description = Living_Room;
            }
            else if (Value == 4)
            {
                Room = "Kitchen";
                Description = Kitchen;
            }
            else if (Value == -2)
            {
                Room = "Painting Room";
                Description = Painting_Room;
            }
            else if (Value == 2)
            {
                Room = "Fancy Bedroom";
                Description = Fancy_Bedroom;
            }
        }
         
        static void Talker()
        {
            Console.WriteLine("You are in the " + Room);
            Console.WriteLine(Description);
        }
    }
}
