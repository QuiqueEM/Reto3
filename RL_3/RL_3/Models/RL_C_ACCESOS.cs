
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace RL_3.Models
{

using System;
    using System.Collections.Generic;
    
public partial class RL_C_ACCESOS
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public RL_C_ACCESOS()
    {

        this.RL_EMPLEADO_ENTRADA = new HashSet<RL_EMPLEADO_ENTRADA>();

        this.RL_EMPLEADO_SALIDA = new HashSet<RL_EMPLEADO_SALIDA>();

    }


    public int ID_ACCESO { get; set; }

    public string DESC_ACCESO { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<RL_EMPLEADO_ENTRADA> RL_EMPLEADO_ENTRADA { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<RL_EMPLEADO_SALIDA> RL_EMPLEADO_SALIDA { get; set; }

}

}
