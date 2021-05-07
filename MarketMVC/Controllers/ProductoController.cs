using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketMVC.Models;

namespace MarketMVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            MarketPlaceEntities entities = new MarketPlaceEntities();
            List<ListProductoVM> lstProductosVM = new List<ListProductoVM>();
            try
            {
                lstProductosVM = (from d in entities.Producto
                                  select new ListProductoVM
                                  {
                                      Id = d.Id,
                                      Nombre = d.Nombre,
                                      Precio = d.Precio,
                                      Stock = d.Stock,
                                      FechaExpiracion = d.FechaExpiracion
                                  }).ToList();
            }
            catch(Exception ex)
            {

            }
            finally{
                entities.Dispose();
            }

            return View(lstProductosVM);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(NuevoProductoVM model)
        {
            MarketPlaceEntities entities = new MarketPlaceEntities();

            try 
            {
                if (ModelState.IsValid)
                {
                    int Id = entities.Producto.Count() + 1;

                    Producto producto = new Producto();
                    producto.Id = model.Id;
                    producto.Nombre = model.Nombre;
                    producto.Precio = model.Precio;
                    producto.Stock = model.Stock;
                    producto.FechaExpiracion = model.FechaExpiracion;
                    entities.Producto.Add(producto);
                    entities.SaveChanges();
                    return Redirect("~/Producto");
                }
            }
            catch (Exception ex) 
            { 
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        public ActionResult Editar(int Id)
        {
            MarketPlaceEntities entities = new MarketPlaceEntities();
            EditarProductoVM model = new EditarProductoVM();

            try
            {
                Producto producto = entities.Producto.Find(Id);

                if (producto != null)
                {
                    model.Id = producto.Id;
                    model.Nombre = producto.Nombre;
                    model.Precio = producto.Precio;
                    model.Stock = producto.Stock;
                    model.FechaExpiracion = producto.FechaExpiracion;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarProductoVM model)
        {
            MarketPlaceEntities entities = new MarketPlaceEntities();

            try
            {
                if (ModelState.IsValid)
                {
                    Producto producto = entities.Producto.Find(model.Id);

                    producto.Nombre = model.Nombre;
                    producto.Precio = model.Precio;
                    producto.Stock = model.Stock;
                    producto.FechaExpiracion = model.FechaExpiracion;
                    entities.Entry(producto).State = System.Data.EntityState.Modified;
                    entities.SaveChanges();
                    return Redirect("~/Producto");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            MarketPlaceEntities entities = new MarketPlaceEntities();

            try
            {
                Producto producto = entities.Producto.Find(Id);

                if (producto != null)
                {
                    entities.Producto.Remove(producto);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                entities.Dispose();
            }

            return Redirect("~/Producto");
        }
    }
}
