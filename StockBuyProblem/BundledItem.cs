using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBuyProblem
{
    public class BundledItem
    {
        public int partId {  get; set; }
        public string? partName { get; set; }
        public int partRequired { get; set; }
        public List<BundledItem>? subBundlesList { get; set; }
        public int partInvetory { get; set; }
    }
}
