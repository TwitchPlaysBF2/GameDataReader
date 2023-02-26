using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace GameDataReader.Common.Refractor.V1.Files;

internal class UtilityMethodsRefractorV1ConfigFile
{
    public string GetProcessPath(string modName)
    {
        var matchingProcesses = Process.GetProcessesByName(modName);
        return matchingProcesses.Length == 1 ? matchingProcesses[0].GetMainModuleFileName(modName) : string.Empty;
    }
}

internal static class Extensions
{
    [DllImport("Kernel32.dll")]
    private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);

    public static string GetMainModuleFileName(this Process process, string modName, int buffer = 1024)
    {
        var fileNameBuilder = new StringBuilder(buffer);
        var bufferLength = (uint)fileNameBuilder.Capacity + 1;
        return (QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) ? Path.GetDirectoryName(fileNameBuilder.ToString()) : string.Empty) ?? string.Empty;
    }
}