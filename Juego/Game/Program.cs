using Game.Abstracciones;
using Game.Entidades;
using Game.SingletonManagers;
using Game.Utilities;
using System;
using System.Collections.Generic;

// Comment test
namespace Game
{
    public class Program
    {
        private static PlayerController pc = new PlayerController();
        
        static void Main(string[] args)
        {
            Engine.Initialize();
            LevelManager.AddRender(1, pc);
            LevelManager.AddUpdate(pc);
            while (true)
            {
                LevelManager.Update();
                Render();
            }
        }

        private static void Render()
        {
            Engine.Clear();
            LevelManager.Render();
            Engine.Show();
        }
    }
}