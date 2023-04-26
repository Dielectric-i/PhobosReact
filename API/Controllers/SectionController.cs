using Microsoft.AspNetCore.Mvc;
using PhobosReact.API.Data.Models;

namespace PhobosReact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SectionController : ApiController
    {
        private static readonly IEnumerable<Section> _section = new[]
        {
            new Section{Id =1, Name = "Warehouse", Type = "Section"},
            new Section{Id =2, Name = "Production", Type = "Section"},
            new Section{Id =3, Name = "Orders", Type = "Section"}
        };
        [HttpGet]
        public Section[] GetAllSections()
        {
            Section[] section = _section.ToArray();
            //System.Threading.Thread.Sleep(2000);
            return section;
        }
    }
}
