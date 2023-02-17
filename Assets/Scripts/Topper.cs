using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topper : Actor
{
    public GameObject TheHeart = null;

    [SerializeField] int value = 10;


    new void Start()
    {
        base.Start();

        TheHeart = GameObject.FindGameObjectWithTag("TheHeart");
    }


    //this Update() work like actor intelliger
    protected virtual void Update() //virtual because i want to override it sometime to make some specific botter/topper
    {
        GameObject target = find_target_in_range("Botter");

        if (target == null)     //no target in view range
        {
            move_to(TheHeart);
            play_animation(State.Idle);
        }
        else
        {
            if (target_is_in_attack_range(target)) //target is also in attack range -> attack it
            {
                attack(target);
                play_animation(State.Attack);
            }
            else                                   //target is in view range, but not in attack range
            { 
                move_to(target);
                play_animation(State.Walking);
            }
        }     
    }

    private void LateUpdate()  //Dead is happend in LateUpdate to prevent actor target on a removed target
    {
        if (isDead())
            topper_dead();
    }

    private void to_the_South() //GameObject go down yo yo
    {

        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    protected void topper_dead()
    {
        GameEnvironment.Singleton.RemoveTopper(this.gameObject);
        GameEnvironment.Singleton.AddMoney(value);
        //Dead Animation (in couratine)

        Destroy(this.gameObject);
    }

}
