using Game.Abstracciones;
using System;
using System.Collections.Generic;

namespace Game.SingletonManagers
{
    public static class CollisionController
    {

        public static bool ControlarColision(Vector2D v1, Vector2D v2)
        {
            return VerificarColisionEnX(v1, v2) && VerificarColisionEnY(v1, v2);
        }

        #region Funciones privadas

        //Corresponde que este metodo sea privado, lo dejo publico solo para poder correr los tests.
        private static bool VerificarColisionEnX(Vector2D v1, Vector2D v2)
        {
            if ((v1.LimiteDerecha < v2.LimiteDerecha && v1.LimiteIzquierda > v2.LimiteIzquierda)
                || (v2.LimiteDerecha < v1.LimiteDerecha && v2.LimiteIzquierda > v1.LimiteIzquierda)
                || (v1.X == v2.X))
                return true; //Colisiona por completo

            if ((v1.X < v2.X && v1.LimiteDerecha > v2.LimiteIzquierda)
                || (v2.X < v1.X && v2.LimiteDerecha > v1.LimiteIzquierda))
                return true; //Colision parcial
            return false;
        }

        //Corresponde que este metodo sea privado, lo dejo publico solo para poder correr los tests.
        private static bool VerificarColisionEnY(Vector2D v1, Vector2D v2)
        {
            if ((v1.LimiteTop < v2.LimiteTop && v1.LimiteBot > v2.LimiteBot)
                || (v2.LimiteTop < v1.LimiteTop && v2.LimiteBot > v1.LimiteBot)
                || (v1.Y == v2.Y))
                return true; //Colisiona por completo

            if ((v1.Y < v2.Y && v1.LimiteTop > v2.LimiteBot)
                || (v2.Y < v1.Y && v2.LimiteTop > v1.LimiteBot))
                return true; //Colision parcial
            return false;
        }

        #endregion

    }
}
