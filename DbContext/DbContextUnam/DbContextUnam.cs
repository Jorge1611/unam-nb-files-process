namespace WA_UNAM_NB_PR.DbContextUnam
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContextUnam : DbContext
    {
        public DbContextUnam()
            : base("name=DbContextUnam")
        {
        }

        public virtual DbSet<Archivo> Archivo { get; set; }
        public virtual DbSet<GrupoTipoArchivo> GrupoTipoArchivo { get; set; }
        public virtual DbSet<Md5File> Md5File { get; set; }
        public virtual DbSet<TipoAlmacenamiento> TipoAlmacenamiento { get; set; }
        public virtual DbSet<TipoArchivo> TipoArchivo { get; set; }
        public virtual DbSet<Procedimiento> Procedimiento { get; set; }
        public virtual DbSet<TipoEstatusResultado> TipoEstatusResultado { get; set; }
        public virtual DbSet<TipoPrioridad> TipoPrioridad { get; set; }
        public virtual DbSet<Estudio> Estudio { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<TipoRolEstudio> TipoRolEstudio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioEstudio> UsuarioEstudio { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>()
                .HasOptional(e => e.Estudio)
                .WithRequired(e => e.Archivo);

            modelBuilder.Entity<GrupoTipoArchivo>()
                .HasMany(e => e.TipoArchivo)
                .WithRequired(e => e.GrupoTipoArchivo)
                .HasForeignKey(e => e.FK_IdGrupoTipoArchivo__FILES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Md5File>()
                .Property(e => e.PathFile)
                .IsUnicode(false);

            modelBuilder.Entity<Md5File>()
                .HasMany(e => e.Archivo)
                .WithRequired(e => e.Md5File)
                .HasForeignKey(e => e.FK_IdMd5File__FILES);

            modelBuilder.Entity<TipoAlmacenamiento>()
                .Property(e => e.PK_IdTipoAlmacenamiento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoAlmacenamiento>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoAlmacenamiento>()
                .HasMany(e => e.TipoArchivo)
                .WithRequired(e => e.TipoAlmacenamiento)
                .HasForeignKey(e => e.FK_IdTipoAlmacenamiento__FILES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoArchivo>()
                .Property(e => e.FK_IdTipoAlmacenamiento__FILES)
                .IsUnicode(false);

            modelBuilder.Entity<TipoArchivo>()
                .HasMany(e => e.Archivo)
                .WithRequired(e => e.TipoArchivo)
                .HasForeignKey(e => e.FK_IdTipoArchivo__FILES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedimiento>()
                .HasMany(e => e.Resultado)
                .WithRequired(e => e.Procedimiento)
                .HasForeignKey(e => e.FK_IdProcedimiento__PROCESS);

            modelBuilder.Entity<TipoEstatusResultado>()
                .HasMany(e => e.Resultado)
                .WithRequired(e => e.TipoEstatusResultado)
                .HasForeignKey(e => e.FK_IdTipoEstatusResultado__PROCESS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPrioridad>()
                .HasMany(e => e.Procedimiento)
                .WithRequired(e => e.TipoPrioridad)
                .HasForeignKey(e => e.FK_IdTipoPrioridad__PROCESS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPrioridad>()
                .HasMany(e => e.Estudio)
                .WithRequired(e => e.TipoPrioridad)
                .HasForeignKey(e => e.FK_IdTipoPrioridad__PROCESS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudio>()
                .HasMany(e => e.Resultado)
                .WithRequired(e => e.Estudio)
                .HasForeignKey(e => e.FK_IdEstudio__RECORD);

            modelBuilder.Entity<Estudio>()
                .HasMany(e => e.UsuarioEstudio)
                .WithRequired(e => e.Estudio)
                .HasForeignKey(e => e.FK_IdEstudio__RECORD);

            modelBuilder.Entity<TipoRolEstudio>()
                .HasMany(e => e.UsuarioEstudio)
                .WithRequired(e => e.TipoRolEstudio)
                .HasForeignKey(e => e.FK_IdTipoRolEstudio__RECORD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Procedimiento)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IdUsuario__RECORD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuarioEstudio)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IdUsuario__RECORD)
                .WillCascadeOnDelete(false);
        }
    }
}
