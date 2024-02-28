using System;
using System.Collections.Generic;

namespace Loxotron;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Balance { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BalanceChange> BalanceChanges { get; set; } = new List<BalanceChange>();
}
