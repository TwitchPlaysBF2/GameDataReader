using Microsoft.Win32;
using System.Diagnostics;

namespace GameDataReader.Common.Refractor.V1.Files;

public static class RefractorV1PathResolver
{
    public static string GetConFilePath(string conFile, string modName, string gameName)
    {
        // Use the path from the Registry, if the con file exists within the game installation path
        var conFilePath = GetPathFromRegistry(gameName);
        if (File.Exists(conFilePath))
        {
            return conFilePath;
        }

        // Use the path from the game process, if the con file exists within the game process path
        conFilePath = GetPathFromGameProcess(conFile, modName);
        if (File.Exists(conFilePath))
        {
            return conFilePath;
        }

        // Use the path from AppData, if the con file exists within the AppData path
        conFilePath = GetPathFromAppData(conFile, gameName);
        if (File.Exists(conFilePath))
        {
            return conFilePath;
        }

        return string.Empty;
    }

    public static string GetPathFromRegistry(string gameName)
    {
        var conFilePath = string.Empty;

        try
        {
            // If the Operating System is 64bit, then the game's install path needs to be read from Wow6432Node 
            var registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry32 : RegistryView.Default;
            var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView);
            var registryPath = $@"SOFTWARE\EA GAMES\{gameName}";

            baseKey.OpenSubKey(registryPath);
            if (baseKey.SubKeyCount > 0)
            {
                var value = baseKey.GetValue("GAMEDIR");
                if (value != null)
                {
                    conFilePath = value.ToString();
                }
            }

            return conFilePath;
        }
        catch (Exception)
        {
            return conFilePath;
        }
    }

    public static string GetPathFromGameProcess(string conFile, string processName)
    {
        var conFilePath = string.Empty;

        var foundProcess = Process.GetProcessesByName(processName).FirstOrDefault();
        var processPath = foundProcess?.MainModule?.FileName;

        if (!string.IsNullOrWhiteSpace(processPath))
        {
            conFilePath = Path.Combine(processPath, conFile);
            if (File.Exists(conFilePath))
            {
               return conFilePath;
            }
        }

        return conFilePath;
    }

    public static string GetPathFromAppData(string conFile, string gameName)
    {
        var conFilePath = string.Empty;

        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        if (!string.IsNullOrWhiteSpace(appDataPath))
        {
            // Use the 32bit Operating System AppData path by default and override the AppData path if is the Operating System is 64bit
            conFilePath = Path.Combine(appDataPath, "\\VirtualStore\\Program Files\\EA GAMES\\");
            if (Environment.Is64BitOperatingSystem)
            {
                conFilePath = Path.Combine(appDataPath, "\\VirtualStore\\Program Files (x86)\\EA GAMES\\");
            }

            conFilePath = Path.Combine(conFilePath, gameName, conFile);
            if (File.Exists(conFilePath))
            {
                return conFilePath;
            }
        }

        return conFilePath;
    }
}
