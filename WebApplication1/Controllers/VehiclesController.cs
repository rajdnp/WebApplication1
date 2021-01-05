using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DatabaseContext;
using WebApplication1.Models;
using WebApplication1.Resources;

namespace WebApplication1.Controllers
{
    [Route("api/vehicle/")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext appDbContext;

        public VehiclesController(IMapper mapper, AppDbContext appDbContext)
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            appDbContext.Vehicles.Add(vehicle);
            await appDbContext.SaveChangesAsync();
            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {

            var vehicle = await appDbContext.Vehicles.Include(x => x.Features).SingleOrDefaultAsync(x => x.Id == id);
            mapper.Map(vehicleResource, vehicle);
            await appDbContext.SaveChangesAsync();
            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await appDbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound();
            appDbContext.Vehicles.Remove(vehicle);
            await appDbContext.SaveChangesAsync();
            return Ok(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await appDbContext.Vehicles
                .Include(x => x.Features)
                .ThenInclude(x => new Feature { Id = x.Id, Name = x.Name })
                .Include(x => x.Model)
                .ThenInclude(x => x.Make)
                .SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

    }
}
