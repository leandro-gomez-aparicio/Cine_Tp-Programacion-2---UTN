﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cine_Tp.Data;

public partial class Factura
{
    public int NumFactura { get; set; }

    public int? IdCliente { get; set; }

    public DateOnly? FechaFactura { get; set; }

    public int? IdTipoCompra { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Cliente IdClienteNavigation { get; set; }

    public virtual TiposCompra IdTipoCompraNavigation { get; set; }
}