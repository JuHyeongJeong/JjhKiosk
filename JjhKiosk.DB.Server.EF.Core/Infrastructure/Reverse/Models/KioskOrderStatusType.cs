using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskOrderStatusType
{
    public byte StatusTypeId { get; set; }

    public string? StatusTypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KioskOrder> KioskOrders { get; set; } = new List<KioskOrder>();
}
