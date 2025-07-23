using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuOptionType
{
    public uint OptionTypeId { get; set; }

    public string? OptionTypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KioskMenuOptionGroup> KioskMenuOptionGroups { get; set; } = new List<KioskMenuOptionGroup>();

    public virtual ICollection<KioskMenuOptionLinker> KioskMenuOptionLinkers { get; set; } = new List<KioskMenuOptionLinker>();
}
