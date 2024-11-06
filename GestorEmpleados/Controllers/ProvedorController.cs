using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiWebAPI.Data;
using MiWebAPI.Models;

namespace MiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvedorController : ControllerBase
    {
        private readonly ProvedorData _ProvedorData;
        public ProvedorController(ProvedorData ProvedorData)
        {
            _ProvedorData = ProvedorData;
        }

        [HttpPost]
        [Route("GetProvedor")]
        public async Task<IActionResult> Lista([FromBody] string filtro)
        {
            List<Provedor> Lista = await _ProvedorData.GetProvedor(filtro);
            return StatusCode(StatusCodes.Status200OK, Lista);
        }
        [HttpPost]
        [Route("AddProvedor")]
        public async Task<IActionResult> AddProvedor([FromBody] Provedor objeto)
        {

            var respuesta = await _ProvedorData.AddProvedor(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("UpdateProvedor")]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Provedor objeto)
        {

            var respuesta = await _ProvedorData.UpdateProvedor(objeto);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

        [HttpPost]
        [Route("DeleteProvedor")]
        public async Task<IActionResult> DeleteProvedor([FromBody] int Id)
        {

            var respuesta = await _ProvedorData.DeleteProvedor(Id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });
        }

    }
}
