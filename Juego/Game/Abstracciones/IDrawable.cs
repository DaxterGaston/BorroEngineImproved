using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Abstracciones
{
    public interface IDrawable
    {
        /// <summary>
        /// Renderiza el objeto dentro del engine.
        /// </summary>
        void Render();
    }
}
