//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiRestProveedores.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class proveedor
    {
        public int id { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public int id_localidad { get; set; }
        public string nombre { get; set; }
    
        public virtual estado estado { get; set; }
        public virtual localidad localidad { get; set; }
        public virtual municipio municipio { get; set; }
    }
}
