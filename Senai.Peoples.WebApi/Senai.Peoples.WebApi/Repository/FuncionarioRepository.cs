using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Peoples;User Id=sa;Pwd=132";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            string Query = "SELECT * FROM Funcionarios";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public void Inserir(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT INTO Funcionarios(Nome,Sobrenome,DataNascimento) VALUES (@Nome,@Sobrenome,@DataNascimento)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionarioDomain.DataNascimento);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT* FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString(),
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            String Query = "UPDATE Funcionarios SET Nome = @Nome WHERE Idfuncionario = @IdFuncionario UPDATE Funcionarios Set Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario UPDATE Funcionarios Set DataNascimento = @DataNascimento WHERE IdFuncionario = @IdFuncionario";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                    cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionarioDomain.DataNascimento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE Funcionarios WHERE IdFuncionario = @Id";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<NomesCompletosViewModel> NomesCompletos()
        {
            List<NomesCompletosViewModel> funcionarios = new List<NomesCompletosViewModel>();
            string Query = "SELECT * FROM Funcionarios";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        NomesCompletosViewModel funcionario = new NomesCompletosViewModel
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            NomeCompleto = sdr["Nome"].ToString() + " " + sdr["Sobrenome"].ToString(),
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public List<FuncionarioDomain> BuscarNome(string nome)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            string Query = "SELECT * FROM Funcionarios WHERE Nome LIKE @Nome";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@Nome", "%"+nome+"%");
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString(),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            };
                            funcionarios.Add(funcionario);
                        }
                        return funcionarios;
                    }
                    return null;
                }
            }
        }

        public List<FuncionarioDomain> Listar(string ordem)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            string Query = $"SELECT * FROM Funcionarios ORDER BY Nome {ordem}";
      
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

    }
}
