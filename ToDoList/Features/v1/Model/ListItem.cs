namespace ToDoList.Features.v1.Model
{
    public class ListItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int User_id { get; set; }
        public int List_id { get; set; }
        public int ListItem_id { get; set; }
        public IEnumerable<ListItem>? ListItems { get; set; }
    }
}
