using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botter : Actor
{
    private Vector3 basePos; //Base Position of Botter. It help to reset Position of Botter after a turn.

    //this Update() work like actor intelliger
    protected virtual void Update()
    {
        GameObject target = find_target_in_range("Topper");

        if (target == null)     //no target in view range
            play_animation(State.Idle);       
        else
        {
            if (target_is_in_attack_range(target)) //target is also in attack range -> attack target
            {
                play_animation(State.Attack);
                attack(target);
            }
            else //target is in view range but not in attack range -> move to that target
            {
                move_to(target);
                play_animation(State.Walking);  
            }
        }
    }

    private void LateUpdate() //Dead is happend in LateUpdate to prevent actor target on a removed target
    {
        if (isDead())
            botter_dead();
    }


    protected void botter_dead()
    {
        //Botter dead is not actually destroyed but just disable to be enable again in next turn
        GameEnvironment.Singleton.RemoveBotter(this.gameObject);
        GameEnvironment.Singleton.AddDeadBotter(this.gameObject);
        //Dead Animation (in couratine)

        this.gameObject.SetActive(false);
    }

    public Vector3 BasePos
    {
        get
        {
            return basePos;
        }
        set
        {
            basePos = value;
        }
    }



    //reset botter after a Turn
    protected void reset()
    {
        this.transform.position = basePos;
        this.HP = maxHP;
    }
}
