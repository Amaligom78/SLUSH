using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class SaveSlotUtility
{
    public static int CountSaves(string savesFolder, string extension = "json")
    {
        if (!Directory.Exists(savesFolder)) return 0;

        var files = Directory.GetFiles(savesFolder, $"*.{extension}", SearchOption.TopDirectoryOnly);
        return files.Length;
    }

    public static string[] GetSaves(string savesFolder, string extension = "json")
    {
        //if (!Directory.Exists(savesFolder)) return;

        return Directory.GetFiles(savesFolder, $"*.{extension}", SearchOption.TopDirectoryOnly);
    }
}