//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MakeupOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public Nullable<int> UserId { get; set; }
        [Required]
        public Nullable<int> CategoryId { get; set; }
        [Required]
        public Nullable<System.DateTime> SellStartDate { get; set; }
        [Required]
        public Nullable<System.DateTime> SellEndDate { get; set; }
        [Required]
        public Nullable<int> IsNew { get; set; }
        public Nullable<int> ModelId { get; set; }
        public Nullable<double> Price { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Model Model { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
