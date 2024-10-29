namespace laba_10
{
    public class Car : Transport
    {
        private string[] carBrand = { "Lada", "Toyota", "Ford", "BMW", "Honda", "Nissan", "Chevrolet", "Audi", "Mercedes-Benz", "Kia" };
        private string[] bodyType = { "Saloon", "Hatchback ", "Estate", "Coupe", " Pickup" };
        public string BodyType { get; set; }
        public string CarBrand { get; set; }

        public Car() : base("NoNameTransport", 0, 0, 0)
        {
            CarBrand = "NoNameTransport";
            BodyType = "NoBodyType";
        }

        public Car(string carTransportType, int yearRelease, int maxSpeed, int numbersPassengers, string carBrand, string bodyType) : base(carTransportType, yearRelease, maxSpeed, numbersPassengers)
        {
            CarBrand = carBrand;
            BodyType = carBrand;
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите тип кузова: ");
            string input;
            var isRead = false;
            do
            {
                input = Console.ReadLine();
                if (!bodyType.Contains(input))
                {
                    Console.WriteLine("Incorrect car body type (possible options: Saloon, Hatchback , Estate, Coupe, Pickup)");
                    Console.Write("Enter body type:: ");
                    isRead = false;
                }
                else
                    isRead = true;
            } while (!isRead);
            BodyType = input;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"CarBrand = {BodyType}");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            TransportType = "Car";
            BodyType = bodyType[rnd.Next(bodyType.Length)];
            CarBrand = carBrand[rnd.Next(CarBrand.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $", CarBrand: {CarBrand}" + $", BodyType: {BodyType}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }

            var other = (Car)obj;
            return BodyType == other.BodyType;
        }

        public override int CompareTo(object obj)
        {
            return base.CompareTo(obj); 
        }
    }
}