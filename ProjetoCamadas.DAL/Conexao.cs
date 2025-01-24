using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCamadas.DAL
{
    public class Conexao
    {
        protected SqlConnection conexao;
        protected SqlCommand command;
        protected SqlDataReader dataReader;


        protected void Conectar()
        {
            try
            {
                conexao = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=OficinaMecanicaDB ;Integrated Security = true");
                conexao.Open();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        protected void Desconectar()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }
    }
}
