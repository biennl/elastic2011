using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogService
{
    /// <summary>
    /// represente la structure de données 
    /// pour l'enregistrement de service.
    /// Chaque service est representer par son adresse
    /// IP, son port d'ecoute et le nom du service
    /// </summary>
    class ServiceInfo
    {
        public string Service { set; get; }
        public string Address { set; get; }
        public string Port    { set; get; }

        public ServiceInfo(string service, string address, string port) 
        {
            this.Service   = service;
            this.Address = address;
            this.Port = port;   
        }

    }
}
