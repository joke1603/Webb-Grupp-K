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
    
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            this.personchannels = new HashSet<personchannel>();
        }
    
        public int personid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public Nullable<int> SVT1 { get; set; }
        public Nullable<int> SVT2 { get; set; }
        public Nullable<int> TV3 { get; set; }
        public Nullable<int> TV4 { get; set; }
        public Nullable<int> TV6 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personchannel> personchannels { get; set; }
    }
}
