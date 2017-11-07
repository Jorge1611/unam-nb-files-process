namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FILES.Md5File")]
    public partial class Md5File
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Md5File()
        {
            Archivo = new HashSet<Archivo>();
        }

        [Key]
        public Guid PK_IdMd5File { get; set; }

        public int ContentLength { get; set; }

        public string PathFile { get; set; }

        public byte[] BufferFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archivo> Archivo { get; set; }
    }
}
