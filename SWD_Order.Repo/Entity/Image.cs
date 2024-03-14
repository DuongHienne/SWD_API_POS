using System;
using System.Collections.Generic;

namespace SWD_Order.Repo.Entity
{
    public partial class Image
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? ImagePath { get; set; }

        public virtual Product? Product { get; set; }
    }
}
