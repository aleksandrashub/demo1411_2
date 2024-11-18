using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class Prod
{
    public long IdProd { get; set; }

    public string? Articul { get; set; }

    public string? Name { get; set; }

    public long? IdEdIzm { get; set; }

    public long? Cost { get; set; }

    public float? MaxDisc { get; set; }

    public long? IdMan { get; set; }

    public long? IdCust { get; set; }

    public long? IdCateg { get; set; }

    public float? CurrDisc { get; set; }

    public long? QuanSkl { get; set; }

    public string? Descr { get; set; }

    public string? Image { get; set; }

    public virtual Categ? IdCategNavigation { get; set; }

    public virtual Cust? IdCustNavigation { get; set; }

    public virtual EdIzm? IdEdIzmNavigation { get; set; }

    public virtual Manuf? IdManNavigation { get; set; }

    public virtual ICollection<ZakazPr> ZakazPrs { get; set; } = new List<ZakazPr>();

    public Bitmap? bitmap => Image != "" ? new Bitmap($@"Assets\\{Image}") : null;

    public bool CostVisible => CurrDisc!=0 ? true : false;
    public float? ItogCost => Cost - (Cost*CurrDisc/100);
    //? new Bitmap($@"Assets\\picture_zagl.png") : null;

}
