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
    
    public partial class Ginecologia
    {
        public int idGinecologia { get; set; }
        public Nullable<int> idConsulta { get; set; }
    
        public virtual Consulta Consulta { get; set; }
    }
}
