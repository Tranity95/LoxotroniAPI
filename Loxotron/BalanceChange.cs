using System;
using System.Collections.Generic;

namespace Loxotron;

public partial class BalanceChange
{
    public int Id { get; set; }

    public decimal Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
