using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using TodoAPI.Models;


namespace TodoAPI.Interfaces
{
    public interface IToDoRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<TodoItems> All { get; }
        TodoItems Find(string id);
        void Insert(TodoItems item);
        void Update(TodoItems item);
        void Delete(string id);

        IEnumerable<Registrado> GetCredenciales(string Login, string Pwd);
        IEnumerable<Registrado> ListRegistrados { get; }
        IEnumerable<Works> ListWorksRegistradosPerfil { get; }
        IEnumerable<Products> ListProductsRegistradosPerfil { get; }
        IEnumerable<Registrado> Registrado (string EmailRegistrado);
        IEnumerable<Registrado> RegistradoById(string IdRegistrado);

        IEnumerable<PerfilDuo> RegistradoPerfil(string EmailRegistrado);
        IEnumerable<PerfilDuo> ListRegistradosPerfil { get; }
        IEnumerable<Works> RegistradoWorks(string RegPerfilId);
        IEnumerable<Works> RegistradoPerfilWork(string RegPerfilId);
        IEnumerable<Works> WorksPerfil(string IdWorks);
        IEnumerable<Products> ProductsPerfil(string IdProduct);

        IEnumerable<Products> RegistradoProducts(string RegPerfilId);
        IEnumerable<Products> RegistradoProductPerfil(string RegPerfilId);
        IEnumerable<Anuncio> RegistradoAnuncio(string RegAnuncioId);
        IEnumerable<Anuncio> RegistradoAnuncios { get; }
        IEnumerable<AnuncioImages> RegistradoAnuncioImages(string RegAnuncioId);
        void InsertRegistro(Registrado item);
        void InsertRegistroPerfil(PerfilDuoTnq item);
        void InsertRegistroWorks(WorksTnq item);
        void InsertRegistroProducts(ProductsTnq item);
        void InsertRegistroAnuncio(AnuncioTnq item);

        //IEnumerable<Afiliados> ListAfiliados { get; }
        //IEnumerable<Afiliados> Afiliado(int IdAfiliado);
        //IEnumerable<Productosafiliados> ListProductosAfiliados { get; }
        //IEnumerable<Productosafiliados> ProductosAfiliado(int IdAfiliado);

        //IEnumerable<Promociones> ListPromociones { get; }

        //IEnumerable<Afiliados> ListRestaurantes { get; }
        //IEnumerable<Afiliados> ListComidaRapidaPiqueos { get; }
        //IEnumerable<Afiliados> ListTiendasLicoreras { get; }
        //IEnumerable<Afiliados> ListSalud { get; }
        //IEnumerable<Afiliados> ListVarios { get; }
    }
}
