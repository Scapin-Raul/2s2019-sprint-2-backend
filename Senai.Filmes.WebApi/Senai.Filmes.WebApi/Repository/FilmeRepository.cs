using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes;User Id=sa;Pwd=132";

        public void Cadastrar(FilmeDomain filmeDomain)
        {
            string Query = "INSERT Filmes(Titulo,IdGenero) VALUES (@Titulo,@GeneroId)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filmeDomain.Titulo);
                    cmd.Parameters.AddWithValue("@GeneroId", filmeDomain.GeneroId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            string Query = "SELECT F.*, G.Nome FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero";
            List<FilmeDomain> filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        filmes.Add(filme);
                        };
                    return filmes;
                }

            };

        }

        public FilmeDomain BuscarPorId(int id)
        {
            string Query = "SELECT F.*, G.Nome FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero WHERE IdFilme = @IdFilme";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }
                            };
                            return filme;
                        }

                    }
                    return null;

                }
            }
        }

        public List<FilmeDomain> BuscarNome(string nome)
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();
            string Query = "SELECT F.*, G.Nome FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero WHERE F.Titulo LIKE @Nome";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        filmes.Add(filme);
                    };
                    return filmes;

                }

            }

        }

    }
}
