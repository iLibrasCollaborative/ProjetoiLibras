using System;
using System.IO;
using iLibras.Data;
using iLibras.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace iLibras
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:3000";
        static CategoriaItemDatabase databaseCategoria;
        static TagItemDatabase databaseTag;
        static UsuarioItemDatabase databaseUsuario;
        static EstadoItemDatabase databaseEstado;
        static PerfilItemDatabase databasePerfil;
        static SessaoItemDatabase databaseSessao;
        static ContextoItemDatabase databaseContexto;
        static ImagemRepresentativaItemDatabase databaseImagemRepresentativa;
        static SinalItemDatabase databaseSinal;
        static EscritaSinaisItemDatabase databaseEscritaSinais;

        public App()
        {
            MainPage = new SplashPage();
        }

        public static CategoriaItemDatabase DatabaseCategoria
        {
            get
            {
                if (databaseCategoria == null)
                    databaseCategoria = new CategoriaItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseCategoria;
            }
        }

        public static TagItemDatabase DatabaseTag
        {
            get
            {
                if (databaseTag == null)
                    databaseTag = new TagItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseTag;
            }
        }

        public static UsuarioItemDatabase DatabaseUsuario
        {
            get
            {
                if (databaseUsuario == null)
                    databaseUsuario = new UsuarioItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseUsuario;
            }
        }

        public static EstadoItemDatabase DatabaseEstado
        {
            get
            {
                if (databaseEstado == null)
                    databaseEstado = new EstadoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseEstado;
            }
        }

        public static PerfilItemDatabase DatabasePerfil
        {
            get
            {
                if (databasePerfil == null)
                    databasePerfil = new PerfilItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databasePerfil;
            }
        }

        public static SessaoItemDatabase DatabaseSessao
        {
            get
            {
                if (databaseSessao == null)
                    databaseSessao = new SessaoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseSessao;
            }
        }

        public static ContextoItemDatabase DatabaseContexto
        {
            get
            {
                if (databaseContexto == null)
                    databaseContexto = new ContextoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseContexto;
            }
        }

        public static EscritaSinaisItemDatabase DatabaseEscritaSinais
        {
            get
            {
                if (databaseEscritaSinais == null)
                    databaseEscritaSinais = new EscritaSinaisItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseEscritaSinais;
            }
        }

        public static ImagemRepresentativaItemDatabase DatabaseImagemRepresentativa
        {
            get
            {
                if (databaseImagemRepresentativa == null)
                    databaseImagemRepresentativa = new ImagemRepresentativaItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseImagemRepresentativa;
            }
        }

        public static SinalItemDatabase DatabaseSinal
        {
            get
            {
                if (databaseSinal == null)
                    databaseSinal = new SinalItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("iLibrasSQLite.db3"));

                return databaseSinal;
            }
        }

        public static Usuario User { get; set; }
    }
}
