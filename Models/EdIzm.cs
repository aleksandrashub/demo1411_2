﻿using System;
using System.Collections.Generic;

namespace demo1411shubenok.Models;

public partial class EdIzm
{
    public long IdEdIzm { get; set; }

    public string? EdIzm1 { get; set; }

    public virtual ICollection<Prod> Prods { get; set; } = new List<Prod>();
}
