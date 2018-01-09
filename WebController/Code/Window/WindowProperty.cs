namespace WebController.Code.Window
{
    public class WindowProperty : IWindowProperty
    {
        public WindowPropertySearchType SearchType { get; set; }
        public string Pattern { get; internal set; }
    }

    public class WindowSelectorProperty : IWindowProperty
    {
        public WindowPropertySearchType SearchType { get { return WindowPropertySearchType.Selector; } set { throw new System.NotImplementedException(); } }
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