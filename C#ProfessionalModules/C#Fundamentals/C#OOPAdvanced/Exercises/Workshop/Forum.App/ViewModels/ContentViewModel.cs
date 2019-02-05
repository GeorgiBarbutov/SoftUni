namespace Forum.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ContentViewModel
    {
        private const int lineLenght = 37;

        public ContentViewModel(string content)
        {
            this.Content = GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] charContent = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+=lineLenght)
            {
                char[] row = charContent.Skip(i).Take(lineLenght).ToArray();
                string rowString = String.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
