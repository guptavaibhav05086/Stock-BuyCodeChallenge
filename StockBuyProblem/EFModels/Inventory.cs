using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBuyProblem.EFModels
{
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        [Column("id ")]
        public int Id { get; set; }
       
        [Column("bundle_Id")]
        [ForeignKey("Bundles")]
        public int BundleId { get; set; }
        [Column("stock ")]
        public int partInvetory { get; set; }

    }
}
