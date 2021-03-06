using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Namespace.Util
{
    public class BitmapFont
    {
        public Dictionary<int, Graphic> CharacterMap = new Dictionary<int, Graphic>();
        public int CharWidth { get; private set; }
        public int CharHeight { get; private set; }

        /// <summary>
        /// Bitmap font wrapper. Maps chars onto their ascii equivalent, depending on the image source.
        /// 
        /// I can recommend using tilemaps from "https://dwarffortresswiki.org/index.php/Tileset_repository"
        /// as they mostly work with all keys on common keyboards. You just have to remove the pink background.
        /// </summary>
        /// <param name="source">An image</param>
        /// <param name="charWidth">with of a character</param>
        /// <param name="charHeight">height of a character</param>
        /// <param name="xChars">number of characters per row</param>
        public BitmapFont(Graphic source, int charWidth, int charHeight, int xChars = 16)
        {
            CharWidth = charWidth;
            CharHeight = charHeight;
            int index = 0;

            int y = 0;
            while (y * CharHeight < source.Height)
            {
                for (int x = 0; x < xChars; x++)
                {
                    CharacterMap.Add(index, new Graphic(source, x * CharWidth, y * CharHeight, charWidth, charHeight));
                    index++;
                }
                y++;
            }
        }

        public void DrawString(string text, int x, int y)
        {
            string[] split = text.Split('\n');
            for (int line = 0; line < split.Length; line++)
            {
                for (int i = 0; i < split[line].Length; i++)
                {
                    CharacterMap[split[line][i]].Draw(new Vector2(x + i * CharWidth, y + line * CharHeight));
                }
            }
        }

        public void DrawString(string text, Vector2 pos)
        {
            DrawString(text, (int)pos.X, (int)pos.Y);
        }

        public void DrawString(string text, int x, int y, Color color)
        {
            string[] split = text.Split('\n');
            for (int line = 0; line < split.Length; line++)
            {
                for (int i = 0; i < split[line].Length; i++)
                {
                    CharacterMap[split[line][i]].Draw(new Vector2(x + i * CharWidth, y + line * CharHeight), Vector2.Zero, color);
                }
            }
        }

        public void DrawString(string text, Vector2 pos, Color c)
        {
            DrawString(text, (int)pos.X, (int)pos.Y, c);
        }

        public Vector2 MeasureString(string text)
        {
            string[] split = text.Split('\n');
            int width = 0;
            int height = CharHeight * split.Length;
            for (int i = 0; i < split.Length; i++)
            {
                int other = split[i].Length * CharWidth;
                width = other > width ? other : width;
            }
            return new Vector2(width, height);
        }
    }
}
