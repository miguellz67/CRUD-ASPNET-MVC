using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteWeb.Dao;
using ClienteWeb.Models;

namespace ClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        
       
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Adicionar(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                CPF = form["cpf"],
                Identificacao = new Random().Next(10, 250),
            };
            new ClienteDao().Adicionar(cliente);
            return RedirectToAction("Cadastro");
        }

        public ActionResult Atualizar(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                CPF = form["cpf"],
                Nome = form["nome"],
                Identificacao = int.Parse(form["id"]),
            };
            new ClienteDao().Atualizar(cliente);
            return RedirectToAction("Cadastro");
        }

        public ActionResult Deletar(FormCollection form)
        {
            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                CPF = form["cpf"],
                Identificacao = int.Parse(form["id"]),
            };
            
            new ClienteDao().Deletar(cliente);
            return RedirectToAction("Cadastro");
        }

        public ActionResult Consultar(FormCollection form)
        {
           ViewBag.data = new ClienteDao().Consultar();
            return View();
        }
    }
}