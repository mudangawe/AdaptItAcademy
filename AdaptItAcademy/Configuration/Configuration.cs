using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.Configuration
{
    public class AppConfiguration
    {
        public string Name { get; }
        public string Version { get; }
        public string Description { get; }
        public string TermsOfService { get; }
        public string Connection { get; }
        public string ServerAddress { get; }
        public string ClientAddress { get; }
        public string CorsPolicy { get; }

        public AppConfiguration(IConfiguration configuration)
        {
            ServerAddress = configuration["App:ServerRootAddress"];
            ClientAddress = configuration["App:ClientRootAddress"];
            Name = configuration["App:Meta:Name"];
            Version = 'v' + configuration["App:Meta:Version"];
            Description = configuration["App:Meta:Description"];
            TermsOfService = configuration["App:Meta:TermsOfService"];
            Connection = configuration.GetConnectionString("Default");
            CorsPolicy = configuration.GetConnectionString("Default");
        }

      
    }
}
