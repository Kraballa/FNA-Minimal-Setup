using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Namespace.Util;
using System;

namespace Namespace
{
    /// <summary>
    /// Renderer class that reveals various pixel-based methods globally. Based on the `Draw` class from Monocle.
    /// </summary>
    public class Render
    {
        public static Texture2D Pixel;

        public static SpriteBatch SpriteBatch { get; set; }

        public static float CharWidth;
        public static float CharHeight;

        private static Rectangle rect;

        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
            Pixel = new Texture2D(graphicsDevice, 1, 1);
            Color[] colors = new Color[1];
            colors[0] = Color.White;
            Pixel.SetData(colors);
        }

        public static void Point(Vector2 at, Color color)
        {
            SpriteBatch.Draw(Pixel, at, null, color, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

        #region Line

        public static void Line(Vector2 start, Vector2 end, Color color)
        {
            LineAngle(start, Calc.Angle(start, end), Vector2.Distance(start, end), color);
        }

        public static void Line(Vector2 start, Vector2 end, Color color, float thickness)
        {
            LineAngle(start, Calc.Angle(start, end), Vector2.Distance(start, end), color, thickness);
        }

        public static void Line(float x1, float y1, float x2, float y2, Color color)
        {
            Line(new Vector2(x1, y1), new Vector2(x2, y2), color);
        }

        public static void Line(float x1, float y1, float x2, float y2, Color color, float t)
        {
            Line(new Vector2(x1, y1), new Vector2(x2, y2), color, t);
        }

        #endregion

        #region Line Angle

        public static void LineAngle(Vector2 start, float angle, float length, Color color)
        {
            SpriteBatch.Draw(Pixel, start, null, color, angle, Vector2.Zero, new Vector2(length, 1), SpriteEffects.None, 0);
        }

        public static void LineAngle(Vector2 start, float angle, float length, Color color, float thickness)
        {
            SpriteBatch.Draw(Pixel, start, null, color, angle, new Vector2(0, .5f), new Vector2(length, thickness), SpriteEffects.None, 0);
        }

        public static void LineAngle(float startX, float startY, float angle, float length, Color color)
        {
            LineAngle(new Vector2(startX, startY), angle, length, color);
        }

        #endregion

        #region Circle

        public static void Circle(Vector2 position, float radius, Color color, int resolution)
        {
            Vector2 last = Vector2.UnitX * radius;
            Vector2 lastP = last.Perpendicular();
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 at = Calc.AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                Vector2 atP = at.Perpendicular();

                Line(position + last, position + at, color);
                Line(position - last, position - at, color);
                Line(position + lastP, position + atP, color);
                Line(position - lastP, position - atP, color);

                last = at;
                lastP = atP;
            }
        }

        public static void Circle(float x, float y, float radius, Color color, int resolution)
        {
            Circle(new Vector2(x, y), radius, color, resolution);
        }

        public static void Circle(Vector2 position, float radius, Color color, float thickness, int resolution)
        {
            Vector2 last = Vector2.UnitX * radius;
            Vector2 lastP = last.Perpendicular();
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 at = Calc.AngleToVector(i * MathHelper.PiOver2 / resolution, radius);
                Vector2 atP = at.Perpendicular();

                Line(position + last, position + at, color, thickness);
                Line(position - last, position - at, color, thickness);
                Line(position + lastP, position + atP, color, thickness);
                Line(position - lastP, position - atP, color, thickness);

                last = at;
                lastP = atP;
            }
        }

        public static void Circle(float x, float y, float radius, Color color, float thickness, int resolution)
        {
            Circle(new Vector2(x, y), radius, color, thickness, resolution);
        }

        #endregion

        #region Rect

        public static void Rect(float x, float y, float radius, Color c)
        {
            Rect(x - radius, y - radius, radius * 2, radius * 2, c);
        }

        public static void Rect(Vector2 pos, float radius, Color c)
        {
            Rect(pos.X - radius, pos.Y - radius, radius * 2, radius * 2, c);
        }

