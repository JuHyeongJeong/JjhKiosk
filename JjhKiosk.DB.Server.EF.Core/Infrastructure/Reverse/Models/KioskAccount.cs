using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskAccount
{
    public uint UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public uint? StoreId { get; set; }

    public string? Salt { get; set; }

    public virtual KioskStoreList? Store { get; set; }
}
