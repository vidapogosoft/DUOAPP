using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoRepository : IToDoRepository
    {
        private List<TodoItems> _toDoList;

        public TodoRepository()
        {
            //InitializeData();
        }

        //Inicio de tipos de negocio de afiliados

        public IEnumerable<Registrado> GetCredenciales(string Login, string Pwd)
        { return CargaCredenciales(Login,Pwd); }

        public IEnumerable<PerfilDuo> ListRegistradosPerfil
        { get { return CargaRegistradosPerfil(); } }

        public IEnumerable<Works> ListWorksRegistradosPerfil
        { get { return CargaWorksRegistradosPerfil(); } }

        public IEnumerable<Products> ListProductsRegistradosPerfil
        { get { return CargaProductsRegistradosPerfil(); } }

        public IEnumerable<Registrado> ListRegistrados
        { get { return CargaRegistrados(); } }

        public IEnumerable<Registrado> Registrado(string EmailRegistrado)
        { return CargaRegistrado(EmailRegistrado); }

        public IEnumerable<Registrado> RegistradoById(string IdRegistrado)
        { return CargaRegistradoById(IdRegistrado); }

        public IEnumerable<PerfilDuo> RegistradoPerfil(string EmailRegistrado)
        { return CargaRegistradoPerfil(EmailRegistrado); }

        public IEnumerable<Works> RegistradoWorks(string RegPerfilId)
        { return CargaWorks(RegPerfilId); }

        public IEnumerable<Works> RegistradoPerfilWork(string RegPerfilId)
        { return CargaWorkPerfil(RegPerfilId); }

        public IEnumerable<Products> RegistradoProducts(string RegPerfilId)
        { return CargaProducts(RegPerfilId); }

        public IEnumerable<Products> RegistradoProductPerfil(string RegPerfilId)
        { return CargaProductPerfil(RegPerfilId); }

        public IEnumerable<Works> WorksPerfil(string IdWorks)
        { return WorkPerfilDuo(IdWorks); }

        public IEnumerable<Products> ProductsPerfil(string IdProducts)
        { return ProductsPerfilDuo(IdProducts); }

        public IEnumerable<Anuncio> RegistradoAnuncio(string RegId)
        { return CargaAnuncio(RegId); }

        public IEnumerable<Anuncio> RegistradoAnuncios
        { get { return CargaAnuncios(); } }

        public IEnumerable<AnuncioImages> RegistradoAnuncioImages(string RegAnuncioId)
        { return CargaAnuncioImages(RegAnuncioId); }

        //public IEnumerable<Afiliados> ListRestaurantes
        //{ get { return CargaAfiliadosRestaurantes(); } }

        //public IEnumerable<Afiliados> ListComidaRapidaPiqueos
        //{ get { return CargaAfiliadosComidaRapidaPiqueos(); } }

        //public IEnumerable<Afiliados> ListTiendasLicoreras
        //{ get { return CargaAfiliadosTiendasLicoreras(); } }

        //public IEnumerable<Afiliados> ListSalud
        //{ get { return CargaAfiliadosSalud(); } }

        //public IEnumerable<Afiliados> ListVarios
        //{ get { return CargaAfiliadosVarios(); } }

        ////Afiliado en total
        //public IEnumerable<Afiliados> ListAfiliados
        //{ get { return CargaAfiliados(); } }

        ////Fin de tipos de negocio

        //public IEnumerable<Promociones> ListPromociones
        //{ get { return CargaPromociones(); } }

        public IEnumerable<TodoItems> All
        { get { return _toDoList; } }


        //public IEnumerable<Productosafiliados> ListProductosAfiliados
        //{ get { return CargaProductosAfiliados(); } }

        //public IEnumerable<Productosafiliados> ProductosAfiliado(int IdAfiliado)
        //{ return CargaProductosAfiliado(IdAfiliado); }

        //public IEnumerable<Afiliados> Afiliado(int IdAfiliado)
        //{ return CargaAfiliado(IdAfiliado); }

        public void Delete(string id)
        {
            _toDoList.Remove(this.Find(id));
        }

        public bool DoesItemExist(string id)
        {
            return _toDoList.Any(item => item.ID == id);
        }

        public TodoItems Find(string id)
        {
            return _toDoList.FirstOrDefault(item=> item.ID == id);
        }

        public void Insert(TodoItems item)
        {
            _toDoList.Add(item);
        }

        public void Update(TodoItems item)
        {
            var todoItem = this.Find(item.ID);
            var index = _toDoList.IndexOf(todoItem);
            _toDoList.RemoveAt(index);
            _toDoList.Insert(index, item);
        }

        private void InitializeData()
        {
            _toDoList = new List<TodoItems>();

            var todoItem1 = new TodoItems
            {
                ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Xamarin University",
                Done = true
            };


            var todoItem2 = new TodoItems
            {
                ID = "6bb8a868-d93b7-94ebce87e243",
                Name = "Api development",
                Notes = "MVA University",
                Done = false
            };

            var todoItem3 = new TodoItems
            {
                ID = "CC8a968-d93b7-94ebce87e290",
                Name = "Publish Apps in Market",
                Notes = "Sipecom",
                Done = false
            };

            _toDoList.Add(todoItem1);
            _toDoList.Add(todoItem2);
            _toDoList.Add(todoItem3);

        }

        #region registro movil

        public List<Works> WorkPerfilDuo(string IdWorks)
        {
            using (var context = new duoContext())
            {
                return context.Works.Where(a => a.RegWorksId == int.Parse(IdWorks)).ToList();
            }
        }

        public List<Products> ProductsPerfilDuo(string IdProduct)
        {
            using (var context = new duoContext())
            {
                return context.Products.Where(a => a.RegProductId == int.Parse(IdProduct)).ToList();
            }
        }

        public List<Registrado> CargaCredenciales(string Login, string Pwd)
        {
            using (var context = new duoContext())
            {
                return context.Registrado.Where(a => a.RegEmail == Login && a.RegContrasenia == Pwd)
                    .ToList();
            }
        }
        public List<Products> CargaProducts(string RegPerfilId)
        {
            using (var context = new duoContext())
            {
                return context.Products.Where(a => a.RegPerfilId == int.Parse(RegPerfilId) && a.IsNew == 0)
                    .OrderByDescending(a=> a.RegProductId).ToList();
            }
        }

        public List<Products> CargaProductPerfil(string RegPerfilId)
        {
            using (var context = new duoContext())
            {
                return context.Products.Where(a => a.RegPerfilId == int.Parse(RegPerfilId) && a.IsNew == 1)
                    .OrderByDescending(a => a.RegProductId).Take(1).ToList();
            }
        }

        public List<Works> CargaWorks(string RegPerfilId)
        {
            using (var context = new duoContext())
            {
                return context.Works.Where(a => a.RegPerfilId == int.Parse(RegPerfilId) && a.IsNew == 0)
                    .OrderByDescending(a => a.RegWorksId).ToList();
            }
        }

        public List<Works> CargaWorkPerfil(string RegPerfilId)
        {
            using (var context = new duoContext())
            {
                return context.Works.Where(a => a.RegPerfilId == int.Parse(RegPerfilId) && a.IsNew == 1)
                    .OrderByDescending(a => a.RegWorksId).Take(1).ToList();
            }
        }

        public List<Registrado> CargaRegistrado(string EmailRegistrado)
        {
            using (var context = new duoContext())
            {
                return context.Registrado.Where(a => a.RegEmail == EmailRegistrado)
                    .ToList();
            }
        }

        public List<Registrado> CargaRegistradoById(string IdRegistrado)
        {
            using (var context = new duoContext())
            {
                return context.Registrado.Where(a => a.RegId == int.Parse(IdRegistrado))
                    .ToList();
            }
        }

        public List<PerfilDuo> CargaRegistradoPerfil(string EmailRegistrado)
        {
            using (var context = new duoContext())
            {
                return context.PerfilDuo.Where(a => a.RegEmail == EmailRegistrado)
                    .ToList();
            }
        }

        public List<PerfilDuo> CargaRegistradosPerfil()
        {
            using (var context = new duoContext())
            {
                return context.PerfilDuo
                    .OrderByDescending(a => a.RegPerfilId).ToList();
            }
        }

        public List<Works> CargaWorksRegistradosPerfil()
        {
            using (var context = new duoContext())
            {
                return context.Works
                    .ToList();
            }
        }

        public List<Products> CargaProductsRegistradosPerfil()
        {
            using (var context = new duoContext())
            {
                return context.Products
                    .ToList();
            }
        }

        public List<Registrado> CargaRegistrados()
        {
            using (var context = new duoContext())
            {
                return context.Registrado
                    .OrderByDescending(a => a.RegId).ToList();
            }
        }

        public void InsertRegistro(Registrado item)
        {
            using (var context = new duoContext())
            {
                context.Registrado.Add(item);
                context.SaveChanges();
            }
        }

        public List<Anuncio> CargaAnuncio(string RegId)
        {
            using (var context = new duoContext())
            {
                return context.Anuncio.Where(a => a.RegId == int.Parse(RegId) && a.RegAnuncioEstado == "ACTIVO")
                    .OrderByDescending(a => a.RegAnuncioId).ToList();
            }
        }

        public List<Anuncio> CargaAnuncios()
        {
            using (var context = new duoContext())
            {
                return context.Anuncio.Where(a => a.RegAnuncioEstado == "ACTIVO")
                    .OrderByDescending(a => a.RegAnuncioId).ToList();
            }
        }

        public List<AnuncioImages> CargaAnuncioImages(string RegAnuncioId)
        {
            using (var context = new duoContext())
            {
                return context.AnuncioImages.Where(a => a.RegAnuncioId == int.Parse(RegAnuncioId))
                    .OrderByDescending(a => a.RegAnuncioImagenId).ToList();
            }
        }
        public void InsertRegistroPerfil(PerfilDuoTnq item)
        {
            using (var context = new duoContext())
            {
                context.PerfilDuoTnq.Add(item);
                context.SaveChanges();
            }
        }

        public void InsertRegistroWorks(WorksTnq item)
        {
            //se utiliza para grabar el registro a borrar en el TNQ

            using (var context = new duoContext())
            {
                context.WorksTnq.Add(item);
                context.SaveChanges();
            }
        }


        public void InsertRegistroProducts(ProductsTnq item)
        {
            //se utiliza para grabar el registro a borrar en el TNQ

            using (var context = new duoContext())
            {
                context.ProductsTnq.Add(item);
                context.SaveChanges();
            }
        }

        public void InsertRegistroAnuncio(AnuncioTnq item)
        {
            //se utiliza para grabar el registro a borrar en el TNQ

            using (var context = new duoContext())
            {
                context.AnuncioTnq.Add(item);
                context.SaveChanges();
            }
        }

        //public List<Afiliados> CargaAfiliados()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a=> a.Estado =="ACTIVO")
        //            .OrderByDescending(a=> a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliadosRestaurantes()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.Estado == "ACTIVO" && a.TipoNegocio == "Restaurantes")
        //            .OrderByDescending(a => a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliadosComidaRapidaPiqueos()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.Estado == "ACTIVO" && a.TipoNegocio == "Comida Rapida/Piqueos")
        //            .OrderByDescending(a => a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliadosTiendasLicoreras()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.Estado == "ACTIVO" && a.TipoNegocio == "Tiendas/Licoreras")
        //            .OrderByDescending(a => a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliadosSalud()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.Estado == "ACTIVO" && a.TipoNegocio == "Salud")
        //            .OrderByDescending(a => a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliadosVarios()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.Estado == "ACTIVO" && a.TipoNegocio == "Varios")
        //            .OrderByDescending(a => a.IdAfiliado).ToList();
        //    }
        //}

        //public List<Productosafiliados> CargaProductosAfiliados()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Productosafiliados.Where(a => a.Estado == "ACTIVO")
        //            .OrderByDescending(a => a.IdProductoAfiliado).ToList();
        //    }
        //}

        //public List<Productosafiliados> CargaProductosAfiliado(int IdAfiliado)
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Productosafiliados.Where(a => a.IdAfiliado == IdAfiliado && a.Estado == "ACTIVO")
        //            .OrderByDescending(a => a.IdProductoAfiliado).ToList();
        //    }
        //}

        //public List<Afiliados> CargaAfiliado(int IdAfiliado)
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Afiliados.Where(a => a.IdAfiliado == IdAfiliado && a.Estado == "ACTIVO")
        //            .ToList();
        //    }
        //}

        //public void InsertRegistro(Afiliados item)
        //{
        //    using (var context = new chopinContext())
        //    {
        //        context.Afiliados.Add(item);
        //        context.SaveChanges();
        //    }
        //}

        //public void UpdateRegistro(Afiliados item)
        //{
        //    using (var context = new chopinContext())
        //    {
        //        context.Update(item);
        //        //context.Attach(item).State = EntityState.Modified;
        //        //context.Entry(item).State = EntityState.Modified;
        //        context.SaveChanges();

        //        //var std = context.Suscritonoticias.FirstOrDefault(a => a.Cedula == item.Cedula );
        //        //std.EmailSuscrito = item.EmailSuscrito;
        //        //context.Update(std);
        //        //context.SaveChanges();

        //    }
        //}

        //public List<Promociones> CargaPromociones()
        //{
        //    using (var context = new chopinContext())
        //    {
        //        return context.Promociones.Where(a => a.Estado == "ACTIVO")
        //            .OrderByDescending(a => a.IdPromocion).ToList();
        //    }
        //}

        #endregion

    }
}
