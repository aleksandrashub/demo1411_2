using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Cust
{
    public long IdCust { get; set; }

    public string? Cust1 { get; set; }

    public virtual ICollection<Prod> Prods { get; set; } = new List<Prod>();
}
