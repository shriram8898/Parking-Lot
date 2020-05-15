namespace ConsoleApp1
{
    class ParkedVehicle:IVehicle
    {
        public string vehicleId { get; set; }
        public string vehicleType { get; set; }
        public int floors { get; set; }
        public int spots { get; set; }
        public bool isadvanced { get; set; }
        public int Rate { get; set; }
        public int visited { get; set; }
        public ParkedVehicle(string type, string id, int floor, int spot, bool isadvanced)
        {
            this.vehicleId = id;
            this.vehicleType = type;
            this.floors = floor;
            this.spots = spot;
            this.isadvanced = isadvanced;
            if (isadvanced == true)
            {
                this.Rate = 5;
            }
            else
                this.Rate = 0;
        }
    }
}
