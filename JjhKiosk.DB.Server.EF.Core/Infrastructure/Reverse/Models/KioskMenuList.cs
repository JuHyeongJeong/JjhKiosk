using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuList
{
    public uint MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public uint Price { get; set; }

    public uint? StoreId { get; set; }

    public uint? MenuTypeId { get; set; }

    public virtual ICollection<KioskOrderCart> KioskOrderCarts { get; set; } = new List<KioskOrderCart>();

    public virtual KioskMenuType? MenuType { get; set; }

    public virtual KioskStoreList? Store { get; set; }
}
