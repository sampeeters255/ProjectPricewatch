//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pricewatch_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductWinkels = new HashSet<ProductWinkel>();
        }
    
        public int id { get; set; }
        public int subId { get; set; }
        public int merkId { get; set; }
        public string productNaam { get; set; }
        public Nullable<double> schermdiagonaal { get; set; }
        public string besturingssysteem { get; set; }
        public Nullable<int> opslagcapaciteit { get; set; }
        public Nullable<int> werkgeheugen { get; set; }
        public string soort { get; set; }
        public Nullable<int> batterijduur { get; set; }
        public string verbinding { get; set; }
        public string zakloos { get; set; }
        public Nullable<double> inhoud { get; set; }
        public string koffiesoort { get; set; }
        public Nullable<double> inhoudBonen { get; set; }
        public Nullable<double> inhoudWater { get; set; }
        public Nullable<int> vermogen { get; set; }
    
        public virtual Merk Merk { get; set; }
        public virtual Subcategorie Subcategorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductWinkel> ProductWinkels { get; set; }
    }
}