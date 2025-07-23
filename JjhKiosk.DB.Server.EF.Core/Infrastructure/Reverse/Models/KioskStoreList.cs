using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskStoreList
{
    public uint StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public string? TelNumber { get; set; }

    public DateTime? RegiDate { get; set; }

    public sbyte? StoreTypeNumber { get; set; }

    public string? Description { get; set; }

    public string? Owner { get; set; }

    public virtual ICollection<KioskAccount> KioskAccounts { get; set; } = new List<KioskAccount>();

    public virtual ICollection<KioskList> KioskLists { get; set; } = new List<KioskList>();

    public virtual ICollection<KioskMenuCategory> KioskMenuCategories { get; set; } = new List<KioskMenuCategory>();

    public virtual ICollection<KioskOrder> KioskOrders { get; set; } = new List<KioskOrder>();

    public virtual KioskStoreType? StoreTypeNumberNavigation { get; set; }
}
