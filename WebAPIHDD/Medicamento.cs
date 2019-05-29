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
    
    public partial class Medicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicamento()
        {
            this.Compra = new HashSet<Compra>();
            this.DetalleVenta = new HashSet<DetalleVenta>();
            this.MedicamentoHospitalizacion = new HashSet<MedicamentoHospitalizacion>();
            this.Precio = new HashSet<Precio>();
        }
    
        public int idMedicamento { get; set; }
        public Nullable<int> idFarmacia { get; set; }
        public Nullable<int> idCategoriaMedicamento { get; set; }
        public string nombreComercial { get; set; }
        public string nombreGenerico { get; set; }
        public Nullable<bool> ingresado { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        public virtual CategoriaMedicamento CategoriaMedicamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual Farmacia Farmacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicamentoHospitalizacion> MedicamentoHospitalizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precio> Precio { get; set; }
    }
}