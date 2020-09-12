using Web.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Web.BD.Interface
{
    public interface IUsuarioDAO<T>
    {
        T DadosDoUsuario(int id);
        T Autentica(T entity);
        bool Adicionar(T entity);
        IList<T> Lista();
        bool VerificarSeJaExiste(T entity);
        bool Atualizar(T entity);
        bool Deletar(T entity);
        bool ValidaUsuarioNoCache();
        IList<Colaborador> ListaColaboradores();
    }
}
