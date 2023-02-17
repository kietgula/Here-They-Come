using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Botter
{
    bool isTriggered = false;

    new protected void Update()
    {
        base.Update();

        breave();  //if half hp then trigger passive up armor + reduce attack damage
    }

    void breave()
    {
        if (this.HP * 2 <= this.maxHP && isTriggered == false)
        {
            //animation;
            this.armorPoint = this.armorPoint * 2;
            this.attackDamage = this.attackDamage / 2;
            isTriggered = true;
        }
        else if (this.HP * 2 > this.maxHP && isTriggered == true)
        {
            //animation;
            this.armorPoint = this.armorPoint / 2;
            this.attackDamage = this.attackDamage * 2;
        }

    }
}
