using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Categ
{
    public long IdCateg { get; set; }

    public string? Categ1 { get; set; }

    public virtual ICollection<Prod> Prods { get; set; } = new List<Prod>();
}
