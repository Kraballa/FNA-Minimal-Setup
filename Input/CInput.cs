using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Namespace.Util
{
    public static class CInput
    {
        public const int NUM_GAMEPADS = 4;

        public static GamePadState[] current;
        public static GamePadState[] prev;

        public static void Initialize()
        {
            current = new GamePadState[NUM_GAMEPADS];
            prev = new GamePadState[NUM_GAMEPADS];
            for (int i = 0; i < NUM_GAMEPADS; i++)
            {
                current[i] = GamePad.GetState((PlayerIndex)i);
            }
        }

        public static void Update()
        {
            for (int i = 0; i < NUM_GAMEPADS; i++)
            {
                prev[i] = current[i];
                current[i] = GamePad.GetState((PlayerIndex)i);
            }
        }

        public static bool Check(Buttons button, int playerIndex = 0)
        {
            return current[playerIndex].IsButtonDown(button);
        }

        public static bool CheckPressed(Buttons button, int playerIndex = 0)
        {
            return Check(button, playerIndex) && !prev[playerIndex].IsButtonDown(button);
        }

        public static bool CheckReleased(Buttons button, int playerIndex = 0)
        {
            return !Check(button, playerIndex) && prev[playerIndex].IsButtonDown(button);
        }

        public static Point DPad(int playerIndex = 0)
        {
            GamePadDPad dpad = current[playerIndex].DPad;
            int x = 0;
            int y = 0;
            if (dpad.Left == ButtonState.Pressed) { x--; }
            if (dpad.Right == ButtonState.Pressed) { x++; }
            if (dpad.Up == ButtonState.Pressed) { y--; }
            if (dpad.Down == ButtonState.Pressed) { y++; }
            return new Point(x, y);
        }

        public static Vector2 LeftStick(int playerIndex = 0, float deadZone = 0.2f)
        {
            Vector2 stick = current[playerIndex].ThumbSticks.Left;
            if (stick.Length() < deadZone)
                return Vector2.Zero;
            return stick;
        }

        public static Vector2 RightStick(int playerIndex = 0, float deadZone = 0.2f)
        {
            Vector2 stick = current[playerIndex].ThumbSticks.Left;
            if (stick.Length() < deadZone)
                return Vector2.Zero;
            return stick;
        }

        public static float LeftTrigger(int playerIndex = 0, float deadZone = 0)
        {
            float val = current[playerIndex].Triggers.Left;
            if (val < deadZone)
                return 0f;
            return val;
        }

        public static float RightTrigger(int playerIndex = 0, float deadZone = 0)
        {
            float val = current[playerIndex].Triggers.Right;
            if (val < deadZone)
                return 0f;
            return val;
        }
    }
}
