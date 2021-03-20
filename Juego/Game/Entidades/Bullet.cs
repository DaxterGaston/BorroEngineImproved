using Game.Abstracciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entidades
{
    public class Bullet : PhysicalGameObject, IUpdatable
    {
        Stopwatch sw;
        Vector2D _direction;
        public Bullet(Vector2D direction, Vector2D position) : base("SpongeBullet.png", false, position)
        {
            sw = new Stopwatch();
            _direction = direction;
            sw.Start();
        }

        

        public void Update()
        {
            X += _direction.X;
            Engine.Debug(ActualPosition.X);
            //Si pasaron 3 segundos desde que existe.
            //if (sw.Elapsed.Seconds == 3)
            //{

            //}
        }
    }
}
