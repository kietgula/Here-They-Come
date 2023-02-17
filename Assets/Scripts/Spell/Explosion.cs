using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Spell
{
    public double SpellDamage = 1;
    public float ExistTime = 1;

    private void Start()
    {
        //this spell does damage equal to spell owner attack damage
        this.SpellDamage = SpellOwner.GetComponent<Actor>().attackDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Topper")
        {     
            collision.gameObject.GetComponent<Actor>().TakeDamage(SpellDamage, "magical");
            Destroy(this.gameObject,ExistTime);
        }
    }

}
