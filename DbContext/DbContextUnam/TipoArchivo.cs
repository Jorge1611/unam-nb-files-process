namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES.TipoArchivo")]
    public partial class TipoArchivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoArchivo()
        {
            Archivo = new HashSet<Archivo>();
        }

        [Key]
        public int PK_IdTipoArchivo { get; set; }

        public int FK_IdGrupoTipoArchivo__FILES { get; set; }

        [Required]
        [StringLength(5)]
        public string FK_IdTipoAlmacenamiento__FILES { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string MimeType { get; set; }

        [Required]
        [StringLength(50)]
        public string Extension { get; set; }

        public bool CT_LIVE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_CREATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_UPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archivo> Archivo { get; set; }

        public virtual GrupoTipoArchivo GrupoTipoArchivo { get; set; }

        public virtual TipoAlmacenamiento TipoAlmacenamiento { get; set; }
    }
}
