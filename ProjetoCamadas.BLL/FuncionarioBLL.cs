using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCamadas.DAL;
using ProjetoCamdas.DTO;

namespace ProjetoCamadas.BLL
{
    public class FuncionarioBLL
    {
        FuncionarioDAL funcionario = new FuncionarioDAL();

        public FuncionarioDTO AutenticaFuncionario (string nome, string senha)
        {
            return funcionario.Autenticar(nome, senha);
        }


        public void CreateFuncionario(FuncionarioDTO user)
        {
            funcionario.Create(user);
        }

        public List<TipoFuncionarioDTO> GetTipoFuncionario() 
        {
            return funcionario.GetTipos();
        }
    }
}
