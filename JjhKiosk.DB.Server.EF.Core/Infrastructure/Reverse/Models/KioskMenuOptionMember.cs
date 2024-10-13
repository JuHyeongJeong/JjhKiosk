using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuOptionMember
{
    public uint OptionMemberId { get; set; }

    public string? OptionMemberName { get; set; }

    public uint OptionMemberPrice { get; set; }

    public uint OptionGroupId { get; set; }

    public virtual KioskMenuOptionGroup OptionGroup { get; set; } = null!;
}
