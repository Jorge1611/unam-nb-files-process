namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROCESS.TipoEstatusResultado")]
    public partial class TipoEstatusResultado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoEstatusResultado()
        {
            Resultado = new HashSet<Resultado>();
        }

        [Key]
        public int PK_IdTipoEstatusResultado { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resultado> Resultado { get; set; }
    }
}
