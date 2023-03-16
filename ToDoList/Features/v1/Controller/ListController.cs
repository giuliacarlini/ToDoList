using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/lists")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListController : ControllerBase
    {
        private readonly DataContext _context;
        public ListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public List GetByID(int id)
        {
            List _list = _context.List.Where(x => x.ID == id).First(); ;
            return _list;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public List Post([FromBody] List list)
        {
            _context.Add(list);
            _context.SaveChanges();

            return list;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public void Delete(int id)
        {
            List _list = _context.List.Where(x => x.ID == id).First(); 

            _context.Remove(_list);
            _context.SaveChanges();
        }
    }
}
