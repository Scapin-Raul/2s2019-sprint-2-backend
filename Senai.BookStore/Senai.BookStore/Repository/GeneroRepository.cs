using Senai.BookStore.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            string Query = "SELECT * FROM Generos";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = sdr["Descricao"].ToString()
                        };
                        generos.Add(genero);
                    }
                    return generos;
                }
            }


        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string Query = "INSERT Generos(Descricao) VALUES (@Descricao)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", generoDomain.Descricao);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<LivroDomain> BuscarLivroPorGenero(string nome)
        {
            List<LivroDomain> livros = new List<LivroDomain>();
            string Query = "SELECT L.*, G.Descricao, A.Nome FROM Livros	 L JOIN Generos G ON G.IdGenero = L.IdGenero JOIN Autores A ON A.IdAutor = L.IdAutor WHERE G.Descricao LIKE @Nome";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");
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
    }
}
