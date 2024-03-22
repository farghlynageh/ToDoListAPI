using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repository
{
    public class ToDoItemRepo : IToDoItemRepo
    {
        private readonly ToDoListContext _context;
        public ToDoItemRepo(ToDoListContext context)
        {
            _context = context;
        }
        public void AddItem(ToDoItem item)
        {  
            try
            {
                _context.ToDoItems.Add(item);
                _context.SaveChanges();   
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public bool DeleteItem(int id)
        {

            ToDoItem item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public void EditItem(int id, ToDoItem Newitem)
        {
            ToDoItem OldItem = _context.ToDoItems.Find(id);
            if (OldItem != null)
            {
                
                OldItem.Title = Newitem.Title;
                OldItem.IsCompleted = Newitem.IsCompleted;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                ex.Message.ToString();
                }
            }
        }

        public List<ToDoItem> GetAllItems()
        {
            List<ToDoItem> toDoItemsList = _context.ToDoItems.ToList();
            return toDoItemsList;
        }

        public ToDoItem GetItemByID(int id)
        {
            ToDoItem item = _context.ToDoItems.Find(id);
            return item;
        }
    }
}
