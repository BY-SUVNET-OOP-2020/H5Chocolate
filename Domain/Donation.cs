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
        }

        public Donation(string organization)
        {
            this.organization = organization;
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