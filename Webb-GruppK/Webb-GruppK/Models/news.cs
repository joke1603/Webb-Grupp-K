
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Webb_GruppK.Models
{

using System;
    using System.Collections.Generic;
    
public partial class news
{

    public int Id { get; set; }

    public Nullable<int> programid { get; set; }



    public virtual program program { get; set; }

}

}
