using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
