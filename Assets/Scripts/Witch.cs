using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Witch : Botter
{
    public GameObject SpellBullet;
    protected override void attack(GameObject target)
    {
        if (next_attack_time <= Time.time)
        { 
            GameObject spell = Instantiate(SpellBullet, target.transform.position, target.transform.rotation);
            spell.GetComponent<Spell>().SpellOwner = this.gameObject;
            next_attack_time = Time.time + 1 / this.attackSpeed;
        }
    }

    protected new void Start()
    {
        //animation prepare
        //scale attack speed animation with attack speed
        animator = GetComponent<Animator>();
        animator.SetFloat("AttackFreq", (float)attackSpeed / 3f /(3f/2f)); //this witch is specific because it's attack animation is longer than others. That's why i decide to divided it by (1/2) / (1/3)

        //it's animation is still not perfect :( 

        HP = maxHP;
        next_attack_time = Time.time + 1 / this.attackSpeed;
    }
}
