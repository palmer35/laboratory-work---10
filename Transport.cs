namespace laba_10
{
    public class Transport:IInit, IComparable
    {
        protected Random rnd = new Random();

        private string[] brands = { "Star Voyager", "Sunny Breeze", "Lunar Cruiser", "Cosmic Dolphin", "Galactic Express", "Misty Road", "Shining Comet", "Whirlwind of Joy", "Magical Bus", "Astral Traveler" };

        public string TransportType { get; set; }

        private int yerRelease;

        public int YearRelease
        {
            get => yerRelease;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException($"The year of issue should be between 0 and {DateTime.Now.Year}.");
                }
                yerRelease = value;
            }
        }

        private int maxSpeed;
        public int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException($"Incorrect speed! It should be between 0 and 1000.");
                }
                maxSpeed = value;
            }
        }

        private int numberPassengers;
        public int NumberPassengers
        {
            get => numberPassengers;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Incorrect number of passengers! It should be between 0 and 100.");
                }
                numberPassengers = value;
            }
        }

        public Transport()
        {
            TransportType = "NoBrand";
            YearRelease = 0;
            MaxSpeed = 0;
            NumberPassengers = 0;
        }

        public Transport(string transportType, int yearRelease, int maxSpeed, int numberPassengers)
        {
            TransportType = transportType;
            YearRelease = yearRelease; 
            MaxSpeed = maxSpeed; 
            NumberPassengers = numberPassengers;
        }


        public virtual void Show()
        {
            Console.WriteLine($"Transport = {TransportType}\n" +
                              $"Year Release = {YearRelease}\n" +
                              $"Max Speed = {MaxSpeed}\n" +
                              $"Number of Passengers = {NumberPassengers}");
        }


        public virtual void Init()
        {
            Console.Write("Enter the transportType name: ");
            TransportType = Console.ReadLine();

            YearRelease = CheckValues("Enter the year of release: ", 0, DateTime.Now.Year, 
                $"Incorrect year of release! Try again... (Enter between 0 and {DateTime.Now.Year})");

            MaxSpeed = CheckValues("Enter the maximum transport speed: ", 0,1000,
                $"Incorrect maximum speed! Try again... (Enter between 0 and 1000)");

            NumberPassengers = CheckValues("Enter the number of passengers: ", 0, 100,
                $"Incorrect number of passengers! Try again... (Enter between 0 and 100)");
        }

        protected int CheckValues(string message, int min, int max, string errorMessage)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.WriteLine(errorMessage);
                Console.Write(message);
            }
            return value;
        }

        public virtual void RandomInit()
        {
            TransportType = brands[rnd.Next(brands.Length)];
            YearRelease = rnd.Next(1886, DateTime.Now.Year+1);
            MaxSpeed = rnd.Next(1, 1000);
            NumberPassengers = rnd.Next(1, 100);
        }


        public virtual bool Equals(object obj)
        {
            if (obj is Transport other)
            {
                return this.TransportType == other.TransportType &&
                       this.YearRelease == other.YearRelease &&
                       this.MaxSpeed == other.MaxSpeed &&
                       this.NumberPassengers == other.NumberPassengers;
            }
            return false;
        }

        public override string ToString()
        {
            return $"TransportType: {TransportType}, Year: {YearRelease}, MaxSpeed: {MaxSpeed} km/h, Passengers: {NumberPassengers}";
        }

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (obj is Transport p)
            {
                return String.Compare(this.TransportType, p.TransportType);
            }
            throw new ArgumentException("Object is not a Transport");
        }
    }
}
