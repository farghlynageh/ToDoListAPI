using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Repository;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class todosController : ControllerBase
    {
        private readonly IToDoItemRepo _DataSource;
        public todosController(IToDoItemRepo DataSource)
        {
            _DataSource = DataSource;
        }

        //Get all Items
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                List<ToDoItem> items = _DataSource.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
    
        }


        //Get Item By ID
        [HttpGet("{id:int}")]
        public IActionResult GetItemById(int id)
        {
            try
            {
                return Ok(_DataSource.GetItemByID(id));
            }
            catch (Exception ex)
            {
                return NotFound($"No Item Exists With Id : {id}");
            }
            
        }

        //Add New Item
        [HttpPost]
        public IActionResult AddNewItem([FromBody]ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _DataSource.AddItem(item);
                return Ok($"Item :{item.Title} Added Successfully!");
            }
            return BadRequest(ModelState);
        }


        //Edit Item
        [HttpPut("{id:int}")]
        public IActionResult EditItem(int id , [FromBody]ToDoItem item ) 
        {
            if (ModelState.IsValid)
            {
                _DataSource.EditItem(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
            
        }


        //Delete Item
        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem(int id)
        {
            if (_DataSource.DeleteItem(id))
                return Ok($"Item with Id {id} Deleted Successfully!");
            else
                return NotFound($"Item with ID : {id} Not Found");
            
        }

    }
}
