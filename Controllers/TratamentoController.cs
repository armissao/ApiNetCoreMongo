using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProApi.Data.Collections;
using ProApi.Model;

namespace ProApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TratamentoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Tratamento> _tratamentoCollection;

         public TratamentoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _tratamentoCollection = _mongoDB.DB.GetCollection<Tratamento>(typeof(Tratamento).Name.ToLower());
        }

        [HttpPost("/tratamento/cadastro")]
        public ActionResult SalvarTratamento([FromBody] TratamentoDto dto)
        {
            var tratamento = new Tratamento(dto.Id ,dto.InicioTratamento, dto.FinalTratamento, dto.Observacoes, dto.infectadoId);

            _tratamentoCollection.InsertOne(tratamento);
            
            return StatusCode(201, "Tratamento cadastrado com sucesso");
        }

        [HttpGet("/tratamento/consulta")]
        public ActionResult ObterTratamento()
        {
            var tratamento = _tratamentoCollection.Find(Builders<Tratamento>.Filter.Empty).ToList();
            
            return Ok(tratamento);
        }

        [HttpPut("/tratamento/cadastro/{id}")]
        public ActionResult AtualizarTratamento([FromBody] TratamentoDto dto)
        {
            
            _tratamentoCollection.UpdateOne(Builders<Tratamento>.Filter.Where(_ => _.Id == dto.Id), Builders<Tratamento>.Update.Set("InicioTratamento", dto.InicioTratamento)
                                                                                                                             .Set("FinalTratamento" , dto.FinalTratamento)
                                                                                                                             .Set("Observacoes", dto.Observacoes)
                                                                                                                             .Set("infectadoId", dto.infectadoId));
            
            return StatusCode(201, "Tratamento alterado com sucesso");
        }

         [HttpDelete("/tratamento/{Id}")]
        public ActionResult RemoverTratamento(string Id)
        {
            _tratamentoCollection.DeleteOne(Builders<Tratamento>.Filter.Where(_ => _.Id == Int32.Parse("Id")));
            
            return StatusCode(201, "Tratamento removido com sucesso");
        }
    }
}