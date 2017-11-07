namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES.GrupoTipoArchivo")]
    public partial class GrupoTipoArchivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrupoTipoArchivo()
        {
            TipoArchivo = new HashSet<TipoArchivo>();
        }

        [Key]
        public int PK_IdGrupoTipoArchivo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public bool CT_LIVE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_CREATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_UPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoArchivo> TipoArchivo { get; set; }
    }
}
