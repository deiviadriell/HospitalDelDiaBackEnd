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
    
    public partial class Path
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Path()
        {
            this.PermisoPerfil = new HashSet<PermisoPerfil>();
        }
    
        public int idPath { get; set; }
        public Nullable<int> idMenu { get; set; }
        public Nullable<int> idSubMenu { get; set; }
        public string url { get; set; }
        public string icono { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual subMenu subMenu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermisoPerfil> PermisoPerfil { get; set; }
    }
}
