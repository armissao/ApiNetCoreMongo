using System;

namespace ProApi.Data.Collections
{
    public class Tratamento
    {
         public Tratamento(int Id,
                           DateTime InicioTratamento,
                           DateTime FinalTratamento,
                           string Observacoes,
                           Infectado infectadoId
                          
                         
                        )
        {
            this.Id = Id;
            this.InicioTratamento = InicioTratamento;
            this.FinalTratamento = FinalTratamento;
            this.Observacoes = Observacoes;
            this.infectadoId = infectadoId;
        }
        public int Id { get; set; }
        public DateTime InicioTratamento { get; set; }
        public DateTime FinalTratamento { get; set; }
        public string Observacoes {get; set;}
        public Infectado infectadoId {get; set;}
        
        }
}