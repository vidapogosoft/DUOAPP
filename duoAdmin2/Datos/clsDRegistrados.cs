using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public class clsDRegistrados
    {
        public List<ModeloDatos.Entidades.clsRegistrado> ConsultarRegistradoById(int IdRegistrado)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.Registrado
                         where a.RegId == IdRegistrado
                         select new ModeloDatos.Entidades.clsRegistrado()
                         {   
                            RegId = a.RegId,
                            RegCodigoUnico = a.RegCodigoUnico,
                            RegNombres = a.RegNombres,
                            RegApellidos= a.RegApellidos,
                            RegNombreCompleto = a.RegNombres + " " + a.RegApellidos,
                            RegContrasenia = a.RegContrasenia,
                            RegEmail = a.RegEmail,
                            RegNumeroCelular = a.RegNumeroCelular,
                            RegFecha = a.RegFecha,
                            AnioReg = a.AnioReg,
                            MesReg = a.MesReg,
                            DiaReg = a.DiaReg,
                            Tecnologia = a.Tecnologia,
                            Legales = a.Legales,
                            Comunicacion = a.Comunicacion,
                            Comercio = a.Comercio,
                            ArteDiseno = a.ArteDiseno,
                            ServiciosTecnicos = a.ServiciosTecnicos,
                            Urbanismo = a.Urbanismo,
                            Emprendimientos = a.Emprendimientos

                  }).ToList();

                return x;
            }
        }

        public int SavePerfilDuo(PerfilDuo Perfil)
        {
            int IdProveedor = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var promo = ctx.PerfilDuo.Where(a => a.RegPerfilId == Perfil.RegPerfilId).ToList();

                if (promo.Count > 0)
                {
                    foreach (PerfilDuo promos in promo)
                    {
                        promos.RegId = Perfil.RegId;
                        promos.RegPerfilId = Perfil.RegPerfilId;
                        //promos.RegProfesion = Perfil.RegProfesion;
                        //promos.RegAcercaDe = Perfil.RegAcercaDe;
                        //promos.RegNombres = Perfil.RegNombres;
                        //promos.RegApellidos = Perfil.RegApellidos;
                        //promos.RegNombresCompletos = Perfil.RegNombres + " " + Perfil.RegApellidos;

                        //promos.RegEmail = Perfil.RegEmail;
                        //promos.RegNumeroCelular = Perfil.RegNumeroCelular;
                        promos.RegFecha = DateTime.Now;
                        promos.AnioReg = DateTime.Now.Year;
                        promos.MesReg = DateTime.Now.Month;
                        promos.DiaReg = DateTime.Now.Day;
                        //promos.Tecnologia = Perfil.Tecnologia;
                        //promos.Legales = Perfil.Legales;
                        //promos.Comunicacion = Perfil.Comunicacion;
                        //promos.Comercio = Perfil.Comercio;
                        //promos.ArteDiseno = Perfil.ArteDiseno;
                        //promos.ServiciosTecnicos = Perfil.ServiciosTecnicos;
                        //promos.Urbanismo = Perfil.Urbanismo;
                        promos.Emprendimientos = true;
                        promos.RegCodigoUnico = Perfil.RegCodigoUnico;
                        promos.RegRutaImagen = Perfil.RegRutaImagen;

                        ctx.SaveChanges();

                        IdProveedor = Perfil.RegPerfilId;
                    }
                }
                else
                {
                    ctx.PerfilDuo.Add(Perfil);
                    ctx.SaveChanges();
                    IdProveedor = Perfil.RegPerfilId;
                }
                
                return IdProveedor;
            }
        }

        public int SaveTrabajoDuo(works Perfil)
        {
            int IdProveedor = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var promo = ctx.works.Where(a => a.RegWorksId == Perfil.RegWorksId).ToList();

                if (promo.Count > 0)
                {
                    foreach (works promos in promo)
                    {
                        promos.RegWorksId = Perfil.RegWorksId;
                        promos.RegPerfilId = Perfil.RegPerfilId;
                        promos.RegId = Perfil.RegId;
                        promos.RegCodigoUnico = Perfil.RegCodigoUnico;
                        promos.RegDescripcion = Perfil.RegDescripcion;
                        promos.RegFecha = DateTime.Now;
                        promos.AnioReg = DateTime.Now.Year;
                        promos.MesReg = DateTime.Now.Month;
                        promos.DiaReg = DateTime.Now.Day;

                        promos.RegRutaImagen = Perfil.RegRutaImagen;

                        ctx.SaveChanges();

                        IdProveedor = Perfil.RegWorksId;
                    }
                    
                }
                else {
                    ctx.works.Add(Perfil);
                    ctx.SaveChanges();
                    IdProveedor = Perfil.RegWorksId;
                }

                return IdProveedor;
            }
        }

        public int SaveProductDuo(Products Perfil)
        {
            int IdProveedor = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var promo = ctx.Products.Where(a => a.RegProductId == Perfil.RegProductId).ToList();

                if (promo.Count > 0)
                {
                    foreach (Products promos in promo)
                    {
                        promos.RegProductId = Perfil.RegProductId;
                        promos.RegPerfilId = Perfil.RegPerfilId;
                        promos.RegId = Perfil.RegId;
                        promos.RegCodigoUnico = Perfil.RegCodigoUnico;
                        promos.RegTituloProducto = Perfil.RegTituloProducto;
                        promos.RegDescripcionProducto = Perfil.RegDescripcionProducto;
                        promos.RegPreciProducto = Perfil.RegPreciProducto;
                        promos.RegFecha = DateTime.Now;
                        promos.AnioReg = DateTime.Now.Year;
                        promos.MesReg = DateTime.Now.Month;
                        promos.DiaReg = DateTime.Now.Day;

                        ctx.SaveChanges();
                        IdProveedor = Perfil.RegProductId;
                    }
                }
                else
                {
                    ctx.Products.Add(Perfil);
                    ctx.SaveChanges();
                    IdProveedor = Perfil.RegProductId;
                }

                return IdProveedor;
            }
        }

        public int SaveAnuncioDuo(Anuncio Ads)
        {
            int IdAnuncio = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
               
                ctx.Anuncio.Add(Ads);
                ctx.SaveChanges();
                IdAnuncio = Ads.RegAnuncioId;
                
                return IdAnuncio;
            }
        }

        public int SaveAnuncioImageDuo(AnuncioImages AdsIm)
        {
            int IdAnuncio = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {

                ctx.AnuncioImages.Add(AdsIm);
                ctx.SaveChanges();
                IdAnuncio = AdsIm.RegAnuncioImagenId;

                return IdAnuncio;
            }
        }

        public List<ModeloDatos.Entidades.clsPerfilDUO> ConsultarPerfilById(int IdRegistrado)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.PerfilDuo
                         where a.RegId == IdRegistrado
                         select new ModeloDatos.Entidades.clsPerfilDUO()
                         {
                             RegPerfilId = a.RegPerfilId,
                             RegId = a.RegId,
                             RegCodigoUnico = a.RegCodigoUnico,
                             RegNombres = a.RegNombres,
                             RegApellidos = a.RegApellidos,
                             RegNombresCompletos = a.RegNombres + " " + a.RegApellidos,
                             RegEmail = a.RegEmail,
                             RegNumeroCelular = a.RegNumeroCelular,
                             RegFecha = a.RegFecha,
                             AnioReg = a.AnioReg,
                             MesReg = a.MesReg,
                             DiaReg = a.DiaReg,
                             Tecnologia = a.Tecnologia,
                             Legales = a.Legales,
                             Comunicacion = a.Comunicacion,
                             Comercio = a.Comercio,
                             ArteDiseno = a.ArteDiseno,
                             ServiciosTecnicos = a.ServiciosTecnicos,
                             Urbanismo = a.Urbanismo,
                             Emprendimientos = a.Emprendimientos,
                             RegProfesion = a.RegProfesion,
                             RegAcercaDe = a.RegAcercaDe,
                             RegRutaImagen = a.RegRutaImagen

                         }).ToList();

                return x;
            }
        }


        public List<ModeloDatos.Entidades.clsPerfilDUO> ConsultarWorksById(int IdRegistrado)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.works
                         where a.RegId == IdRegistrado
                         select new ModeloDatos.Entidades.clsPerfilDUO()
                         {                            
                             RegId = a.RegId,
                             RegCodigoUnico = a.RegCodigoUnico,
                             RegFecha = a.RegFecha,
                             AnioReg = a.AnioReg,
                             MesReg = a.MesReg,
                             DiaReg = a.DiaReg,
                             RegRutaImagen = a.RegRutaImagen

                         }).ToList();

                return x;
            }
        }
    }
}
