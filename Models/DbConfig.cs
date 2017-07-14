using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pgSQL.Models
{
    public class DbConfig
    {
        private string _connectionString;

        public DbConfig(string connectionString)
        {
            _connectionString = connectionString;
            SetConnectionString();
        }

        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }

        private void SetConnectionString() 
        {
            _connectionString.Replace("//", "");

            char[] delimiterChars = { '/', ':', '@', '?' };
            string[] strConn = _connectionString.Split(delimiterChars);
            strConn = strConn.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            this.User = strConn[1];
            this.Password = strConn[2];
            this.Server = strConn[3];
            this.Database = strConn[5];
            this.Port = strConn[4];
        }

        public string GetConnectionString() 
        {
            var connectionString = "host=" + this.Server 
                + ";port=" + this.Port 
                + ";database=" + this.Database 
                + ";uid=" + this.User 
                + ";pwd=" + this.Password 
                + ";sslmode=Require;Trust Server Certificate=true;Timeout=1000";
            // EX: connectionString = "Host=ec2-54-243-210-223.compute-1.amazonaws.com;Port=5432;User Id=bpqmfsatgaabpb;Password=TIpfRzH32iobV_8Q8Fi--bx9IV;Database=d6kdk6sivm8mpe;sslmode=Require;Trust Server Certificate=true;Timeout=1000";                
            
            return connectionString;
        }
    }
}