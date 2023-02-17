using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveRun : Spell //it's inherited from Spell, but doesnt really have spellOwner. I will work on this in the next time
{
    //this spell kill all topper that is existing in the whole map
    Rigidbody2D rb;
    [SerializeField] float speedOfLove;
    float damageOfLove = 99999;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, speedOfLove, 0);
        Destroy(this.gameObject, 20/speedOfLove); //because i dont want when speed of love too slow. it will disappear before it touch the topper
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Topper")
        {
            collision.gameObject.GetComponent<Actor>().TakeDamage(damageOfLove, "magical");
        }
    }
}
