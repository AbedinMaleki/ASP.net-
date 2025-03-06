using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Models.ModelClasses;

namespace Sample1.Controllers
{
    [ApiController]
    [Route("API/Controller")]
    public class SampleController:ControllerBase
    {
        private readonly SampleDB _db;
        private readonly IUnitOfWork _unitOfWork;

        public SampleController(SampleDB db,IUnitOfWork unitOfWork)
        {
            this._db = db;
            this._unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product p)
        {
            var model=new Product { Description = p.Description,Name=p.Name,Price=p.Price };
            _db.Pruducts.Add(model);
          await  _db.SaveChangesAsync();
            return Ok(model.Id);
        }
        [HttpPost("CreateRepo")]
        public async Task<IActionResult> CreateProductRepo(Product p)
        {
            await _unitOfWork.repository.Add(p);
             _unitOfWork.save();
            return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _unitOfWork.repository.GetByIdAsync(id);
            return Ok(p);

        }
    }
}
