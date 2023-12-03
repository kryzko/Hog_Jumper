using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hog_Jumper.classes
{
    internal class Player
    {
        public Physics physics;
        public Image sprite;

        public Player()
        {
            //изменение спрайта тут делать
            // кароче сделай новую функцию
            // или класс и при нажатии на
            // определенный спрайт в скинах
            // сюда после точки название закидывать пон

            sprite = Properties.Resources.Hog1_standing; 
            physics = new Physics(new Point(100, 440), new Size(40, 40));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
