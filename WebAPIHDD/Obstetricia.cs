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
    
    public partial class Obstetricia
    {
        public int idObstetricia { get; set; }
        public Nullable<int> idPaciente { get; set; }
        public Nullable<System.DateTime> fecPrimerParto { get; set; }
        public Nullable<int> gestas { get; set; }
        public Nullable<int> partos { get; set; }
        public Nullable<int> cesareas { get; set; }
    
        public virtual Paciente Paciente { get; set; }
    }
}
