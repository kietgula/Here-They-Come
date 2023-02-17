using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

//PLEASE READ
//all of character's class should be inherited from this class
//SOOOOOOOO IMPORTANT
public class Actor : MonoBehaviour
{
    protected Animator animator;

    //basic stats
    public double maxHP = 100;
    [NonSerialized] public double HP;

    public float moveSpeed = 1;

    //attack stats
    public double attackDamage = 10f;
    public float attackSpeed = 1f;
    public double attackRange = 1;
    protected float next_attack_time; //to control attack speed

    //defense stats
    public double armorPoint = 1;
    public string attackType = "physical";
    public string armorType = "steel";

    //privated stats that be hardcode
    private float viewRange = 3;

    protected void Start()
    {
        //animation prepare
        //scale attack speed animation with attack speed
        animator = GetComponent<Animator>();
        animator.SetFloat("AttackFreq", (float)attackSpeed / 3f); 

        HP = maxHP;
        next_attack_time = Time.time + 1 / this.attackSpeed;
    }

    protected GameObject find_target_in_range(string targetTag)
    {
        //look for in-range GameObject that contained in Singleton List
        List<GameObject> targetList = null;

        if (targetTag == "Topper")
            targetList = GameEnvironment.Singleton.Toppers;
        else if (targetTag == "Botter")
            targetList = GameEnvironment.Singleton.Botters;
        
        if (targetList.Count == 0)
            return null; //there is no actor to look for

        float min_distance = Vector3.Distance(this.transform.position, targetList[0].transform.position);
        GameObject closest_topper = null;
        //this loop look for the closest one
        foreach (GameObject actor in targetList)
        {
            //calculate the distance between this actor and that topper. Take the min one
            float distance = Vector3.Distance(this.transform.position, actor.transform.position);
            if (distance <= min_distance)
            {
                closest_topper = actor;
                min_distance = distance;
            }
        }

        //only set target if it is in range. Like they only aim someone of it's in their viewRange. pretty nature ;33
        if (min_distance <= viewRange)
            return closest_topper;
        else return null;
    }

    //protected void call_for_help()

    //attack target aka call target's TakeDamage() function
    protected virtual void attack(GameObject target) //attack target
    {

        if (next_attack_time <= Time.time)
        {
            target.GetComponent<Actor>().TakeDamage(this.attackDamage, this.attackType);
            next_attack_time = Time.time + 1 / this.attackSpeed;
        }
    }

    //this actor take damage, the damage will increase or decrease depend on attack type and armor type
    public void TakeDamage(double damage, string type)
    {
        if (this.armorType == "steel" && type == "physical")
            damage = damage * 0.75;
        else if (this.armorType == "steel" && type == "magical")
            damage = damage * 1.5;
        else if (this.armorType == "wood" && type == "physical")
            damage = damage * 1.5;
        else if (this.armorType == "wood" && type == "magical")
            damage = damage * 0.75;

        damage = damage - (this.armorPoint * 0.06) / (1 + this.armorPoint * 0.06) * damage;

        this.HP = this.HP - damage;
    }

    protected bool isDead()
    {
        if (this.HP < 0)
            return true;
        return false;
    }

    //protected virtual void dead() //both toppers and botters can be dead, but their dead is different to the others
    //{

    //}


    //check if target is in attack range
    protected bool target_is_in_attack_range(GameObject target)
    {
        //if (target == null)

        if (Vector3.Distance(this.transform.position, target.transform.position) <= attackRange)
            return true;
        return false;
    }

    //just move to the target, nothing more
    protected void move_to(GameObject target)
    {
        if (target == null)
            return;

        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;
        float this_x = this.transform.position.x;
        float this_y = this.transform.position.y;

        float aim_x = target_x - this_x;
        float aim_y = target_y - this_y;

        //move to target
        var aim = new Vector3(aim_x, aim_y, 0);
        aim.Normalize();
        this.transform.Translate(aim * this.moveSpeed * Time.deltaTime);
    }


    protected enum State: int
    {
        Idle, //0
        Walking, //1
        Attack, //2
        Dead, //3

        SpellCasting, //4 (not using yet)
       
    }

    protected void play_animation(State state)
    {
        int integer_state = (int) state;

        animator.SetInteger("State", integer_state);
    }

}
