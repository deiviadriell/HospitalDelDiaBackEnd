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
    
    public partial class ConsultaEstudioLaboratorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsultaEstudioLaboratorio()
        {
            this.ResultadoEstudioLaboratorio = new HashSet<ResultadoEstudioLaboratorio>();
        }
    
        public int idConsultaEstudioLaboratorio { get; set; }
        public Nullable<int> idConsulta { get; set; }
        public Nullable<int> idEstudioLaboratorio { get; set; }
        public string observacion { get; set; }
    
        public virtual Consulta Consulta { get; set; }
        public virtual EstudioLaboratorio EstudioLaboratorio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultadoEstudioLaboratorio> ResultadoEstudioLaboratorio { get; set; }
    }
}