namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECORD.Resultado")]
    public partial class Resultado
    {
        [Key]
        [Column(Order = 0)]
        public Guid FK_IdEstudio__RECORD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_IdProcedimiento__PROCESS { get; set; }

        public int FK_IdTipoEstatusResultado__PROCESS { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FechaRegistro { get; set; }

        public bool CT_LIVE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_CREATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_UPDATE { get; set; }

        public virtual Procedimiento Procedimiento { get; set; }

        public virtual TipoEstatusResultado TipoEstatusResultado { get; set; }

        public virtual Estudio Estudio { get; set; }
    }
}
