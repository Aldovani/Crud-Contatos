using crud.Models;

namespace crud.Repositorio
{
    public interface IContatoRepositorio
    {

        ContatoModel ListarPorId(int id);
        List<ContatoModel> buscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);



    }
}
