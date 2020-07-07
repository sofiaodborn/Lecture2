using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

/* foundation for homework */
namespace A2_TextAdventure
{
    class ExampleEndlessLoop
    {
        static int Value = 0;
        static int ReverseValue;

        static string Room;
        static string Direction;

        static int[] ApprovedValues = new int[] { 0, 1, -2, 2, 4 };


    /* entry point, i.e. the method that executes first */
    static void Main()
        {
            InputLoop();
        }

        static void InputLoop()
        {
            while (true)
            {
                RoomNameAssignment();
                RoomDescrip();
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

            /* ctrl + h, replace with
             * alt + up/down arrow, move entire row */
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

        static void RoomNameAssignment()
        {
            if (Value == 0)
            {
                Room = "Entrance Hall";
            }
            else if (Value == 1)
            {
                Room = "Living Room";
            }
            else if (Value == 4)
            {
                Room = "Kitchen";
            }
            else if (Value == -2)
            {
                Room = "Painting Room";
            }
            else if (Value == 2)
            {
                Room = "Fancy Bedroom";
            }
        }

         
        static void RoomDescrip()
        {
            Console.WriteLine("You are in the " + Room);

            if (Value == 0)
            {
                Console.WriteLine("There is a door to the north");
            }
            else if (Value == 1)
            {
                Console.WriteLine("There are doors to the north, south, east, and west. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.");
            }
            else if (Value == 4)
            {
                Console.WriteLine("There is a door to the west. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.");
            }
            else if (Value == -2)
            {
                Console.WriteLine("There is a door to the east. There is a harpsichord, and a large medieval oil painting. The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing. ");
            }
            else if (Value == 2)
            {
                Console.WriteLine("There is a door to the south. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.");
            }
        }
    }
}
