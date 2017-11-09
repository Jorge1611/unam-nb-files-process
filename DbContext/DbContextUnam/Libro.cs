namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Libro")]
    public partial class Libro
    {
        [Key]
        public int PK_IdLibro { get; set; }

        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public DateTime? FechaAdquisicion { get; set; }
    }
}