﻿using System;
using System.Collections.Generic;

namespace Proy_GreenCity.DOMAIN.Core.Entities;

public partial class Roles
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
}
