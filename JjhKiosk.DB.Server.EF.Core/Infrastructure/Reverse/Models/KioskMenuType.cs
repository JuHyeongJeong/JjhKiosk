using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuType
{
    public uint MenuTypeId { get; set; }

    public string? MenuTypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KioskMenuList> KioskMenuLists { get; set; } = new List<KioskMenuList>();

    public virtual ICollection<KioskMenuOptionGroup> KioskMenuOptionGroups { get; set; } = new List<KioskMenuOptionGroup>();
}
