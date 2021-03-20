using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstracciones
{
    public class Vector2D
    {
        public Vector2D(float x = 0, float y = 0, float offsetX = 0, float offsetY = 0)
        {
            X = x;
            Y = y;
        }

        public Vector2D(Vector2D initialPosition)
        {
            X = initialPosition.X;
            Y = initialPosition.Y;
        }

        public Vector2D ActualPosition { get { return this; } set { X = value.X; Y = value.Y; } }
        public float OffsetX { get; protected set; }
        public float OffsetY { get; protected set; }
        public float LimiteDerecha { get { return X + OffsetX; } protected set {; } }
        public float LimiteIzquierda { get {return X - OffsetX; } protected set {; } }
        public float LimiteTop { get { return Y - OffsetY; } protected set {; } }
        public float LimiteBot { get { return Y + OffsetY; } protected set {; } }
        public float X { get; protected set; }
        public float Y { get; protected set; }

        #region Operadores

        public static Vector2D operator +(Vector2D v1, Vector2D v2) => new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector2D operator -(Vector2D v1, Vector2D v2) => new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        public static Vector2D operator *(Vector2D v1, float k) => new Vector2D(v1.X * k, v1.Y * k);
        public static Vector2D operator /(Vector2D v1, float k)
        {
            if (k == 0f)
                throw new DivideByZeroException("No podes dividir por cero.");
            return new Vector2D(v1.X / k, v1.Y / k);
        }

        #endregion
    }
}
