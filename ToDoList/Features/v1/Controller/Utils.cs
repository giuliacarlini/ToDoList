using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    public class Utils
    {
        private readonly DataContext _context;

        public Utils(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<ListItem> RetornaItens(IEnumerable<ListItem> _listItems)
        {

            foreach (ListItem _listItem in _listItems)
            {
                _listItem.ListItems = _context.ListItem.Where(x => x.ListItem_id == _listItem.Id);

                if (_listItem.ListItems == null) 
                    break;
                else
                    RetornaItens(_listItem.ListItems);
            }

            return _listItems;

        }
    }
}
