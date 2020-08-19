using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniNext.Context;
using MiniNext.Models;

namespace MiniNext
{
    public class ClienteController : Controller
    {
        private readonly MiniFlixDatabaseContext _context;

        public ClienteController(MiniFlixDatabaseContext context)
        {
            _context = context;
        }


        // GET: Cliente
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
            //return View(await _context.Clientes.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {

            return View();

        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Email,Contraseña,TarjetaCredito,Abono")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cliente", new { @id = cliente.Id });
            }
            return View("Index", "Cliente");
        }

        [HttpPost]
        public ActionResult Login(string Email, string Contraseña)
        {
            Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Email == Email && C.Contraseña == Contraseña);
            if (cliBuscado != null)
            {


                return RedirectToAction("Index", "Cliente", new { @id = cliBuscado.Id });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login(int? id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Email,Contraseña,TarjetaCredito,Abono")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Cliente", new { @id = cliente.Id });
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }


        //[HttpGet]
        //public IActionResult MenuBase(int id)
        //{
        //    Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Id == id);

        //    var peliculaService = new PeliculasServiceBase();
        //    var model = peliculaService.ObtenerPeliculas();
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult MenuPremium(int id)
        //{
        //    Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Id == id);

        //    var peliculaService = new PeliculasServicePremium();
        //    var model = peliculaService.ObtenerPeliculas();
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult VerPeliculas(int id)
        //{
        //    Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Id == id);
        //    if (cliBuscado != null)
        //    {
        //        if (cliBuscado.Abono == TipoAbono.BASE)
        //        {
        //            // return RedirectToAction("MenuBase", "Cliente", new { @id = cliBuscado.Id });
        //            return RedirectToActionPermanent("VerPeliculas", "Cliente");
        //        }
        //        else
        //        {
        //            //   return RedirectToAction("MenuPremium", "Cliente", new { @id = cliBuscado.Id });
        //            return RedirectToActionPermanent("VerPeliculas", "Cliente");

        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //[HttpGet]
        //public IActionResult VerPelis(int id)
        //{
        //    Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Id == id);

        //    return View("VerPeliculas");
        //}

        [HttpGet]
        public async Task<IActionResult> VerPelis(int? id)
        {
            Cliente cliBuscado = _context.Clientes.FirstOrDefault(C => C.Id == id);
            List<Pelicula> peliculas = (await _context.Peliculas.ToListAsync());
            List<Pelicula> peliculasAMostrar = new List<Pelicula>();

            if (cliBuscado != null)
            {
                if (cliBuscado.Abono == TipoAbono.BASE)
                {
                    foreach (Pelicula pe in peliculas)
                    {
                        if (pe.Abono == TipoAbono.BASE)
                        {
                            peliculasAMostrar.Add(pe);


                        }
                    }
                    return View("VerPelis", peliculasAMostrar);

                }
                else
                {
                        peliculasAMostrar = peliculas; 
                        // RedirectToAction("VerPelis", "Cliente", peliculasAMostrar);
                        return View("VerPelis", peliculasAMostrar);
                }
            }


            return View();


        }
        //   [HttpGet]
        //   public IActionResult teMuestro(List<Pelicula>pelis)
        //   {
        //       return View("VerPelis", pelis);
        //   }
        //}
    }
}