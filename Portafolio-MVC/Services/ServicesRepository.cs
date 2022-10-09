using Portafolio_MVC.Models;

namespace Portafolio_MVC.Services
{
    public interface IServicesRepository
    {
        List<ProyectDTO> getProyects();
    }

    public class ServicesRepository: IServicesRepository
    {

        public List<ProyectDTO> getProyects()
        {
            return new List<ProyectDTO> {

                new ProyectDTO{
                    Titulo = "Amazon",
                    Descripcion = "E-Commerse de amazon web services",
                    Imagen = "/img/amazon.png",
                    Link = "https://www.amazon.com/-/es/"
                },

                new ProyectDTO{
                    Titulo = "New York Times",
                    Descripcion = "Pagina de noticias en react",
                    Imagen = "/img/nyt.png",
                    Link = "https://www.nytimes.com/international/"
                },

                new ProyectDTO{
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    Imagen = "/img/reddit.png",
                    Link = "https://www.reddit.com/"
                },

                new ProyectDTO{
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para la compra de video juegos",
                    Imagen = "/img/steam.png",
                    Link = "https://store.steampowered.com/games/?l=spanish"
                }
            };
        }
    }
}
