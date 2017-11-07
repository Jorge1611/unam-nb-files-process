namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES.Archivo")]
    public partial class Archivo
    {
        [Key]
        public Guid PK_IdArchivo { get; set; }

        public Guid FK_IdMd5File__FILES { get; set; }

        public int FK_IdTipoArchivo__FILES { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Column(TypeName = "xml")]
        [Required]
        public string MetaData { get; set; }

        public bool CT_LIVE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_CREATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_UPDATE { get; set; }

        public virtual Md5File Md5File { get; set; }

        public virtual TipoArchivo TipoArchivo { get; set; }

        public virtual Estudio Estudio { get; set; }
    }
}
