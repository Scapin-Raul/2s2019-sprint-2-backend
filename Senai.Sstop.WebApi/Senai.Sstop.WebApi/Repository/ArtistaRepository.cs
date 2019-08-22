using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repository
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Sstop;User Id=sa;Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT A.IdArtista, A.Nome, A.IdEstiloMusical, E.Nome AS NomeEstilo FROM Artistas A JOIN EstilosMusicas E ON A.IdEstiloMusical = E.IdEstiloMusical";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain {
                            IdArtista = Convert.ToInt32(sdr["IdArtista"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["NomeEstilo"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }
            return artistas;
                }
            }
        }
       
        public void Cadastrar(ArtistaDomain artistaDomain)
        {
            string Query = "INSERT INTO Artistas(Nome, IdEstiloMusical) VALUES(@Nome, @EstiloId)";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", artistaDomain.Nome);
                    cmd.Parameters.AddWithValue("@EstiloId", artistaDomain.EstiloId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
