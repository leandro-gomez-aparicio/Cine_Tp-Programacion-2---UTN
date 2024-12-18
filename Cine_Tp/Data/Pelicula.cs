﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cine_Tp.Data;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Nombre { get; set; }

    public int? Duracion { get; set; }

    public int? IdRestriccion { get; set; }

    public int? IdGenero { get; set; }

    public bool? Estreno { get; set; }
    public decimal Precio { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public virtual ICollection<Funciones> Funciones { get; set; } = new List<Funciones>();

    public virtual Genero IdGeneroNavigation { get; set; }

    public virtual Restriccione IdRestriccionNavigation { get; set; }
}