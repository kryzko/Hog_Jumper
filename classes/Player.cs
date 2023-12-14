using Hog_Jumper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hog_Jumper.classes
{
    internal class Player
    {
        public Physics physics;
        public Image sprite;
        public bool IsFacingLeft;

        public Player(int name)
        {
            if (name == 0)
                this.sprite = Properties.Resources.Hog1_standing;
            if (name == 1)
                this.sprite = Properties.Resources.Hog2_standing;
            if (name == 2)
                this.sprite = Properties.Resources.Hog3_standing;
            if (name == 3)
                this.sprite = Properties.Resources.Hog4_standing;
            //изменение спрайта тут делать
            // кароче сделай новую функцию
            // или класс и при нажатии на
            // определенный спрайт в скинах
            // сюда после точки название закидывать пон
            //Form3 form3 = new Form3();
            //if (form3.skin == 0)
            //    sprite = Properties.Resources.Hog1_standing;
            //if (form3.skin == 1)
            //    sprite = Properties.Resources.Png;
            //if (form3.skin == 2)
            //    sprite = Properties.Resources.глаз;
            //if (form3.skin == 3)
            //    sprite = Properties.Resources.праздник;

            physics = new Physics(new Point(100, 250), new Size(60, 40));
            this.IsFacingLeft = false;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
