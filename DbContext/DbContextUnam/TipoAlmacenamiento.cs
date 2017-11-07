namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES.TipoAlmacenamiento")]
    public partial class TipoAlmacenamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoAlmacenamiento()
        {
            TipoArchivo = new HashSet<TipoArchivo>();
        }

        [Key]
        [StringLength(5)]
        public string PK_IdTipoAlmacenamiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TipoArchivo> TipoArchivo { get; set; }
    }
}
