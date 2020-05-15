using System;
namespace ConsoleApp1
{
    public interface Iparking
    {
        int floors { get; set; }
        int spots { get; set; }
    }
    public interface IVehicle : Iparking
    {
        string vehicleId { get; set; }
        string vehicleType { get; set; }
        bool isadvanced { get; set; }
        int Rate { get; set; }
        int visited { get; set; }
    }
    public interface Ilevels
    {
        int[] bikeSpot { get; set; }
        int[] carSpot { get; set; }
        int[] busSpot { get; set; }
    }
    class Level:Ilevels
    {
        public int[] bikeSpot { get; set; }
        public int[] carSpot { get; set; }
        public int[] busSpot { get; set; }
        public Level(int spots)
        {
            int len1,len2,len3;
            len1 = spots * 40 / 100;
            len2 = spots * 40 / 100;
            len3 = spots * 20 / 100;
            if((len1+len2+len3)!=spots)
            {           
                len1 += spots - (len1 + len2 + len3);
            }
            bikeSpot = new int[len1];
            Array.Clear(bikeSpot, 0, bikeSpot.Length);
            carSpot = new int[len2];
            Array.Clear(carSpot, 0, carSpot.Length);
            busSpot = new int[len3];
            Array.Clear(busSpot, 0, busSpot.Length);
            printf();
        }
        public void printf()
        {
            Console.WriteLine("Bike:");
            print(bikeSpot);
            Console.WriteLine("Cars:");
            print(carSpot);
            Console.WriteLine(" Bus:");
            print(busSpot);
        }
        void print(int[] arr)
        {
            int count1 = 0,count = 0;
            foreach (int k in arr)
            {
                if (k == 1)
                    count++;
                else
                    count1++;
                //Console.Write(k + " ");
            }
            Console.WriteLine("No. of vacant={0}",count1);
            Console.WriteLine("No. of occupied={0}",count);
        }
        public int GetSpot(string type)
        {
            if (type == "bike")
            {
                for (int i = 0; i < bikeSpot.Length; i++)
                {
                    if (bikeSpot[i] == 0)
                    {
                        bikeSpot[i] = 1;
                        return i;
                    }
                }
            }
            else if (type == "car")
            {
                for (int i = 0; i < carSpot.Length; i++)
                {
                    if (carSpot[i] == 0)
                    {
                        carSpot[i] = 1;
                        return i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < busSpot.Length; i++)
                {
                    if (busSpot[i] == 0)
                    {
                        busSpot[i] = 1;
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
