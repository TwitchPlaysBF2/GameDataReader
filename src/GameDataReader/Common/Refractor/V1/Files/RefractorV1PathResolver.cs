using Microsoft.Win32;
using System.Diagnostics;

namespace GameDataReader.Common.Refractor.V1.Files;

public static class RefractorV1PathResolver
{
    public static string GetConFilePath(string conFile, string modName, string gameName)
    {
        // Use the path from the Registry, if the con file exists within the game installation path
        var conFilePath = GetPathFromRegistry(conFile, gameName);
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

    public static string GetPathFromRegistry(string conFile, string gameName)
    {
        var conFilePath = string.Empty;

        try
        {
            // Since BF1942 and BFV are 32bit games, the game's install path needs to be read from Wow6432Node
            var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            var registryPath = $@"SOFTWARE\EA GAMES\{gameName}";

            baseKey.OpenSubKey(registryPath);
            if (baseKey.SubKeyCount > 0)
            {
                var value = baseKey.GetValue("GAMEDIR");
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    conFilePath = Path.Combine(value.ToString(), conFile);
                    if (File.Exists(conFilePath))
                    {
                        return conFilePath;
                    }
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
        if (foundProcess?.MainModule != null)
        {
            conFilePath = foundProcess.MainModule.FileName;
        }

        conFilePath = Path.Combine(conFilePath, conFile);
        if (File.Exists(conFilePath))
        {
            return conFilePath;
        }

        conFilePath = string.Empty;

        return conFilePath;
    }

    public static string GetPathFromAppData(string conFile, string gameName)
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        // Since BF1942 and BFV are 32bit games, the game's AppData path needs to be read from Program Files (x86)
        var conFilePath = Path.Combine(appDataPath, "\\VirtualStore\\Program Files (x86)\\EA GAMES\\", gameName, conFile);
        if (File.Exists(conFilePath))
        {
            return conFilePath;
        }

        conFilePath = string.Empty;

        return conFilePath;
    }
}
