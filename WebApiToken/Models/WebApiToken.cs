//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiToken.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TokenEntity
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Authtoken { get; set; }
        public Nullable<System.DateTime> IssuedOn { get; set; }
        public Nullable<System.DateTime> ExpiryOn { get; set; }
    }
}
