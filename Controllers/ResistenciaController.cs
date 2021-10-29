using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;


namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResistenciaController : ControllerBase
    {
        //Metodo POST para calcular ingresando los datos por medio de un json en el body. Ej. {"Color1":"rojo","Color2":"rojo","Color3":"rojo","Color4":"dorado"}
        
        [HttpPost]
        [Route("")]
        public IActionResult Calcular([FromBody]Resistencia res)
        {
            var calculo = new ResistenciaService();
            var resis = calculo.Calcular(res);
            return Ok(resis);
        }


        //Metodo GET para calcular ingresando los datos en la direccion. Ej. https://localhost:5001/api/resistencia/rojo.rojo.rojo.dorado

        [HttpGet]
        [Route("{color1}.{color2}.{color3}.{color4}")]
        public IActionResult Calcular2(string color1, string color2, string color3, string color4)

        {
            var res = new Resistencia(color1,color2,color3,color4);
            var calculo = new ResistenciaService();
            var resis = calculo.Calcular(res);
            return Ok(resis);
        }
    }
}