using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.DetectivePikaptchaEp2
{
    public class Pikaptcha
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Face Face { get; private set; }
        public WallOn WallOn { get; private set; }
        public Pikaptcha(int x, int y, Face face)
        {
            this.X = x;
            this.Y = y;
            this.Face = face;
        }
        public Pikaptcha(int x, int y, char face) : this(x, y, FromString(face))
        {
           
        }
        private static Face FromString(char face)
        {
            switch (face)
            {
                default:
                case '>':
                    return Face.Right;
                case 'v':
                    return Face.Down;
                case '<':
                    return Face.Left;
                case '^':
                    return Face.Up;
            }
        }
        public void SetWallOn(string value)
        {
            if (value == "L")
                this.WallOn = WallOn.Left;
            else
                this.WallOn = WallOn.Right;
        }
        public (int X, int Y) Move(int x, int y, int[,] cells, int width, int height)
        {
            int count = 0;
            (int X, int Y, Face face) next;
            Face face = this.Face;
            do
            {
                if (count > 0)
                    face = face.Rotate(this.WallOn);
                next = face.Next(this.WallOn, x, y);
                count++;
            } while (count <= 4 && (next.X < 0 || next.Y < 0 || next.X >= width || next.Y >= height || cells[next.X, next.Y] < 0));
            if (count > 4)
                return (-1, -1);
            this.Face = next.face;
            return (next.X, next.Y);
        }
    }
    public static class FaceExtensions
    {
        public static (int X, int Y, Face Face) Next(this Face face, WallOn wallOn, int x, int y)
        {
            switch (face)
            {
                default:
                case Face.Right:
                    if (wallOn == WallOn.Left)
                        return (x, y - 1, Face.Up);
                    else
                        return (x, y + 1, Face.Down);
                case Face.Left:
                    if (wallOn == WallOn.Left)
                        return (x, y + 1, Face.Down);
                    else
                        return (x, y - 1, Face.Up);
                case Face.Down:
                    if (wallOn == WallOn.Left)
                        return (x + 1, y, Face.Right);
                    else
                        return (x - 1, y, Face.Left);
                case Face.Up:
                    if (wallOn == WallOn.Left)
                        return (x - 1, y, Face.Left);
                    else
                        return (x + 1, y, Face.Right);
            }
        }
        public static Face Rotate(this Face face, WallOn wallOn)
        {
            if (wallOn == WallOn.Left)
            {
                switch (face)
                {
                    case Face.Down:
                        return Face.Left;
                    case Face.Left:
                        return Face.Up;
                    case Face.Up:
                        return Face.Right;
                    default:
                    case Face.Right:
                        return Face.Down;
                }
            }
            else
            {
                switch (face)
                {
                    case Face.Down:
                        return Face.Right;
                    case Face.Left:
                        return Face.Down;
                    case Face.Up:
                        return Face.Left;
                    default:
                    case Face.Right:
                        return Face.Up;
                }
            }
        }
    }
    public enum Face
    {
        Right,
        Down,
        Left,
        Up
    }
    public enum WallOn
    {
        Left,
        Right
    }
}
