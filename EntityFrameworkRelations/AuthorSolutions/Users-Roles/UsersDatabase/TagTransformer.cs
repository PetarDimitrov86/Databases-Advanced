namespace UsersDatabase
{
    using System;

    class TagTransformer
    {
        public static string Transform(string tag)
        {
            tag = tag.Replace(" ", "");
            tag = tag.Replace("\\t", "");
            tag = tag.Replace("\\n", "");

            if (!tag.StartsWith("#"))
            {
                tag = "#" + tag;
            }

            return tag.Substring(0, Math.Min(20, tag.Length));
        }
    }
}
