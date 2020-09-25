namespace H5Chocolate
{
    public class Donation
    {
        public int amount;
        private string organization;

        public string Organization
        {
            get
            {
                return organization;
            }
            set
            {
                organization = value;
            }
        }
    }
}

// public MyController(IMyService myService)
// {
//     if (myService == null)
//     {
//         throw new ArgumentNullException(nameof(myService));
//     }

//     _myService = myService;
// }