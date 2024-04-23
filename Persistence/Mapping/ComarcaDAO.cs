using Npgsql;
using AC4.Persistence.DAO;
using AC4.Persistence.Utils;

namespace AC4.Persistence.Mapping
{
    public class ComarcaDAO : IComarcaDAO
    {
        private readonly string connectionString;



        public ComarcaDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public ComarcaDTO GetComarcaById(int CodiComarca)
        {
            ComarcaDTO comarca = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT \"year\", \"codicomarca\", \"nomcomarca\", \"poblacio\", \"domesticxarxa\", " +
                               "\"activitatseconomiques\", \"total\", \"consumdomesticpercapita\" " +
                               "FROM \"comarcas\" WHERE \"codicomarca\" = @CodiComarca";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodiComarca", CodiComarca);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // ORM: [--,--,--] -----> ContactDTO
                    comarca = NpgsqlUtils.GetComarca(reader);
                }
            }

            return comarca;
        }

        public void AddComarca(ComarcaDTO comarca)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO \"comarcas\" (\"year\", \"codicomarca\", \"nomcomarca\", \"poblacio\", \"domesticxarxa\", \"activitatseconomiques\", \"total\", \"consumdomesticpercapita\") " +
                               "VALUES (@Year, @CodiComarca, @NomComarca, @Poblacio, @DomesticXarxa, @ActivitatsEconomiques, @Total, @ConsumDomesticPerCapita)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", comarca.Year);
                command.Parameters.AddWithValue("@CodiComarca", comarca.CodiComarca);
                command.Parameters.AddWithValue("@NomComarca", comarca.NomComarca);
                command.Parameters.AddWithValue("@Poblacio", comarca.Poblacio);
                command.Parameters.AddWithValue("@DomesticXarxa", comarca.DomesticXarxa);
                command.Parameters.AddWithValue("@ActivitatsEconomiques", comarca.ActivitatsEconomiques);
                command.Parameters.AddWithValue("@Total", comarca.Total);
                command.Parameters.AddWithValue("@ConsumDomesticPerCapita", comarca.ConsumDomesticPerCapita);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateComarca(ComarcaDTO comarca)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE \"comarcas\" SET \"nomcomarca\" = @NomComarca, \"poblacio\" = @Poblacio, " +
                               "\"domesticxarxa\" = @DomesticXarxa, \"activitatseconomiques\" = @ActivitatsEconomiques, " +
                               "\"total\" = @Total, \"consumdomesticpercapita\" = @ConsumDomesticPerCapita " +
                               "WHERE \"year\" = @Year AND \"codicomarca\" = @CodiComarca"; NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", comarca.Year);
                command.Parameters.AddWithValue("@CodiComarca", comarca.CodiComarca);
                command.Parameters.AddWithValue("@NomComarca", comarca.NomComarca);
                command.Parameters.AddWithValue("@Poblacio", comarca.Poblacio);
                command.Parameters.AddWithValue("@DomesticXarxa", comarca.DomesticXarxa);
                command.Parameters.AddWithValue("@ActivitatsEconomiques", comarca.ActivitatsEconomiques);
                command.Parameters.AddWithValue("@Total", comarca.Total);
                command.Parameters.AddWithValue("@ConsumDomesticPerCapita", comarca.ConsumDomesticPerCapita);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteComarca(int CodiComarca)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM \"comarcas\" WHERE \"codicomarca\" = @CodiComarca";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodiComarca", CodiComarca);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ComarcaDTO> GetAllComarcas()
        {
            List<ComarcaDTO> comarcas = new List<ComarcaDTO>();

            using (NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT \"year\", \"codicomarca\", \"nomcomarca\", \"poblacio\", \"domesticxarxa\", " +
                               "\"activitatseconomiques\", \"total\", \"consumdomesticpercapita\" FROM \"comarcas\""; NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ComarcaDTO comarca = NpgsqlUtils.GetComarca(reader);
                    comarcas.Add(comarca);
                }
            }
            return comarcas;
        }
    }

}