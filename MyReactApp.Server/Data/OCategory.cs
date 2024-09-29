namespace MyReactApp.Server.Data;

public class OCategory
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
}