        public static void Rect(float x, float y, float width, float height, Color color)
        {
            rect.X = (int)x;
            rect.Y = (int)y;
            rect.Width = (int)width;
            rect.Height = (int)height;
            SpriteBatch.Draw(Pixel, rect, null, color);
        }

        public static void Rect(Vector2 position, float width, float height, Color color)
        {
            Rect(position.X, position.Y, width, height, color);
        }

        public static void Rect(Rectangle rect, Color color)
        {
            Render.rect = rect;
            SpriteBatch.Draw(Pixel, rect, null, color);
        }

        #endregion

        #region Hollow Rect

        public static void HollowRect(float x, float y, float radius, Color c)
        {
            HollowRect(x - radius, y - radius, radius * 2, radius * 2, c);
        }

        public static void HollowRect(Vector2 pos, float radius, Color c)
        {
            HollowRect(pos.X - radius, pos.Y - radius, radius * 2, radius * 2, c);
        }

        public static void HollowRect(float x, float y, float width, float height, Color color)
        {
            rect.X = (int)x;
            rect.Y = (int)y;
            rect.Width = (int)width;
            rect.Height = 1;

            SpriteBatch.Draw(Pixel, rect, null, color);

            rect.Y += (int)height - 1;

            SpriteBatch.Draw(Pixel, rect, null, color);

            rect.Y -= (int)height - 1;
            rect.Width = 1;
            rect.Height = (int)height;

            SpriteBatch.Draw(Pixel, rect, null, color);

            rect.X += (int)width - 1;

            SpriteBatch.Draw(Pixel, rect, null, color);
        }

        public static void HollowRect(Vector2 position, float width, float height, Color color)
        {
            HollowRect(position.X, position.Y, width, height, color);
        }

        public static void HollowRect(Rectangle rect, Color color)
        {
            HollowRect(rect.X, rect.Y, rect.Width, rect.Height, color);
        }

        #endregion

        #region Spritefont Text

