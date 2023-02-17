using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHeart : MonoBehaviour
{
    public int life;
    public GameObject LoveRunSpell;
    public GameObject GameManager;

    bool isInvincible = false;

    private void Update()
    {
        if (this.life < 0)
            GameManager.GetComponent<GameManager>().GameOver();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Topper")
        {
            if (!isInvincible)
            {
                Instantiate(LoveRunSpell, this.transform.position, Quaternion.identity);
                StartCoroutine(Invincible());
            }
        }
    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        life--;
        yield return new WaitForSeconds(1); //5s invincible after toucher topper
        isInvincible = false;
    }
}
