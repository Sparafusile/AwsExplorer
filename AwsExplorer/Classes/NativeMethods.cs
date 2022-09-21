using System.Runtime.InteropServices;

namespace Explorer.Classes;

internal static class NativeMethods
{
    public const uint LVM_FIRST = 0x1000;
    public const uint LVM_GETIMAGELIST = ( LVM_FIRST + 2 );
    public const uint LVM_SETIMAGELIST = ( LVM_FIRST + 3 );

    // https://stackoverflow.com/q/27682170/292578
    private const int TV_FIRST = 0x1100;
    public enum TVM
    {
        GETNEXTITEM = ( TV_FIRST + 10 ),
        GETITEMA = ( TV_FIRST + 12 ),
        GETITEM = ( TV_FIRST + 62 ),
        GETCOUNT = ( TV_FIRST + 5 ),
        SELECTITEM = ( TV_FIRST + 11 ),
        DELETEITEM = ( TV_FIRST + 1 ),
        EXPAND = ( TV_FIRST + 2 ),
        GETITEMRECT = ( TV_FIRST + 4 ),
        GETINDENT = ( TV_FIRST + 6 ),
        SETINDENT = ( TV_FIRST + 7 ),
        GETIMAGELIST = ( TV_FIRST + 8 ),
        SETIMAGELIST = ( TV_FIRST + 9 ),
        GETISEARCHSTRING = ( TV_FIRST + 64 ),
        HITTEST = ( TV_FIRST + 17 ),
    }

    public const uint LVSIL_NORMAL = 0;
    public const uint LVSIL_SMALL = 1;
    public const uint LVSIL_STATE = 2;
    public const uint LVSIL_GROUPHEADER = 3;

    [DllImport( "user32" )]
    public static extern IntPtr SendMessage( IntPtr hWnd, uint msg, uint wParam, IntPtr lParam );

    [DllImport( "comctl32" )]
    public static extern bool ImageList_Destroy( IntPtr hImageList );

    public const uint SHGFI_DISPLAYNAME = 0x200;
    public const uint SHGFI_ICON = 0x100;
    public const uint SHGFI_LARGEICON = 0x0;
    public const uint SHGFI_SMALLICON = 0x1;
    public const uint SHGFI_SYSICONINDEX = 0x4000;
    public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

    [StructLayout( LayoutKind.Sequential )]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 260 )]
        public string szDisplayName;
        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 80 )]
        public string szTypeName;
    };

    [DllImport( "shell32" )]
    public static extern IntPtr SHGetFileInfo( string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags );

    [DllImport( "uxtheme", CharSet = CharSet.Unicode )]
    public static extern int SetWindowTheme( IntPtr hWnd, string pszSubAppName, string pszSubIdList );

    [DllImport( "user32.dll", CharSet = CharSet.Auto )]
    internal static extern IntPtr SendMessage( IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam );

    public static void Scroll( this Control control )
    {
        var pt = control.PointToClient( Cursor.Position );

        if( ( pt.Y + 20 ) > control.Height )
        {
            // scroll down
            SendMessage( control.Handle, 277, (IntPtr)1, (IntPtr)0 );
        }
        else if( pt.Y < 20 )
        {
            // scroll up
            SendMessage( control.Handle, 277, (IntPtr)0, (IntPtr)0 );
        }
    }
}
