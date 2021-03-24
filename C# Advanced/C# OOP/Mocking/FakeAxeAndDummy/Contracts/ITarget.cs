using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public interface ITarget
    {
        void TakeAttack(int attack);

        int GiveExperience();

        bool IsDead();
    }
}
