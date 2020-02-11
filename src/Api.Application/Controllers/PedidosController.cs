using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.AdicionalService;
using Api.Domain.Interfaces.ItemPedidoAdicionalService;
using Api.Domain.Interfaces.ItemPedidoService;
using Api.Domain.Interfaces.PedidoService;
using Api.Domain.Interfaces.SaborService;
using Api.Domain.Interfaces.TamanhoService;
using Api.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private IPedidoService _pedidoService;
        private IItemPedidoService _itemPedidoService;
        private ITamanhoService _tamanhoService;
        private ISaborService _saborService;
        private IAdicionalService _adicionalService;
        private IItemPedidoAdicionalService _itemPedidoAdicionalService;

        public PedidosController(IPedidoService service, IItemPedidoService itemPedidoService, ITamanhoService tamanhoService, 
            ISaborService saborService, IAdicionalService adicionalService,  IItemPedidoAdicionalService itemPedidoAdicionalService)
        {
            _pedidoService = service;
            _itemPedidoService = itemPedidoService;
            _tamanhoService = tamanhoService;
            _saborService = saborService;
            _adicionalService = adicionalService;
            _itemPedidoAdicionalService = itemPedidoAdicionalService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { return Ok(await _pedidoService.GetAll()); }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("getById")]
        public async Task<ActionResult> GetById(long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var pedido = await _pedidoService.Get(id);

            try { return Ok(pedido); }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("criarPedido")]
        public async Task<ActionResult> CriarPedido([FromBody] ItemPedido itemPedido)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var itemPedidoCriado = await _itemPedidoService.Post(itemPedido);

                var pedido = new Pedido();
                pedido.ItemPedido = itemPedidoCriado;
                var pedidoCriado = await _pedidoService.Post(pedido);
                pedidoCriado.ItemPedido = itemPedidoCriado;

                if (pedidoCriado != null)
                {
                    return Ok(pedidoCriado);
                }
                else { return BadRequest(); }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("incluirAdicional")]
        public async Task<ActionResult> IncluirAdicional([FromBody] ItemPedidoAdicional itemPedidoAdicional)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                var result = await _itemPedidoAdicionalService.Post(itemPedidoAdicional);
                var itemPedido = _itemPedidoService.Get(result.ItemPedidoId).Result;
                var pedidoAdicional = _pedidoService.GetByItemPedido(result.ItemPedidoId);
              
                if (pedidoAdicional != null)
                {
                    return Ok(pedidoAdicional);
                }
                else { return BadRequest(); }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("finalizarPedido")]
        public async Task<ActionResult> FinalizarPedido([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            ICollection<Adicional> adicionais = new List<Adicional>();

            try
            {
                var pedidoResult = await _pedidoService.Get(pedido.Id);                
                var itemPedido = await _itemPedidoService.Get(pedido.ItemPedidoId);
                itemPedido.Tamanho = await _tamanhoService.Get(itemPedido.TamanhoId);
                itemPedido.Sabor = await _saborService.Get(itemPedido.SaborId);
                pedidoResult.ItemPedido = itemPedido;                

                foreach (ItemPedidoAdicional itemPedidoAdicional in _itemPedidoAdicionalService.GetByItemPedido(pedidoResult.ItemPedidoId)) {
                    adicionais.Add(await _adicionalService.Get(itemPedidoAdicional.AdicionalId));
                }

                pedidoResult.Adicionais = adicionais;
                pedidoResult.CalculaValorTotal();
                pedidoResult.CalculaTempoDePreparo();

                await _pedidoService.Put(pedidoResult);

                if (pedidoResult != null)
                {
                    return Ok(pedidoResult);
                }
                else { return BadRequest(); }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}