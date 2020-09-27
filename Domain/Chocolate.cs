using System.Collections.Generic;

namespace H5Chocolate
{
    public class Chocolate : Product
    {
        public int CacaoAmount
        {
            get;
            set;
        }
        public int MilkAmount
        {
            get;
            set;
        }

        public List<string> filling = new List<string>();

        public Chocolate(string name, int cacaoAmount, int milkAmount, List<string> filling)
        {
            this.Name = name;
            this.CacaoAmount = cacaoAmount;
            this.MilkAmount = milkAmount;
            this.filling = filling;
        }
    }
}