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
    
    public partial class Precio
    {
        public int idPrecio { get; set; }
        public Nullable<int> idMedicamento { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaFin { get; set; }
        public Nullable<decimal> precio1 { get; set; }
        public Nullable<bool> grabaIVA { get; set; }
        public Nullable<System.DateTime> borrado { get; set; }
    
        public virtual Medicamento Medicamento { get; set; }
    }
}
