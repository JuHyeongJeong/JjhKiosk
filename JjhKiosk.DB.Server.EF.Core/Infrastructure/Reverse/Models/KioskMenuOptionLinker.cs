using System;
using System.Collections.Generic;

namespace JjhKiosk.DB.Server.EF.Core.Infrastructure.Reverse.Models;

public partial class KioskMenuOptionLinker
{
    public uint LinkerId { get; set; }

    public uint? OptionGroupId { get; set; }

    public uint? OptionMemberId { get; set; }

    public uint? OptionTypeId { get; set; }

    public virtual KioskMenuOptionGroup? OptionGroup { get; set; }

    public virtual KioskMenuOptionMember? OptionMember { get; set; }

    public virtual KioskMenuOptionType? OptionType { get; set; }
}
