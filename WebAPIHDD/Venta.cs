//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIHDD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int idVenta { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string cliente { get; set; }
        public string documento { get; set; }
        public Nullable<decimal> subtotal12 { get; set; }
        public Nullable<decimal> subtotal0 { get; set; }
        public Nullable<decimal> iva { get; set; }
        public Nullable<decimal> ice { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}