using System.Text;

namespace _07_Tags
{
    public static class TagTransformer
    {
        public static string Transform(string tag)
        {
            StringBuilder modifiedTag = new StringBuilder();

            if (!tag.StartsWith("#"))
            {
                modifiedTag.Append("#");
            }

            string tagWithoutSpaces = string.Empty;
            tagWithoutSpaces = tag.Replace(" ", "");
            modifiedTag.Append(tagWithoutSpaces);

            string finalTagResult = modifiedTag.ToString();

            if (finalTagResult.Length > 20)
            {
                finalTagResult = finalTagResult.Substring(0, 20);
            }
            return finalTagResult;
        }
    }
}