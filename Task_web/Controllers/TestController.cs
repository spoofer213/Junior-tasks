using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_web.Models;

namespace Task_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IList<TestModel> _testModels;

        public TestController(IList<TestModel> testModels)
        {
            _testModels = testModels;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                var check = _testModels.Where(w => w.Id == testModel.Id).FirstOrDefault();
                if(check == null)
                {
                    _testModels.Add(testModel);
                }
                return CreatedAtAction(nameof(ReadTest), new { id = testModel.Id });
            }
            return BadRequest();
            
        }


        [HttpGet("{id}")]
        private async Task<ActionResult<TestModel>> ReadTest(Guid id)
        {
            var testModel = _testModels.FirstOrDefault(f => f.Id == id);
            if(testModel == null)
            {
                return NotFound();
            }
            return testModel;
        }




        [HttpPut("{id}")]
        private async Task<ActionResult> UpdateTest(Guid id,TestModel testModel)
        {
            if(id != testModel.Id)
            {
                return BadRequest();
            }

            var oldModel = _testModels.FirstOrDefault(f => f.Id == id);
            oldModel.Name = testModel.Name;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTest(Guid id)
        {
            var deleteTest = _testModels.Where(w => w.Id == id).FirstOrDefault();
            if(deleteTest == null)
            {
                return NotFound();
            }

            _testModels.Remove(deleteTest);
            return NoContent();
        }



        /*
         *
         * необходимо релизовать CRUD для testModels
         *
         */
    }
}
