using Senai.BookStore.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Repository
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132";

        public List<AutorDomain> Listar()
        {
            List<AutorDomain> autores = new List<AutorDomain>();
            string Query = "select * from autores";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query,con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutorDomain autor = new AutorDomain {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        autores.Add(autor);
                    }
                    return autores;
                }
            }
        }


        /// <summary>
        /// Cadastra um Autor no Banco de dados
        /// </summary>
        /// <param name="autorDomain"></param>
        public void Cadastrar(AutorDomain autorDomain)
        {
            string Query = "INSERT Autores(nome,Email,DataNascimento) VALUES (@Nome,@Email,@DataNascimento)";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", autorDomain.Nome);
                    cmd.Parameters.AddWithValue("@Email", autorDomain.Email);
                    cmd.Parameters.AddWithValue("@DataNascimento", autorDomain.DataNascimento);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<LivroDomain> BuscarLivrosPorId(int id)
        {
            List<LivroDomain> livros = new List<LivroDomain>();
            string Query = "SELECT L.*, G.Descricao, A.Nome FROM Livros	 L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor WHERE L.IdAutor = @Id";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        LivroDomain livro = new LivroDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Autor = new AutorDomain
                            {
                                Nome = sdr["Nome"].ToString()
                            },
                            Genero = new GeneroDomain
                            {
                                Descricao = sdr["Descricao"].ToString()
                            }
                        };
                        livros.Add(livro);
                    }
                    return livros;
                }
            }
        }

        public List<AutorDomain> Ativos()
        {
            List<AutorDomain> autores = new List<AutorDomain>();
            string Query = "SELECT * FROM autores WHERE Ativo = 1";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutorDomain autor = new AutorDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        autores.Add(autor);
                    }
                    return autores;

                }

            }

        }

        public List<LivroDomain> LivrosDeAtivos(int id)
        {
            List<LivroDomain> livros = new List<LivroDomain>();
            string Query = "SELECT L.*, G.Descricao, A.Nome FROM Livros	 L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor WHERE A.Ativo = 1 AND L.Idlivro = @ID";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        LivroDomain livro = new LivroDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Autor = new AutorDomain
                            {
                                Nome = sdr["Nome"].ToString()
                            },
                            Genero = new GeneroDomain
                            {
                                Descricao = sdr["Descricao"].ToString()
                            }
                        };
                        livros.Add(livro);
                    }
                }
                return livros;
            }
        }
        
    }
}

