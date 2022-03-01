using crud.Models;
using crud.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoReposiorio)
        {
            _contatoRepositorio = contatoReposiorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.buscarTodos();
            return View(contatos);
        }
        public IActionResult Cadastra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastra(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não censeguimos cadastra seu contato , datalhe do erro {erro.Message}";
                return RedirectToAction("Index");

            }


        }
        public IActionResult Editar(int id)
        {

            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (Exception Erro)
            {
                TempData["MensagemErro"] = $"Ops, não censeguimos editar seu contato , datalhe do erro {Erro.Message}";
                return RedirectToAction("Index");


                throw;
            }

        }
        public IActionResult Deletar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apadgado = _contatoRepositorio.Apagar(id);
                if (apadgado)
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso";
                else
                    TempData["MensagemErro"] = $"Ops, não censeguimos deletar seu contato ";

                return RedirectToAction("Index");

            }
            catch (Exception Erro)
            {
                TempData["MensagemErro"] = $"Ops, não censeguimos editar seu contato , datalhe do erro {Erro.Message}";
                return RedirectToAction("Index");

            }

        }
    }
}
