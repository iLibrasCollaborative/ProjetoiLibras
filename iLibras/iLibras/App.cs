using System;
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
        public static string BackendUrl = "https://localhost:5000";
        static CategoriaItemDatabase databaseCategoria;
        static TagItemDatabase databaseTag;
        static UsuarioItemDatabase databaseUsuario;
        static EstadoItemDatabase databaseEstado;
        static Usuario user;

        public App()
        {
            //InitializeComponent();
            MainPage = new MainPage();
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

        public static Usuario User
        {
            get 
            {
                if (user == null)
                    user = new Usuario();
                
                return user; 
            }    
        }
    }
}
