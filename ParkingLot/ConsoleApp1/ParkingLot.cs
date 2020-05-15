using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class ParkingLot:Iparking
    {
        public int floors { get; set; }
        public int spots { get; set; }
        public bool isadvanced { get; set; }
        List<ParkedVehicle> pv = new List<ParkedVehicle>();
        List<string> visited = new List<string>();
        Level[] levels;
        public ParkingLot(int floors, int spots)
        {
            this.floors = floors;
            this.levels = new Level[this.floors];
            for (int i = 0; i < floors; i++)
            {
                Console.WriteLine("Floor" + (i + 1));
                this.levels[i] = new Level(spots);
            }

        }
        public void viewParkedVehicle()
        {
            foreach (ParkedVehicle parked in pv)
            {
                Console.WriteLine(parked.vehicleId + "\t\t" + parked.vehicleType + "\t\t" + parked.floors + "\t\t" + parked.spots);
            }
        }
        public void bookSlot(string type,string number,bool advanced)
        {
            int i, spot,count;
            for (i = 0; i < this.floors; i++)
            {
                spot = levels[i].GetSpot(type);
                if (spot != -1)
                {
                    count=getStatus(visited);
                    ParkedVehicle parked = new ParkedVehicle(type, number, i + 1, spot + 1, advanced);
                    Console.WriteLine("Your parking spot is {0} floor and {1} spot", parked.floors, parked.spots);
                    Console.WriteLine("Welcome sir");
                    parked.visited = count;
                    pv.Add(parked);
                    for (int j = 0; j < floors; j++)
                    {
                        Console.WriteLine("Floor" + (j + 1));
                        levels[j].printf();
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry there is no house for your {0}", type);
                    break;
                }

            }
        }

        private int getStatus(List<string> visited)
        {
            int count = 0;
            foreach(string s in visited)
            {
                count++;
            }
            return count;
        }

        internal void verifyBooking(string number)
        {
            int flag = 0;
            foreach(ParkedVehicle p in pv)
            {
                if(p.vehicleId==number)
                {
                    if (p.isadvanced)
                    {
                        Console.WriteLine("your slot is {0} floor {1} {2}spot", p.floors, p.spots, p.vehicleType);
                    }
                    else
                        Console.WriteLine("there is no advance booking");
                    flag = 1;
                }

            }
            if (flag == 0)
                Console.WriteLine("There is no vehicle");
        }

        internal void CancelBooking(string number)
        {
            int flag = 0;
            foreach (ParkedVehicle p in pv)
            {
                if (p.vehicleId == number)
                {
                    if (p.isadvanced)
                    {

                        freeSpace(p, p.vehicleType);
                    }
                    else
                        Console.WriteLine("there is no advance booking");
                    flag = 1;
                }

            }
            if (flag == 0)
                Console.WriteLine("There is no vehicle");
        }

        internal void removeVehicle(string number,string type, int hrs)
        {
            int flag = 0;
            int sub ;
            foreach(ParkedVehicle p in pv)
            {
                if(p.vehicleId==number&&p.vehicleType==type)
                {
                    
                    Console.WriteLine("Do you have coupoun\n1.yes\n2.no");
                    int coupoun = Convert.ToInt32(Console.ReadLine());
                    if (coupoun == 1 && p.visited == 1)
                        sub = reduceamnt(type, hrs);
                    else
                        sub = amntnocoupoun(hrs, type);
                    freeSpace(p,type);
                    p.Rate += sub;
                    flag = 1;
                    Console.WriteLine("Vehicle Number\tvehicle Type\tFloor\tSpot\tAmount");
                    Console.WriteLine(p.vehicleId + "\t\t" + p.vehicleType + "\t\t" + p.floors + "\t" + p.spots + "\t" + p.Rate);
                    for (int j = 0; j < floors; j++)
                    {
                        Console.WriteLine("Floor" + (j + 1));
                        levels[j].printf();
                    }
                    break;
                }
            }
            if (flag == 0)
                Console.WriteLine("There is no vehicle");
        }

        private void freeSpace(ParkedVehicle p,string type)
        {
            if (type == "bike")
            {
                levels[p.floors - 1].bikeSpot[p.spots - 1] = 0;
            }
            else if (type == "car")
            {
                levels[p.floors - 1].carSpot[p.spots - 1] = 0;
            }
            else
            {
                levels[p.floors - 1].busSpot[p.spots - 1] = 0; 
            }
        }

        private int amntnocoupoun(int hrs, string type)
        {
            if (type == "car")
                return 15 + ((hrs - 1) * 20);
            else if (type == "bike")
                return 10 + ((hrs - 1) * 15);
            else
                return 20 + ((hrs - 1) * 25);
        }

        private int reduceamnt(string type, int hrs)
        {
            int amnt=0;
            if(type=="car")
            {
                amnt = (15 * 50 / 100) + ((hrs - 1) * (20 * 10 / 100));
            }
            else if(type=="bike")
            {
                amnt = (10 * 50 / 100) + ((hrs - 1) * (15 * 10 / 100));
            }
            else
                amnt = (20 * 50 / 100) + ((hrs - 1) * (25 * 10 / 100));

            return amnt;
        }
    }
}
