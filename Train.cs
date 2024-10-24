namespace laba_10
{
    public class Train:Transport
    {

        protected static string[] nameTrain = { "passenger train", "reight train ", "express train", "slow train", "mail train" };
        public string TrainName { get; set; }

        public Train() : base("NoNameTransport", 0, 0, 0)
        {
            TrainName = "NoNameTrain";
        }

        public Train(string carTransportType, int yearRelease, int maxSpeed, int numbersPassengers, string bodyType, string trainName)
            : base(carTransportType, yearRelease, maxSpeed, numbersPassengers)
        {
            TrainName = trainName;
        }
        public override void Init()
        {
            base.Init();

            Console.Write("Enter the type of train: ");
            string input;
            bool isRead = false;
            do
            {
                input = Console.ReadLine();
                if (!nameTrain.Contains(input))
                {
                    Console.WriteLine("Incorrect train body type passenger train, reight train , express train, slow train, mail train)");
                    Console.Write("Enter body train: ");
                    isRead = false;
                }
                else 
                    isRead = true;
            }
            while (!isRead);
            TrainName = input;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"TrainName = {TrainName}");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            TransportType = "Train";
            TrainName = nameTrain[rnd.Next(nameTrain.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $", Train Name: {TrainName}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }
            var other = (Train)obj;
            return TrainName == other.TrainName;
        }

        public override int CompareTo(object obj)
        {
            return base.CompareTo(obj);
        }
    }
}


