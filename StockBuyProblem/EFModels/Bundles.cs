using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBuyProblem.EFModels
{
    [Table("bundles")]
    public class Bundles
    {
        [Key]
        [Column("bundle_Id ")]
        public int partId { get; set; }
        [Column("item_name ")]
        public string? partName { get; set; }
        [Column("parts_required")]
        public int partRequired { get; set; }
        [Column("item_parent_id ")]
        public int parent_id { get; set; }

        public ICollection<Bundles>? subBundlesList { get; set; }
    }
}
