namespace WebController.Code.Window
{
    public class WindowProperty
    {
        public WindowPropertySearchType SearchType { get; set; }
        public string Pattern { get; internal set; }
    }

    public enum WindowPropertySearchType
    {
        Unknown = 0,
        Name = 1,
        Id = 2,
        Class = 3,
        Selector = 4
    }
}