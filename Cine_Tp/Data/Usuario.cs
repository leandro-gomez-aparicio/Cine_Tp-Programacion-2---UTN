﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cine_Tp.Data;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string NombreUsuario { get; set; }

    public string Contraseña { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; }

    //public Usuario(string nombre, string contraseña) {
    
    //}
}