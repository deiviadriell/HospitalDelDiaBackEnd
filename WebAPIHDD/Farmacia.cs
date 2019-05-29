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
    
    public partial class Farmacia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Farmacia()
        {
            this.Medicamento = new HashSet<Medicamento>();
        }
    
        public int idFarmacia { get; set; }
        public Nullable<int> idEstablecimiento { get; set; }
        public string farmacia1 { get; set; }
        public string numero { get; set; }
        public string extension { get; set; }
        public string representante { get; set; }
        public string cedulaRepresentante { get; set; }
        public string celularRepresentante { get; set; }
        public string tipoFarmacia { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        public virtual Establecimiento Establecimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicamento> Medicamento { get; set; }
    }
}
