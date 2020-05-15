using System;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLevels, spotsPerLevel;
            Console.Write("Enter the no.of floor:");
            numOfLevels = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the no.of spots:");
            spotsPerLevel = Convert.ToInt32(Console.ReadLine());
            ParkingLot p = new ParkingLot(numOfLevels, spotsPerLevel);
            while (true)
            {
                bool isAdvanced = false;
                int choice;
                Console.WriteLine("Select a method\n1.Entry Gate\n2.Exit Gate\n3.View Vehicles parked\n4.Advance Booking\n5.Cancel booking");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Did you have advance booking? yes or no");
                        string selection = Console.ReadLine();
                        if (selection.ToLower() == "yes" || selection.ToLower() == "y")
                        {
                            verify(p);
                        }
                        else
                            vehicleEntry(p, isAdvanced);
                        break;
                    case 2:
                        vehicleExit(p);
                        break;
                    case 3:
                        Console.WriteLine("Vehicle Number\tvehicle Type\tFloor\t\tSpot");
                        p.viewParkedVehicle();
                        break;
                    case 4:
                        isAdvanced = true;
                        vehicleEntry(p, isAdvanced);
                        break;
                    case 5:
                        cancelBooking(p);
                        break;
                }
                Console.WriteLine("Do you want to continue?yes or no");
                string select = Console.ReadLine();
                if (select.ToLower() == "no" || select.ToLower() == "n")
                {
                    break;
                }
            }
        }

        private static void cancelBooking(ParkingLot p)
        {
            string number;
            Console.WriteLine("enter the vehicle number");
            number = Console.ReadLine();
            p.CancelBooking(number);
        }

        private static void verify(ParkingLot p)
        {
            string number;
            Console.WriteLine("enter the vehicle number");
            number = Console.ReadLine();
            p.verifyBooking(number);
        }

        private static void vehicleExit(ParkingLot p)
        {
            string number,type;
            Console.WriteLine("enter the vehicle number");
            number = Console.ReadLine();
            Console.WriteLine("enter the vehicle type");
            type = Console.ReadLine();
            p.removeVehicle(number,type,3);
        }

        private static void vehicleEntry(ParkingLot p, bool isAdvanced)
        {
            string typ, num;
            Console.Write("Enter vehicle type:");
            typ = Console.ReadLine();
            Console.Write("Enter vehicle number:");
            num = Console.ReadLine();
            p.bookSlot(typ, num, isAdvanced);
        }
    }
}
