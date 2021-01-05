using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;
using WebApplication1.Resources;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/")]

    public class MakesController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public MakesController(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await appDbContext.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

        [HttpGet]
        [Route("features")]
        public async Task<List<FeatureResource>> GetFeatures()
        {
            var features = await appDbContext.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }

    }
}
