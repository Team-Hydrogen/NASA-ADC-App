using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ReadCsv : MonoBehaviour
{
    public static List<string[]> ReadCsvFile(string filePath)
    {
        List<string[]> data = new List<string[]>();
        var streamReader = new StreamReader(filePath);
        bool endOfFile = false;
        while (!endOfFile)
        {
            var line = streamReader.ReadLine();
            if (line == null)
            {
                endOfFile = true;
                break;
            }
            var values = line.Split(',');
            data.Add(values);
        }
        return data;
    }
}