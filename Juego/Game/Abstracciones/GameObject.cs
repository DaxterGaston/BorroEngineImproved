using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstracciones
{
    public abstract class GameObject : Drawable
    {
        public GameObject(string path, bool animate, Vector2D initialPosition, string animationsName = null) : base(path, animate, initialPosition, animationsName)
        {

        }
    }
}
