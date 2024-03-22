using ToDoListAPI.Models;

namespace ToDoListAPI.Repository
{
    public interface IToDoItemRepo
    {
        //Get all Items
        List<ToDoItem> GetAllItems();


        //Get Item By ID
        ToDoItem GetItemByID(int id);

        //Add New Item
        void AddItem(ToDoItem item);


        //Edit Item
        void EditItem(int id, ToDoItem item);


        //Delete Item
        bool DeleteItem(int id);
    }
}
