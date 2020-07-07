using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.BD.Interface
{
    public interface IModalidadeDAO<T>
    {
        bool Adicionar(T entity);
        IList<T> Lista();
        bool Atualizar(T entityNovo, T entityAntigo);
        bool Deletar(T entity);
        bool VerificarSeJaExiste(T entity, bool acao);
    }
}