        public static void Text(SpriteFont font, string text, Vector2 position, Color color)
        {
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color);
        }

        public static void Text(SpriteFont font, string text, Vector2 position, Color color, Vector2 origin, Vector2 scale, float rotation)
        {
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, rotation, origin, scale, SpriteEffects.None, 0);
        }

        public static void TextJustified(SpriteFont font, string text, Vector2 position, Color color, Vector2 justify)
        {
            Vector2 origin = font.MeasureString(text);
            origin.X *= justify.X;
            origin.Y *= justify.Y;

            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, 1, SpriteEffects.None, 0);
        }

        public static void TextJustified(SpriteFont font, string text, Vector2 position, Color color, float scale, Vector2 justify)
        {
            Vector2 origin = font.MeasureString(text);
            origin.X *= justify.X;
            origin.Y *= justify.Y;
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, scale, SpriteEffects.None, 0);
        }

        public static void TextCentered(SpriteFont font, string text, Vector2 position)
        {
            Text(font, text, position - font.MeasureString(text) * .5f, Color.White);
        }

        public static void TextCentered(SpriteFont font, string text, Vector2 position, Color color)
        {
            Text(font, text, position - font.MeasureString(text) * .5f, color);
        }

        public static void TextCentered(SpriteFont font, string text, Vector2 position, Color color, float scale)
        {
            Text(font, text, position, color, font.MeasureString(text) * .5f, Vector2.One * scale, 0);
        }

        public static void TextCentered(SpriteFont font, string text, Vector2 position, Color color, float scale, float rotation)
        {
            Text(font, text, position, color, font.MeasureString(text) * .5f, Vector2.One * scale, rotation);
        }

        public static void OutlineTextCentered(SpriteFont font, string text, Vector2 position, Color color, float scale)
        {
            Vector2 origin = font.MeasureString(text) / 2;

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.DrawString(font, text, Calc.Floor(position) + new Vector2(i, j), Color.Black, 0, origin, scale, SpriteEffects.None, 0);
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, scale, SpriteEffects.None, 0);
        }

        public static void OutlineTextCentered(SpriteFont font, string text, Vector2 position, Color color, Color outlineColor)
        {
            Vector2 origin = font.MeasureString(text) / 2;

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.DrawString(font, text, Calc.Floor(position) + new Vector2(i, j), outlineColor, 0, origin, 1, SpriteEffects.None, 0);
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, 1, SpriteEffects.None, 0);
        }

        public static void OutlineTextCentered(SpriteFont font, string text, Vector2 position, Color color, Color outlineColor, float scale)
        {
            Vector2 origin = font.MeasureString(text) / 2;

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.DrawString(font, text, Calc.Floor(position) + new Vector2(i, j), outlineColor, 0, origin, scale, SpriteEffects.None, 0);
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, scale, SpriteEffects.None, 0);
        }

        public static void OutlineTextJustify(SpriteFont font, string text, Vector2 position, Color color, Color outlineColor, Vector2 justify)
        {
            Vector2 origin = font.MeasureString(text) * justify;

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.DrawString(font, text, Calc.Floor(position) + new Vector2(i, j), outlineColor, 0, origin, 1, SpriteEffects.None, 0);
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, 1, SpriteEffects.None, 0);
        }

        public static void OutlineTextJustify(SpriteFont font, string text, Vector2 position, Color color, Color outlineColor, Vector2 justify, float scale)
        {
            Vector2 origin = font.MeasureString(text) * justify;

            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        SpriteBatch.DrawString(font, text, Calc.Floor(position) + new Vector2(i, j), outlineColor, 0, origin, scale, SpriteEffects.None, 0);
            SpriteBatch.DrawString(font, text, Calc.Floor(position), color, 0, origin, scale, SpriteEffects.None, 0);
        }

        #endregion

        #region Bitmap Text

        public static void Text(BitmapFont font, string text, Vector2 position)
        {
            font.DrawString(text, Calc.Floor(position));
        }

        public static void Text(BitmapFont font, string text, Vector2 position, Color color)
        {
            font.DrawString(text, Calc.Floor(position), color);
        }

        public static void TextCentered(BitmapFont font, string text, Vector2 position)
        {
            Text(font, text, position - font.MeasureString(text) * .5f, Color.White);
        }

        public static void TextCentered(BitmapFont font, string text, Vector2 position, Color color)
        {
            Text(font, text, position - font.MeasureString(text) * .5f, color);
        }

        public static void OutlineTextCentered(BitmapFont font, string text, Vector2 position, Color color, Color outlineColor)
        {
            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (i != 0 || j != 0)
                        TextCentered(font, text, Calc.Floor(position) + new Vector2(i, j), outlineColor);
            TextCentered(font, text, Calc.Floor(position), color);
        }

        #endregion

        #region Weird Stuff

        public static void Function(Func<float, float> func, Vector2 origin, int max, Color color)
        {
            Vector2 from;
            Vector2 to = new Vector2(0, func(0)) + origin;

            Line(origin, origin + Vector2.UnitX * max, Color.Black);

            for (int x = 3; x < max; x += 4)
            {
                from = to;
                to = new Vector2(x, func(x)) + origin;

                Line(from, to, color);
            }

            from = to;
            to = new Vector2(max, func(max)) + origin;

            Line(from, to, color);
        }

        public static void PointFunction(Func<float, Vector2> func, Vector2 origin, int max, Color color)
        {
            Vector2 from;
            Vector2 to = func(0) + origin;

            for (int x = 5; x < max; x += 4)
            {
                from = to;
                to = func(x) + origin;

                Line(from, to, color);
            }

            from = to;
            to = func(max) + origin;

            Line(from, to, color);
        }

        #endregion

        #region Spline

        public static void Spline(Vector2[] points, float width, Color color, float resolution = 0.03f)
        {
            Vector2 prev = Calc.GetSplinePoint(points, 0);

            for (float t = resolution; t < points.Length - 3f; t += resolution)
            {
                Vector2 next = Calc.GetSplinePoint(points, t);
                Line(prev, next, color, width);
                prev = next;
            }
        }

        #endregion

        public static void Begin(Effect effect = null)
        {
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, effect, Controller.Instance.Camera.Matrix);
        }

        public static void End()
        {
            SpriteBatch.End();
        }
    }
}
