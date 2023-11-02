using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Model;

[Table("products")]

public class Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Column("price")]
    [Required]
    [Range(1,10000)]
    [DataType("decimal(10,2)")]
    public decimal Price { get; set; }

    [Column("description")]
    [StringLength(300)]
    public string Description { get; set; }

    [Column("category_name")]
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [Column("immage_url")]
    [StringLength(300)]
    public string ImmageUrl { get; set; }
}
