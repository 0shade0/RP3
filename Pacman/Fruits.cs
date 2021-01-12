using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class Fruit : movableCharacter
    {
        protected bool rotten;

        public Fruit(Form form, bool _rotten) : base(form)
        {
            rotten = _rotten;
        }
    }

    public class Apple : Fruit
    {
        public Apple(Form form, bool _rotten) : base(form, _rotten)
        {

        }
    }

    public class Cherry : Fruit
    {
        public Cherry(Form form, bool _rotten) : base(form, _rotten)
        {

        }
    }

    public class Pear : Fruit
    {
        public Pear(Form form, bool _rotten) : base(form, _rotten)
        {

        }
    }



}
