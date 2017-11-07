namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECORD.UsuarioEstudio")]
    public partial class UsuarioEstudio
    {
        [Key]
        [Column(Order = 0)]
        public string FK_IdUsuario__RECORD { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid FK_IdEstudio__RECORD { get; set; }

        public int FK_IdTipoRolEstudio__RECORD { get; set; }

        public virtual Estudio Estudio { get; set; }

        public virtual TipoRolEstudio TipoRolEstudio { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
