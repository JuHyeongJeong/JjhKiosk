using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskOrderCart
{
    public byte MenuOrder { get; set; }

    public string OrderId { get; set; } = null!;

    public uint? MenuId { get; set; }

    public ushort Qty { get; set; }

    public virtual KioskMenuList? Menu { get; set; }

    public virtual KioskOrder Order { get; set; } = null!;
}
