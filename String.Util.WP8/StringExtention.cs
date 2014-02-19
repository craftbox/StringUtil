using System.Text;

namespace StringUtil
{
    public static class StringExtention
    {
        private static char[] replacement = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'c', 'c', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'o', 'o', 'o', 'o', 'o', 'o', 'o',  
                                             'u', 'u', 'u', 'u', 't', 'y', 'y', 's', 'b', 'd', 'n', 'm', ' ', ' ', ' ', ' ', ' ' };
        private static char[] accents = { 'à', 'â', 'ä', 'æ', 'ã', 'á', 'å', 'ç', '©', 'é', 'è', 'ê', 'ë', 'î', 'ï', 'í', 'ì', 'ô', 'õ', 'œ', 'ò', 'ó', 'ö', 'ø',  
                                         'ù', 'ú', 'û', 'ü', 'þ', 'ý', 'ÿ', '§', 'ß', 'ð', 'ñ', 'µ', '€', '£', '¥', '+', '•' };

        public static string RemoveDiacritics(this string accentedStr)
        {
            StringBuilder returnString = new StringBuilder();

            if (accentedStr.ToLower().IndexOfAny(accents) > -1)
            {
                returnString.Length = 0;
                returnString.Append(accentedStr);
                for (int i = 0; i < accents.Length; i++)
                {
                    returnString.Replace(accents[i], replacement[i]);
                    returnString.Replace(accents[i].ToString().ToUpper(), replacement[i].ToString().ToUpper());
                }

                return returnString.ToString();
            }
            else
                return accentedStr;
        }

        public static bool StartsWith(this string str, string value, Comparer stringComparison)
        {
            switch (stringComparison)
            {
                case Comparer.IgnoreCase:
                    return str.ToUpper().StartsWith(value.ToUpper());
                case Comparer.RemoveDiacritics:
                    return str.RemoveDiacritics().StartsWith(value.RemoveDiacritics());
                case Comparer.IgnoreCaseAndRemoveDiacritics:
                    return str.RemoveDiacritics().ToUpper().StartsWith(value.RemoveDiacritics().ToUpper());
                case Comparer.Default:
                default:
                    return str.StartsWith(value);
            }
        }

        public static bool Equals(this string str, string value, Comparer stringComparison)
        {
            switch (stringComparison)
            {
                case Comparer.IgnoreCase:
                    return str.ToUpper().Equals(value.ToUpper());
                case Comparer.RemoveDiacritics:
                    return str.RemoveDiacritics().Equals(value.RemoveDiacritics());
                case Comparer.IgnoreCaseAndRemoveDiacritics:
                    return str.RemoveDiacritics().ToUpper().Equals(value.RemoveDiacritics().ToUpper());
                case Comparer.Default:
                default:
                    return str.Equals(value);
            }
        }

        public static bool Contains(this string str, string value, Comparer stringComparison)
        {
            switch (stringComparison)
            {
                case Comparer.IgnoreCase:
                    return str.ToUpper().Contains(value.ToUpper());
                case Comparer.RemoveDiacritics:
                    return str.RemoveDiacritics().Contains(value.RemoveDiacritics());
                case Comparer.IgnoreCaseAndRemoveDiacritics:
                    return str.RemoveDiacritics().ToUpper().Contains(value.RemoveDiacritics().ToUpper());
                case Comparer.Default:
                default:
                    return str.Contains(value);
            }
        }

    }
}
