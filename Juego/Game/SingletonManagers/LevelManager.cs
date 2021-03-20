using Game.Abstracciones;
using System;
using System.Collections.Generic;

namespace Game.SingletonManagers
{
    public static class LevelManager
    {
        private static List<IUpdatable> UpdatableList = new List<IUpdatable>();

        private static List<KeyValuePair<int, IDrawable>> DrawableList = new List<KeyValuePair<int, IDrawable>>();

        public static void AddRender(int order, IDrawable drawable)
        {
            var render = new KeyValuePair<int, IDrawable>(order, drawable);
            DrawableList.Add(render);
        }

        public static void AddUpdate(IUpdatable updatable)
        {
            UpdatableList.Add(updatable);
        }

        public static void Update()
        {
            //Aun que usar un foreach es mas performante que un for, se recorre la lista de esta manera ya que durante su ejecucion esta modificandose. 
            for (int i = 0; i < UpdatableList.Count; i++)
            {
                UpdatableList[i].Update();
            }
        }

        public static void Render()
        {
            foreach (var item in DrawableList)
                item.Value.Render();
        }

        private static void OrderRenderList()
        {
            throw new NotImplementedException();
        }
    }
}
