using System.ComponentModel.Design;

namespace StockBuyProblem
{
    public class Program
    {      
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Product Creation Example by Vaibhav Gupta!");
            Console.WriteLine("**********************************************************");
            Console.WriteLine();
            //Sample Tree input for Bundled items
            BundledItem tree = new BundledItem
            {
                partId = 1,
                partName = "P0",
                partInvetory = -1,//For root product inventory value will always be -1
                partRequired = -1,
                subBundlesList = new List<BundledItem>()
                {
                    //P1
                    new BundledItem
                    {
                        partId = 1,
                        partName = "P1",
                        partInvetory=20,
                        partRequired=3,
                    },
                    //P2
                    new BundledItem
                    {
                        partId = 2,
                        partName = "P2",
                        partInvetory=0,//For parent bundles inventory value is insigificant as it will calculated based on sub bundles
                        partRequired=2,
                        subBundlesList=new List<BundledItem>
                        {
                            new BundledItem
                            {
                                   partId = 5,
                        partName = "P5",
                        partInvetory=12,
                        partRequired=5,
                            },
                             new BundledItem
                            {
                                   partId = 7,
                        partName = "P7",
                        partInvetory=0,
                        partRequired=1,
                        subBundlesList=new List<BundledItem>
                        {
                            new BundledItem
                            {
                                   partId = 8,
                        partName = "P8",
                        partInvetory=11,
                        partRequired=5,
                            },
                             new BundledItem
                            {
                                   partId = 9,
                        partName = "P9",
                        partInvetory=11,
                        partRequired=5,
                            },
                        }
                            }
                        }
                    },
                    //P3
                    new BundledItem
                    {
                        partId = 3,
                        partName = "P3",
                        partInvetory=34,
                        partRequired=5,
                    },
                    //P4
                    new BundledItem
                    {
                        partId = 4,
                        partName = "P4",
                        partInvetory=0,
                        partRequired=2,
                         subBundlesList=new List<BundledItem>
                        {
                            new BundledItem
                            {
                                   partId = 6,
                        partName = "P6",
                        partInvetory=11,
                        partRequired=4,
                            }
                        }
                    },
                }

            };
            Console.WriteLine("Printing the Input Tree");
            try
            {
                var result = CalculateMaxProductsFromBundles(tree, 0);
                if (result == -1)
                {
                    Console.WriteLine("Final Product can not be created as becasue of inventory shortage");
                }
                else
                {
                    Console.WriteLine($"{result} products can be created based on current inventory");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Final Product can not be created as beacsue of inventory shortage");
            }
           

            Console.ReadLine();
        }

        public static int CalculateMaxProductsFromBundles(BundledItem tree, int pCount)
        {

            //For root node 
            if (tree.partInvetory == -1 && (tree.subBundlesList?.Count == 0 || tree.subBundlesList == null))
            {
                return -1;
            }
            foreach (var item in tree.subBundlesList!)
            {
                //Check for leaf count 
                if (item.subBundlesList?.Count == 0 || item.subBundlesList == null)
                {
                    if (item.partInvetory > item.partRequired)
                    {
                        int temVal = item.partInvetory / item.partRequired;
                        if (temVal < pCount || pCount == 0)
                        {
                            pCount = temVal;
                        }                      
                        Console.WriteLine($"PartName Processing {item.partName} and calculate count is {temVal}");
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {                  
                    int calProducts = CalculateMaxProductsFromBundles(item, 0);
                    if (item.partInvetory >= item.partRequired)
                    {
                        int temVal = item.partInvetory / item.partRequired;
                        if (temVal < pCount || pCount == 0)
                        {
                            pCount = temVal;
                        }                       
                        Console.WriteLine($"PartName Processing {item.partName} and calculate count is {temVal}");
                    }
                    else
                    {
                        Console.WriteLine($"PartName  {item.partName} Required Value is  {item.partRequired} but Inventory is {item.partInvetory}");
                        throw new Exception("Inventory Shortage");                        
                    }          
                                 
                }


            }
            tree.partInvetory = pCount;           
            return pCount;
        }
    }
}
