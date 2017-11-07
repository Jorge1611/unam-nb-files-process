using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArqSecurity.Model
{
    [Table("RECORD.Usuario")]
    public partial class Usuario
    {
        [Key]
        public string PK_IdUsuario { get; set; }

        [StringLength(50)]
        public string Puesto { get; set; }

        public virtual ApplicationUser AspNetUsers { get; set; }

    }
}
