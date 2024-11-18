using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Manuf
{
    public long IdManuf { get; set; }

    public string? Manuf1 { get; set; }

    public virtual ICollection<Prod> Prods { get; set; } = new List<Prod>();
}
