﻿using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes;User Id=sa;Pwd=132";


        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos ORDER BY IdGenero ASC";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = $"SELECT IdGenero, Nome FROM Generos WHERE IdGenero = {id}";

                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }
        }


        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(GeneroDomain generoDomain)
        {
            string Query = "INSERT Generos(Nome) VALUES (@Nome)";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> FilmesDeGenero(int id)
        {
            string Query = "SELECT F.*, G.Nome FROM Filmes F JOIN Generos G ON F.IdGenero = G.IdGenero WHERE F.IdGenero = @IdGenero";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                List<FilmeDomain> filmes = new List<FilmeDomain>();
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
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

        public List<GeneroDomain> BuscarNome(string nome)
        {
            string Query = "SELECT * FROM Generos WHERE Nome LIKE @Nome";
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                    return generos;
                }

            }
        }
    }
}
