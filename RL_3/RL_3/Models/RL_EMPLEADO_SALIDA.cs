
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
    
public partial class RL_EMPLEADO_SALIDA
{

    public int ID_CHECADA { get; set; }

    public Nullable<int> EMPLEADO_ID { get; set; }

    public Nullable<System.DateTime> SALIDA { get; set; }

    public Nullable<int> SALIDA_ACCESO { get; set; }



    public virtual RL_C_ACCESOS RL_C_ACCESOS { get; set; }

    public virtual RL_EMPLEADO RL_EMPLEADO { get; set; }

}

}