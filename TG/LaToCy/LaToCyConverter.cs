using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG.LaToCy
{
    public class LaToCyConverter
    {
        public static string Translit(string str)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "Đ", "E", "Ž", "Z", "I", "J", "K", "L", "Lj", "M", "N", "Nj" ,"O", "P", "R", "S", "T", "Ć" ,"U", "F", "H", "C", "Č", "Dž", "Š" };
            string[] lat_low = { "a", "b", "v", "g", "d", "đ", "e", "ž", "z", "i", "j", "k", "l", "lj","m","n", "nj","o", "p", "r", "s", "t", "ć","u", "f", "h", "c", "č", "dž", "š" };
            string[] srb_up = { "А", "Б", "В", "Г", "Д", "Ђ", "Е", "Ж", "З", "И", "Ј", "К", "Л", "Љ","М", "Н", "Њ","О", "П", "Р", "С", "Т", "Ћ","У", "Ф", "Х", "Ц", "Ч", "Џ", "Ш"};
            string[] srb_low = { "а", "б", "в", "г", "д", "ђ", "е", "ж", "з", "и", "ј", "к", "л", "љ", "м", "н", "њ", "о", "п", "р", "с", "т", "ћ", "у", "ф", "х", "ц", "ч", "џ", "ш"};
            for (int i = 0; i <= 29; i++)
            {
                str = str.Replace(lat_up[i], srb_up[i]);
                str = str.Replace(lat_low[i], srb_low[i]);
            }
            return str;
        }
    }
    public class CyToLaConverter
    {
        public static string Translit(string str)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "Đ", "E", "Ž", "Z", "I", "J", "K", "L", "Lj", "M", "N", "Nj", "O", "P", "R", "S", "T", "Ć", "U", "F", "H", "C", "Č", "Dž", "Š" };
            string[] lat_low = { "a", "b", "v", "g", "d", "đ", "e", "ž", "z", "i", "j", "k", "l", "lj", "m", "n", "nj", "o", "p", "r", "s", "t", "ć", "u", "f", "h", "c", "č", "dž", "š" };
            string[] srb_up = { "А", "Б", "В", "Г", "Д", "Ђ", "Е", "Ж", "З", "И", "Ј", "К", "Л", "Љ", "М", "Н", "Њ", "О", "П", "Р", "С", "Т", "Ћ", "У", "Ф", "Х", "Ц", "Ч", "Џ", "Ш" };
            string[] srb_low = { "а", "б", "в", "г", "д", "ђ", "е", "ж", "з", "и", "ј", "к", "л", "љ", "м", "н", "њ", "о", "п", "р", "с", "т", "ћ", "у", "ф", "х", "ц", "ч", "џ", "ш" };
            for (int i = 0; i <= 29; i++)
            {
                str = str.Replace(srb_up[i], lat_up[i]);
                str = str.Replace(srb_low[i], lat_low[i]);
            }
            return str;
        }
    }
}
