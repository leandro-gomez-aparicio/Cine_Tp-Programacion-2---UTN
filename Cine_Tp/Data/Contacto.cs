﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cine_Tp.Data;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public int? IdCliente { get; set; }

    public int? IdTipoContacto { get; set; }

    public string DetalleContacto { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }

    public virtual TiposContacto IdTipoContactoNavigation { get; set; }
}