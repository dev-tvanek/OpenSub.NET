﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OpenSub.NET.OpenSubFile
{
    public static class ReadFileAsync
    {
        /// <summary>
        /// Asynchronně načte obsah titulkového souboru jako string.
        /// Nejprve detekuje kódování souboru a poté načte obsah s použitím tohoto kódování.
        /// </summary>
        /// <param name="filePath">Cesta k titulkovému souboru.</param>
        /// <returns>Asynchronně vrátí textový obsah titulkového souboru.</returns>
        public static async Task<string> ReadAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Cesta k souboru je prázdná nebo null.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Soubor nebyl nalezen.", filePath);

            var encoding = await FileFormatEncoding.GetEncodingAsync(filePath);
            return await File.ReadAllTextAsync(filePath, encoding);
        }

        /// <summary>
        /// Zkontroluje, zda je soubor platným titulkovým souborem na základě jeho přípony.
        /// </summary>
        /// <param name="filePath">Cesta k titulkovému souboru.</param>
        /// <returns>True, pokud je soubor platným titulkovým souborem; jinak false.</returns>
        public static bool IsValidFile(string filePath)
        {
            return FileFormatExtension.IsValidExtension(filePath);
        }

        // Zde můžete přidat další metody, pokud jsou potřeba, například pro načtení souboru jako pole bajtů, atd.
    }
}

