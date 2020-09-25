using System.Collections.Generic;

namespace H5Chocolate
{
    public class Chocolate
    {
        public string name;
        public int cacaoAmount;
        public int milkAmount;
        public List<string> filling = new List<string>();

        //Exempelkod! Returnerar inte ett vettigt pris.
        public float Cost
        {
            get
            {
                return cacaoAmount * milkAmount;
            }
        }
    }
}