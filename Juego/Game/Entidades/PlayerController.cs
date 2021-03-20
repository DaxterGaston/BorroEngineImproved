using Game.Abstracciones;
using Game.SingletonManagers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entidades
{
    #region Enumeraciones

    enum ActualState
    { 
        Idle,
        Run,
        Jump,
        Death
    }
    enum Directions
    { 
        Left,
        Right
    }

    #endregion
    
    public class PlayerController : PhysicalGameObject, IUpdatable
    {
        #region SetUp

        private float _speed = 3f;
        private Directions _actualDirection;
        private ActualState _actualState;
        private Stopwatch sw;
        private TimeSpan tsShoot;
        public PlayerController() : base("Idle_Right", true, new Vector2D(250, 450), "Player")
        {
            Array states;
            Array directions;
            _actualState = ActualState.Idle;
            _actualDirection = Directions.Right;
            states = Enum.GetValues(typeof(ActualState));
            directions = Enum.GetValues(typeof(Directions));
            AddAnimations(states, directions);

            sw = new Stopwatch();
            //Se inicia aca para poder disparar la primera vez...
            sw.Start();
            tsShoot = new TimeSpan(0, 0, 1);
        }

        #endregion

        public void Update()
        {
            
            if (Engine.GetKey(Keys.A))
            {
                X -= _speed;
                _actualState = ActualState.Run;
                _actualDirection = Directions.Left;
            }
            else if (Engine.GetKey(Keys.D))
            {
                X += _speed;
                _actualState = ActualState.Run;
                _actualDirection = Directions.Right;
            }
            else
            {
                _actualState = ActualState.Idle;
            }
            if (Engine.GetKey(Keys.SPACE))
            {
                Y = Y - 1f;
                _actualState = ActualState.Jump;
            }
            if (Engine.GetKey(Keys.Z))
            {
                if (sw.Elapsed >= tsShoot)
                {
                    Bullet bullet = new Bullet(GetAimingDirection(), GetShootingPosition());
                    LevelManager.AddRender(1, bullet);
                    LevelManager.AddUpdate(bullet);
                    sw.Restart();
                }
            }
            ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            UpdateState(_actualState.ToString(), _actualDirection.ToString());
        }

        private Vector2D GetAimingDirection()
        {
            return _actualDirection == Directions.Left ? new Vector2D(-1, 0) : new Vector2D(1, 0);
        }

        private Vector2D GetShootingPosition()
        {
            return _actualDirection == Directions.Left ? new Vector2D(X - OffsetX, Y) : new Vector2D(X + OffsetX, Y);
        }
    }
}
