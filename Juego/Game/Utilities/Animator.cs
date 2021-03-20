using Game.Abstracciones;
using System;
using System.Drawing;
using System.IO;

namespace Game.Utilities
{
    public class Animator
    {
        #region SetUp

        private TimeSpan ts = new TimeSpan(0, 0, 0, 0, 150);
        DateTime dt = new DateTime();
        private readonly string Path = "Animaciones/";
        private readonly string objetcToAnimateFolder;
        private int sprites;
        private int actualIndex = 0;
        private string folderPath;
        private string name = "tile00";
        private string actual;
        private float _height;
        private float _width;
        
        
        #endregion
        
        /// <summary>
        /// Animador.
        /// </summary>
        /// <param name="folderName">Carpeta de animacion especifica.</param>
        /// <param name="AnimationName">Carpeta donde se guardan carpetas de animaciones.</param>
        public Animator(string folderName, string AnimationName)
        {
            objetcToAnimateFolder = AnimationName;
            folderPath = objetcToAnimateFolder + "/" + folderName + "/";
            sprites = Directory.GetFiles(Path + folderPath, "*", SearchOption.AllDirectories).Length;
            dt = DateTime.Now;
            Image img = Image.FromFile(Path + folderPath + name + "0.png");
            _height = img.Height / 2;
            _width = img.Width / 2;
        }

        public void Animate(float x, float y, bool loop = true)
        {
            if (!loop && actualIndex == sprites - 1) return;
            actual = Path + folderPath + name + actualIndex + ".png";
            Engine.Draw(actual, x - _height, y - _width);
            if (dt.Add(ts) < DateTime.Now)
            { 
                actualIndex++;
                dt = DateTime.Now;
            }
            if (actualIndex == sprites - 1)
                actualIndex = 0;
        }

        public void UpdateFolderPath(string path)
        {
            folderPath = objetcToAnimateFolder + "/" + path + "/";
            sprites = Directory.GetFiles(Path + folderPath, "*", SearchOption.AllDirectories).Length;
            actualIndex = 0;
        }

        public string GetPath()
        {
            return Path + folderPath + name + "0.png";
        }
    }
}
