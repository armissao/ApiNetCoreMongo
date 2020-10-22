using System;
using ProApi.Data.Collections;

namespace ProApi.Model
{
    public class TratamentoDto
    {
        
        public int Id {get; set;}
        public DateTime InicioTratamento { get; set; }
        public DateTime FinalTratamento { get; set; }
        public string Observacoes {get; set;}
        public Infectado infectadoId { get; set; }
    }
}