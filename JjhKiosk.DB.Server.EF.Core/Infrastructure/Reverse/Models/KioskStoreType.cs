using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskStoreType
{
    public sbyte StoreTypeNumber { get; set; }

    public string StoreTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<KioskStoreList> KioskStoreLists { get; set; } = new List<KioskStoreList>();
}
