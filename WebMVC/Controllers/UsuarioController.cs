using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibliotecaDAO;
using BibliotecaModel;

namespace WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            var metodoUsuario = new UsuarioDAO();
            var TodosUsuarios = metodoUsuario.Listar();
            return View(TodosUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                var metodosUsuario = new UsuarioDAO();
                metodosUsuario.Insert(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var metodosUsuario = new UsuarioDAO();
                metodosUsuario.Update(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Detalhes(int id)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(id);
            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            var metodosUsuario = new UsuarioDAO();
            var usuario = metodosUsuario.ListarId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmaExcluir(int id)
        {
            var metodosUsuario = new UsuarioDAO();
            Usuario usuario = new Usuario();
            usuario.UsuId = id;
            metodosUsuario.Delete(id);
            return RedirectToAction("Index");
            
        }
    }
}