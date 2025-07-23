using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuCategory
{
    public uint MenuCategoryId { get; set; }

    public string? MenuCategoryName { get; set; }

    public uint? StoreId { get; set; }

    public virtual ICollection<KioskMenuList> KioskMenuLists { get; set; } = new List<KioskMenuList>();

    public virtual KioskStoreList? Store { get; set; }
}
