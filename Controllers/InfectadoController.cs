using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProApi.Data.Collections;
using ProApi.Model;

namespace ProApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost("/cadastro")]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Id ,dto.DataNascimento, dto.Sexo, dto.situacao, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet("/consulta")]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPut("/cadastro/{id}")]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {
            
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id), Builders<Infectado>.Update.Set("dataNascimento", dto.DataNascimento)
                                                                                                                             .Set("sexo" , dto.Sexo)
                                                                                                                             .Set("situacao", dto.situacao));
            
            return StatusCode(201, "Infectado alterado com sucesso");
        }

         [HttpDelete("{Id}")]
        public ActionResult RemoverInfectado(string dataNascimento)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == Int32.Parse("Id")));
            
            return StatusCode(201, "Infectado removido com sucesso");
        }
    }
}