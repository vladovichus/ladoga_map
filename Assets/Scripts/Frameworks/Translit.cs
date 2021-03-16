using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Translit 
{
    private static Dictionary<string, string> cyrToLat;

    private static List<string> cyrToLatKeys;
    private static List<string> cyrToLatValues;

    private static bool InitCyrToLat()
    {
        if (cyrToLat == null || cyrToLat.Count <= 0)
        {
            cyrToLat = new Dictionary<string, string>();
            cyrToLat.Add("а", "a");
            cyrToLat.Add("б", "b");
            cyrToLat.Add("в", "v");
            cyrToLat.Add("г", "g");
            cyrToLat.Add("д", "d");
            cyrToLat.Add("е", "e");
            cyrToLat.Add("ё", "yo");
            cyrToLat.Add("ж", "zh");
            cyrToLat.Add("з", "z");
            cyrToLat.Add("и", "i");
            cyrToLat.Add("й", "j");
            cyrToLat.Add("к", "k");
            cyrToLat.Add("л", "l");
            cyrToLat.Add("м", "m");
            cyrToLat.Add("н", "n");
            cyrToLat.Add("о", "o");
            cyrToLat.Add("п", "p");
            cyrToLat.Add("р", "r");
            cyrToLat.Add("с", "s");
            cyrToLat.Add("т", "t");
            cyrToLat.Add("у", "u");
            cyrToLat.Add("ф", "f");
            cyrToLat.Add("х", "h");
            cyrToLat.Add("ц", "c");
            cyrToLat.Add("ч", "ch");
            cyrToLat.Add("ш", "sh");
            cyrToLat.Add("щ", "sch");
            cyrToLat.Add("ъ", "j");
            cyrToLat.Add("ы", "i");
            cyrToLat.Add("ь", "j");
            cyrToLat.Add("э", "e");
            cyrToLat.Add("ю", "yu");
            cyrToLat.Add("я", "ya");
            cyrToLat.Add("А", "A");
            cyrToLat.Add("Б", "B");
            cyrToLat.Add("В", "V");
            cyrToLat.Add("Г", "G");
            cyrToLat.Add("Д", "D");
            cyrToLat.Add("Е", "E");
            cyrToLat.Add("Ё", "Yo");
            cyrToLat.Add("Ж", "Zh");
            cyrToLat.Add("З", "Z");
            cyrToLat.Add("И", "I");
            cyrToLat.Add("Й", "J");
            cyrToLat.Add("К", "K");
            cyrToLat.Add("Л", "L");
            cyrToLat.Add("М", "M");
            cyrToLat.Add("Н", "N");
            cyrToLat.Add("О", "O");
            cyrToLat.Add("П", "P");
            cyrToLat.Add("Р", "R");
            cyrToLat.Add("С", "S");
            cyrToLat.Add("Т", "T");
            cyrToLat.Add("У", "U");
            cyrToLat.Add("Ф", "F");
            cyrToLat.Add("Х", "H");
            cyrToLat.Add("Ц", "C");
            cyrToLat.Add("Ч", "Ch");
            cyrToLat.Add("Ш", "Sh");
            cyrToLat.Add("Щ", "Sch");
            cyrToLat.Add("Ъ", "J");
            cyrToLat.Add("Ы", "I");
            cyrToLat.Add("Ь", "J");
            cyrToLat.Add("Э", "E");
            cyrToLat.Add("Ю", "Yu");
            cyrToLat.Add("Я", "Ya");
        }

        cyrToLatKeys = new List<string>();
        cyrToLatValues = new List<string>();
        foreach (KeyValuePair<string, string> pair in cyrToLat)
        {
            cyrToLatKeys.Add(pair.Key);
            cyrToLatValues.Add(pair.Value);
        }

        if (cyrToLat == null || cyrToLat.Count <= 0)
            return false;
        else
            return true;
    }

    public static string CyrToLat(string cyrText)
    {
        if (InitCyrToLat())
        {
            string latText = cyrText;
            for (int i = 0; i < cyrToLat.Count; ++i)
            {
                latText = latText.Replace(cyrToLatKeys[i], cyrToLatValues[i]);
            }
            return latText;
        }
        else
        {
            return null;
        }
    }   

    public static string MakeID(string original)
    {
        return Translit.CyrToLat(original).ToLower()
            .Replace(" ", "_")
            .Replace(" ", "_")
            .Replace("-", "_")
            .Replace("–", "_")
            .Replace("—", "_")
            .Replace("(", "_")
            .Replace(")", "_");
    }
}