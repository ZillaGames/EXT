using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Numerics;
namespace MatrixExt
{
    public static class MatrixExtension
    {

        public static int Width<T>(this T[][] matrix)
            => matrix != null && matrix[0] != null
                ? matrix[0].Length
                : 0;

        public static int Height<T>(this T[][] matrix)
            => matrix != null
                ? matrix.Length
                : 0;

        public static void AddColumn<T>(this T[][] matrix)
        {
            for (int i = 0; i < matrix.Height(); i++)
                Array.Resize(ref matrix[i], matrix.Width() + 1);
        }

        public static void RemoveColumn<T>(this T[][] matrix)
        {
            var wid = matrix.Width();

            if (wid == 0) return;

            for (int i = 0; i < matrix.Height(); i++)
                Array.Resize(ref matrix[i], wid - 1);
        }
    }
}
