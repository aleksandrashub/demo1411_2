using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Zakaz
{
    public long IdZakaz { get; set; }

    public DateOnly? DateCr { get; set; }

    public DateOnly? DeteDeliv { get; set; }

    public long? IdPunkt { get; set; }

    public long? IdClient { get; set; }

    public long? Code { get; set; }

    public long? IdStat { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Punkt? IdPunktNavigation { get; set; }

    public virtual Status? IdStatNavigation { get; set; }

    public virtual ICollection<ZakazPr> ZakazPrs { get; set; } = new List<ZakazPr>();
}
