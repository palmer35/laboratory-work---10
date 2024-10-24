namespace laba_10
{
    public class Aircraft : Transport, ICloneable
    {
        private string[] aircraftTypes = { "Passenger", "Cargo", "Military", "Sport", "Private", "Regional", "Training", "VTOL", "Amphibious", "Drone" };

        public string AircraftType { get; private set; }

        private int flightRange;

        public int FlightRange
        {
            get => flightRange;
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Flight range must be between 0 and 1000.");
                }
                flightRange = value;
            }
        }

        public Aircraft() : base("NoNameTransport", 0, 0, 0)
        {
            AircraftType = "NoNamePlane";
            FlightRange = 0;
        }

        public Aircraft(string carTransportType, int yearRelease, int maxSpeed, int numbersPassengers, string aircraftName, int flightLimit)
            : base(carTransportType, yearRelease, maxSpeed, numbersPassengers)
        {
            AircraftType = aircraftName;
            FlightRange = flightLimit;
        }

        public void Init()
        {
            Console.Write("Enter the type of aircraft: ");
            string selectedAircraftType = Console.ReadLine();
            AircraftType = selectedAircraftType;


            Console.Write("Enter the flight range (0 to 1000): ");
            int flight;
            while (!int.TryParse(Console.ReadLine(), out flight) || flight < 0 || flight > 1000)
            {
                Console.WriteLine("Invalid input. Please enter a flight range between 0 and 1000.");
            }
            FlightRange = flight; 
        }

        public override void RandomInit()
        {
            base.RandomInit();
            TransportType = "Aircraft";
            AircraftType = aircraftTypes[rnd.Next(aircraftTypes.Length)];
            FlightRange = rnd.Next(1, 1000); 
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"AircraftType = {AircraftType} \nFlightRange = {FlightRange}км"); 
        }

        public override string ToString()
        {
            return base.ToString() + $", AircraftType = {AircraftType}, FlightRange = {FlightRange}км";
        }

        public object Clone()
        {
            return new Aircraft(this.TransportType, this.YearRelease, this.MaxSpeed, this.NumberPassengers, this.AircraftType, this.FlightRange);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }

            var other = (Aircraft)obj;
            return AircraftType == other.AircraftType;
        }

        public override int CompareTo(object obj)
        {
            return base.CompareTo(obj);
        }
    }
}
