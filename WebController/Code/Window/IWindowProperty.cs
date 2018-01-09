namespace WebController.Code.Window
{
    public interface IWindowProperty
    {
        string Pattern { get; }
        WindowPropertySearchType SearchType { get; set; }
    }
}