//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public Nullable<int> DocumentType { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Age { get; set; }
        public string Image { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual DocumentType DocumentType1 { get; set; }
    }
}