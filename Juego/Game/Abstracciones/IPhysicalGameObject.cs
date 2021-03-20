using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstracciones
{
    public interface IPhysicalGameObject 
    {
        string Type { get; set; }
        float GravityScale { get; set; }
        bool CanCollide { get; set; }
        void ApplyForce(Vector2D direccion, float fuerza = 1f);
        bool IsGrounded();
    }
}
