using System;
using System.Collections.Generic;

namespace pgSQL.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BlogSiteUrl { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
