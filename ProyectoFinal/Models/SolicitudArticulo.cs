using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class SolicitudArticulo
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Empleado Solicitante")]
        [Required]
        public string Empleado { get; set; }
        [DisplayName("Fecha de solicitud")]
        public DateTime FechaSolicitud { get; set; }
        [Required]
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Unidad de Medida")]
        public string UnidadMedida { get; set; }
        public bool Estado { get; set; }
    }

    public class ProjectDbContext : ApplicationDbContext
    {
        public DbSet<SolicitudArticulo> SolicitudArticulos { get; set; }
    }
}