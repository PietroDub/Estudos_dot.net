using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Treino_.Net_MongoDb.Data;
using Treino_.Net_MongoDb.Entities;

namespace Treino_.Net_MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMongoCollection<Cliente> _clientes;
        public ClienteController(MongoDbService mongoDbService)
        {
            _clientes = mongoDbService.Database?.GetCollection<Cliente>("cliente");
        }

        //CRUD
        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clientes.Find(FilterDefinition<Cliente>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente?>> GetById(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(x => x.Cliente_id, id);
            var cliente = _clientes.Find(filter).FirstOrDefault();
            return cliente is not null ? Ok(cliente) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente) { 
            await _clientes.InsertOneAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Cliente_id }, cliente);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(x => x.Cliente_id, cliente.Cliente_id);
            //var update = Builders<Customer>.Update
            //    .Set(x => x.CustomerName, customer.CustomerName)
            //    .Set(x => x.Email, customer.Email);
            //await _customers.UpdateOneAsync(filter, update);
            await _clientes.ReplaceOneAsync(filter, cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(x =>x.Cliente_id, id);
            await _clientes.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
