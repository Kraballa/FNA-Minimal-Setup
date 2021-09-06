using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Namespace
{
    /// <summary>
    /// Basic Mouse input class that handles mouse clicks and presses.
    /// </summary>
    public static class MInput
    {
        public static MouseState State { get; private set; }
        public static MouseState Previous { get; private set; }

        public static int X => State.X;
        public static int Y => State.Y;
        public static Point Position => new Point(State.X, State.Y);
        public static Vector2 PositionF => new Vector2(State.X, State.Y);

        public static void Initialize()
        {
            State = Mouse.GetState();
        }

        public static void Update()
        {
            Previous = State;
            State = Mouse.GetState();
        }

        public static bool Left()
        {
            return State.LeftButton == ButtonState.Pressed;
        }

        public static bool LeftPressed()
        {
            return Left() && Previous.LeftButton == ButtonState.Released;
        }

        public static bool LeftReleased()
        {
            return !Left() && Previous.LeftButton == ButtonState.Pressed;
        }

        public static bool Right()
        {
            return State.RightButton == ButtonState.Pressed;
        }

        public static bool RightPressed()
        {
            return Right() && Previous.RightButton == ButtonState.Released;
        }

        public static bool RightReleased()
        {
            return !Right() && Previous.RightButton == ButtonState.Pressed;
        }

        public static int MouseWheelDelta()
        {
            return Math.Sign(State.ScrollWheelValue - Previous.ScrollWheelValue);
        }
    }
}
