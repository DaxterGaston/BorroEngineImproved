using Game.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game.Abstracciones
{
    enum RenderTypeEnum
    {
        Animatable,
        Static
    }

    public delegate void RenderType();
    public abstract class Drawable : Vector2D, IDrawable
    {
        #region SetUp

        private RenderType render;

        private Dictionary<string, string> Animations;

        RenderTypeEnum _actualRender;

        protected Animator _animator { get; set; }

        private string spritePath;
        private string _actualState;
        private string _actualDirection;
        

        /// <summary>
        /// Clase de dibujo. Admite animaciones de sprites.
        /// </summary>
        /// <param name="path">Path de la textura para no animables. De la carpeta de sprites de la accion si es animacion.</param>
        /// <param name="animate">Si es animable o no.</param>
        /// <param name="animationsName">Carpeta con el nombre del objeto que se quiere animar.</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Drawable(string path, bool animate, Vector2D initialPosition, string animationsName = null) : base(initialPosition)
        {
            X = initialPosition.X;
            Y = initialPosition.Y;
            if (animate)
            {
                _animator = new Animator(path, animationsName);
                render = new RenderType(Animate);
                _actualRender = RenderTypeEnum.Animatable;
                Animations = new Dictionary<string, string>();
                GetOffsets();
            }
            else
            {
                spritePath = "Sprites/" + path;
                GetOffsets(spritePath);
                render = new RenderType(Draw);
                _actualRender = RenderTypeEnum.Static;
            }
        }
        
        #endregion

        public void Render()
        {
            render();
        }

        #region Metodos Protegidos

        protected void Draw()
        {
            Engine.Draw(spritePath, X - OffsetX, Y - OffsetY);
        }

        protected void Animate()
        {
            _animator.Animate(X, Y);
        }

        protected void ChangeRenderType(string type, bool loop = true)
        {
            if (_actualRender == RenderTypeEnum.Animatable)
                _actualRender = RenderTypeEnum.Static;
            else
                _actualRender = RenderTypeEnum.Animatable;
        }

        protected void UpdateState(string state, string direction)
        {
            if (_actualState == state && _actualDirection == direction) return;
            string path = state + "_" + direction;
            if (_actualRender == RenderTypeEnum.Animatable)
                _animator.UpdateFolderPath(path);
            else
                spritePath = path;
            _actualState = state;
            _actualDirection = direction;
        }

        protected void AddAnimations(Array action, Array direction)
        {
            string key;
            string path;
            foreach (var a in action)
            {
                foreach (var d in direction)
                {
                    key = a.ToString() + d.ToString();
                    path = a.ToString() + "_" + d.ToString();
                    Animations.Add(key, path);
                }
            }
        }

        #endregion

        #region Metodos Privados

        private void GetOffsets(string path)
        {
            Image img = Image.FromFile(path);
            OffsetX = img.Height / 2;
            OffsetY = img.Width / 2;
        }

        private void GetOffsets()
        {
            string path = _animator.GetPath();
            Image img = Image.FromFile(path);
            OffsetX = img.Height / 2;
            OffsetY = img.Width / 2;
        }

        #endregion
    }
}
