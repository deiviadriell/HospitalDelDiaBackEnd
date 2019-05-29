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
    
    public partial class Hospitalizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hospitalizacion()
        {
            this.MedicamentoHospitalizacion = new HashSet<MedicamentoHospitalizacion>();
        }
    
        public int idHospitalizacion { get; set; }
        public Nullable<int> idPaciente { get; set; }
        public Nullable<int> idCondicionEgreso { get; set; }
        public Nullable<int> idEspecialidadEgreso { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public Nullable<System.DateTime> fechaEgreso { get; set; }
        public Nullable<System.TimeSpan> horaIngreso { get; set; }
        public string afeccionPrincipal { get; set; }
        public string otrasAfecciones { get; set; }
        public string otrasAfecciones2 { get; set; }
        public string causaExterna { get; set; }
        public Nullable<int> idCodigoCIEAfeccionPrincipal { get; set; }
        public Nullable<int> idCodigoCIEAfeccionSecundaria { get; set; }
        public Nullable<int> idCodigoCIECausaExterna { get; set; }
        public Nullable<bool> alta { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        public virtual CodigoCIE CodigoCIE { get; set; }
        public virtual CodigoCIE CodigoCIE1 { get; set; }
        public virtual CodigoCIE CodigoCIE2 { get; set; }
        public virtual CondicionEgreso CondicionEgreso { get; set; }
        public virtual EspecialidadEgreso EspecialidadEgreso { get; set; }
        public virtual Paciente Paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicamentoHospitalizacion> MedicamentoHospitalizacion { get; set; }
    }
}