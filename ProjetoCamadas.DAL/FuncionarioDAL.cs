using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoCamdas.DTO;




namespace ProjetoCamadas.DAL
{
	public class FuncionarioDAL : Conexao
	{
		public FuncionarioDTO Autenticar(string usuario, string senha)
		{
			try
			{
				Conectar();
				command = new SqlCommand("SELECT * FROM Funcionario WHERE NomeFuncionario = @NomeFuncionario AND SenhaFuncionario = @SenhaFuncionario", conexao);
				command.Parameters.AddWithValue("@NomeFuncionario", usuario);
				command.Parameters.AddWithValue("@SenhaFuncionario", senha);
				dataReader = command.ExecuteReader();

				FuncionarioDTO funcionarioDTO = new FuncionarioDTO();
				if (dataReader.Read())
				{
					funcionarioDTO = new FuncionarioDTO();
					funcionarioDTO.NomeFuncionario = dataReader["NomeFuncionario"].ToString();
					funcionarioDTO.SenhaFuncionario = dataReader["SenhaFuncionario"].ToString();
					funcionarioDTO.TpFuncionario = Convert.ToInt32(dataReader["NomeFuncionario"].ToString());
				}
				return funcionarioDTO;
			}

			catch (Exception erro)
			{

				throw new Exception(erro.Message);
			}
			finally
			{
				Desconectar();
			}

		}


		public void Create(FuncionarioDTO funcionario)
		{
			try
			{
				Conectar();
				command = new SqlCommand("INSERT INTO Funcionario (NomeFuncionario, EmailFuncionario, SenhaFuncionario, DtNascFuncionario, UrlImgFuncionario, CPF, TelefoneFuncionario, Sexo, TpFuncionario) VALUES (@nome, @email,@senha,@data,@img,@cpf,@telefone,@sexo,@tipo);", conexao);


				command.Parameters.AddWithValue("@nome", funcionario.NomeFuncionario);
				command.Parameters.AddWithValue("@email", funcionario.EmailFuncionario);
				command.Parameters.AddWithValue("@senha", funcionario.SenhaFuncionario);
				command.Parameters.AddWithValue("@data", funcionario.DtNascFuncionario);
				command.Parameters.AddWithValue("@img", funcionario.UrlImgFuncionario);
				command.Parameters.AddWithValue("@cpf", funcionario.CPF);
				command.Parameters.AddWithValue("@telefone", funcionario.TelefoneFuncionario);
				command.Parameters.AddWithValue("@sexo", funcionario.Sexo);
				command.Parameters.AddWithValue("@tipo", funcionario.TpFuncionario);


				command.ExecuteNonQuery();
			}
			catch (Exception erro)
			{

				throw new Exception($"Erro ao criar funcionario: {erro.Message}");
			}
			finally
			{
				Desconectar();
			}
		}

		public List<TipoFuncionarioDTO> GetTipos() 
		{
			try
			{
				Conectar();
				command = new SqlCommand("SELECT * FROM TipoFuncionario;", conexao);
				dataReader = command.ExecuteReader();
				List<TipoFuncionarioDTO> Lista = new List<TipoFuncionarioDTO>();

				while (dataReader.Read()) 
				{ 
					TipoFuncionarioDTO tipoUsuario = new TipoFuncionarioDTO();
					tipoUsuario.IdTipoFuncionario = Convert.ToInt32(dataReader["IdTipoFuncionario"]);
					tipoUsuario.DescricaoTipoFuncionario = dataReader["DescricaoTipoFuncionario"].ToString();

					Lista.Add(tipoUsuario);

				}
				return Lista;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			finally
			{
				Desconectar();
			}
		}
	}
}
