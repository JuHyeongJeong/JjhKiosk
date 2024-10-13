using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuOptionGroup
{
    public uint OptionGroupId { get; set; }

    public string? OptionGroupName { get; set; }

    public uint? MenuTypeId { get; set; }

    public uint? OptionTypeId { get; set; }

    public virtual ICollection<KioskMenuOptionMember> KioskMenuOptionMembers { get; set; } = new List<KioskMenuOptionMember>();

    public virtual KioskMenuType? MenuType { get; set; }

    public virtual KioskMenuOptionType? OptionType { get; set; }
}
