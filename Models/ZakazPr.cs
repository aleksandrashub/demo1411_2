using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class ZakazPr
{
    public long IdZakaz { get; set; }

    public long IdProd { get; set; }

    public long? Amount { get; set; }

    public virtual Prod IdProdNavigation { get; set; } = null!;

    public virtual Zakaz IdZakazNavigation { get; set; } = null!;
}
