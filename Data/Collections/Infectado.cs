
using System;
using MongoDB.Driver.GeoJsonObjectModel;
using ProApi.Model;

namespace ProApi.Data.Collections
{

    public class Infectado
    {
        public Infectado(int Id,
                         DateTime dataNascimento,
                         string sexo,
                         Situacao situacao,
                         double latitude,
                         double longitude)
        {
            this.Id = Id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.situacao = situacao;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public int Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Situacao situacao {get; set;}
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }

}