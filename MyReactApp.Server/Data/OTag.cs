namespace MyReactApp.Server.Data;

public class OTag
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
    public string UserIdentifier { get; set; }
    public string CollectionName { get; set; }
    public long CollectionId { get; set; }
    public string ThumbnailImage { get; set; }
}
