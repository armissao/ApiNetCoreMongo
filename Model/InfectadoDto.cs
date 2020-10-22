using System;

namespace ProApi.Model
{
    public class InfectadoDto
    {
        public int Id {get; set;}
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Situacao situacao {get; set;}
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}