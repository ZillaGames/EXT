using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Linq.Enumerable;
namespace Zilla.EXT
{
    public static class StreamReaderExt
    {
        public static IEnumerable<byte> ReadBytes(this StreamReader reader, int nBytes)
        {
            foreach (var _ in Range(0, nBytes))
                yield return (byte)reader.Read();
        }

        public static IEnumerable<char> ReadChar(this StreamReader reader, int nChar)
        {
            foreach (var _ in Range(0, nChar))
                yield return (char)reader.Read();
        }

        public static byte Read8(this StreamReader reader)
            => (byte)reader.Read();

        public static int Read16(this StreamReader reader)
            => (reader.Read8() << 8) | reader.Read8();

        public static int Read32(this StreamReader reader)
            => (reader.Read16() << 16) | reader.Read16();

        public static int ReadVLQ(this StreamReader reader)
        {
            int value = 0;

            foreach (var _ in Range(0, 4))
            {
                var b = reader.Read8();
                value = (value << 7) | (b & 0b_0111_1111);

                if ((b & 0b_1000_0000) == 0) break;
            }

            return value;
        }

        public static string ReadString(this StreamReader reader, int size)
           => string.Concat(reader.ReadChar(size));
    }
}
