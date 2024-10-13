using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskOrder
{
    public string OrderId { get; set; } = null!;

    public uint? FullPrice { get; set; }

    public DateTime OrderDate { get; set; }

    public byte? StatusTypeId { get; set; }

    public uint? StoreId { get; set; }

    public virtual ICollection<KioskOrderCart> KioskOrderCarts { get; set; } = new List<KioskOrderCart>();

    public virtual KioskOrderStatusType? StatusType { get; set; }

    public virtual KioskStoreList? Store { get; set; }
}
