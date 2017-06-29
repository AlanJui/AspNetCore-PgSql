using System;
using System.Collections.Generic;

namespace pgSQL.Models
{
    public partial class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Duration { get; set; }
    }
}
