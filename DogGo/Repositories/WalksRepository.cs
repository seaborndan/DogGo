using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace DogGo.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly IConfiguration _config;

        public WalksRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walks> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Date, Duration FROM Walks";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<Walks> walks = new List<Walks>();

                        while (reader.Read())
                        {
                            Walks walk = new Walks()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration"))
                            };
                            walks.Add(walk);
                        }

                        return walks;
                    }
                }
            }
        }

        public List<Walks> GetWalksByWalker(Walker walker)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Walks.[Id], Walks.[Date], Walks.[Duration], WalkerId
                        FROM Walks INNER JOIN Walker ON Walks.WalkerId = Walker.Id
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        List<Walks> walks = new List<Walks>();

                        while (reader.Read())
                        {
                            Walks walk = new Walks()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration"))
                            };
                            walks.Add(walk);
                        }

                        return walks;
                    }
                }
            }
        }
    }
}