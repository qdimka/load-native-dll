using System.Runtime.InteropServices;
using net.r_eg.DllExport;

namespace DynamicLibraries.Library
{
    public class Library
    {
        [DllExport("Method", CallingConvention.Cdecl)]
        public static string Method(string body)
        {
            return $"{body} {System.Environment.OSVersion.VersionString}";
        }
    }
}