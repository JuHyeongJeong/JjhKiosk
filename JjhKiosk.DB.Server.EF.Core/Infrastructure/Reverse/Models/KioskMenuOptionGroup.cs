using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuOptionGroup
{
    public uint OptionGroupId { get; set; }

    public string? OptionGroupName { get; set; }

    public uint? MenuTypeId { get; set; }

    public uint? OptionTypeId { get; set; }

    public virtual ICollection<KioskMenuOptionLinker> KioskMenuOptionLinkers { get; set; } = new List<KioskMenuOptionLinker>();

    public virtual KioskMenuType? MenuType { get; set; }

    public virtual KioskMenuOptionType? OptionType { get; set; }
}
