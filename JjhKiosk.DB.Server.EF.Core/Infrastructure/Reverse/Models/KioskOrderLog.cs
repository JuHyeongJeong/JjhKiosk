using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskOrderLog
{
    public DateTime OrderDate { get; set; }

    public int? FullPrice { get; set; }

    public uint? StoreId { get; set; }

    public string? MenuDescription { get; set; }

    public byte? StatusTypeId { get; set; }

    public string? OrderId { get; set; }

    public virtual KioskOrder? Order { get; set; }

    public virtual KioskOrderStatusType? StatusType { get; set; }
}
