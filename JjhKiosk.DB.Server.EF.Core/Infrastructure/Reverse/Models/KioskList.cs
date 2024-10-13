using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskList
{
    public uint KioskId { get; set; }

    public string? KioskName { get; set; }

    public DateTime? InstallDate { get; set; }

    public uint? StoreId { get; set; }

    public virtual KioskStoreList? Store { get; set; }
}
