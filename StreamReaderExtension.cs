using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StreamReaderExt
{
    public static class StreamReaderExtension
    {
        public static IEnumerable<string> ReadLines(this StreamReader reader)
        {
            for(var line = reader.ReadLine(); !string.IsNullOrEmpty(line); line = reader.ReadLine())
                yield return line;
        }
    }
}
