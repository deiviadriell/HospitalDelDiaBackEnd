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
    
    public partial class CategoriaEstudioLaboratorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaEstudioLaboratorio()
        {
            this.EstudioLaboratorio = new HashSet<EstudioLaboratorio>();
        }
    
        public int idCategoriaEstudioLaboratorio { get; set; }
        public string categoriaEstudioLaboratorio1 { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstudioLaboratorio> EstudioLaboratorio { get; set; }
    }
}
