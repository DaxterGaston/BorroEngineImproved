using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstracciones
{
    public abstract class PhysicalGameObject : GameObject, IPhysicalGameObject
    {
        private readonly float gravity = 9.8f;
        private readonly float deficiency = 0.2f;

        public PhysicalGameObject(string path, bool animate, Vector2D initialPosition, string animationsName = null) : base(path, animate, initialPosition, animationsName)
        {

        }

        public string Type { get; set; }
        public float GravityScale { get; set; }
        public bool CanCollide { get; set; }
        
        public void ApplyForce(Vector2D direccion, float fuerza = 1f)
        {
            throw new NotImplementedException();
        }

        public bool IsGrounded()
        {
            throw new NotImplementedException();
        }
    }
}
