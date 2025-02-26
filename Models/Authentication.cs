using System;
using System.Collections.Generic;

namespace BackendRestApi.Models;

public partial class Authentication
{
    public int id { get; set; }

    public string username { get; set; } = null!;

    public string password_hash { get; set; } = null!;
}
