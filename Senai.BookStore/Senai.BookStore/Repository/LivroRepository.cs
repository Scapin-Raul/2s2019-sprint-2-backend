using Senai.BookStore.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Repository
{
    public class LivroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132";

        public List<LivroDomain> Listar()
        {
            List<LivroDomain> livros = new List<LivroDomain>();
            string Query = "SELECT L.IdLivro, L.Titulo, G.Descricao, A.Nome FROM Livros L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor";
            
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        LivroDomain livro = new LivroDomain {
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

        public void Cadastrar(LivroDomain livroDomain)
        {
            string Query = ("INSERT Livros(Titulo,IdAutor,IdGenero) VALUES(@Titulo, @IdAutor, @IdGenero)");
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", livroDomain.Titulo);
                    cmd.Parameters.AddWithValue("@IdAutor", livroDomain.AutorId);
                    cmd.Parameters.AddWithValue("@IdGenero", livroDomain.GeneroId);

                    cmd.ExecuteNonQuery();

                }

            }

        }


        public LivroDomain BuscarPorId(int id)
        {
            string Query = "SELECT L.*, G.Descricao, A.Nome FROM Livros L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor WHERE IdLivro = @Id";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
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
                            return livro;
                        }
                    }
                    return null;
                }

            }
        }

        public void Alterar(LivroDomain livroDomain)
        {
            string Query = "UPDATE Livros SET Titulo = @Titulo WHERE IdLivro = @Id";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", livroDomain.Titulo);
                    cmd.Parameters.AddWithValue("@Id", livroDomain.IdLivro);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Livros WHERE IdLivro = @Id";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
