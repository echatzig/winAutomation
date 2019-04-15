public class WinAutoParams
{ }

public class MouseClickParams : WinAutoParams
{
    public enum clicktype { single_click=0, double_click};
    public clicktype click { get; set; }
}

public class SelectWindowParams : WinAutoParams
{
    public string window { get; set; }
}

public class SetCursorParams : WinAutoParams
{
    public int x { get; set; }
    public int y { get; set; }
}

public class SendKeysParams : WinAutoParams
{
    public string str { get; set; }
}

