namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROCESS.Procedimiento")]
    public partial class Procedimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Procedimiento()
        {
            Resultado = new HashSet<Resultado>();
        }

        [Key]
        public int PK_IdProcedimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public int FK_IdTipoPrioridad__PROCESS { get; set; }

        [Required]
        [StringLength(128)]
        public string FK_IdUsuario__RECORD { get; set; }

        public bool CT_LIVE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_CREATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CT_UPDATE { get; set; }

        public virtual TipoPrioridad TipoPrioridad { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resultado> Resultado { get; set; }
    }
}
