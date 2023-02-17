using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKing : MonoBehaviour
{
    public float auraRange;
    List<GameObject> auraList;

    

    void TheKingAura()
    {
        foreach (GameObject botter in GameEnvironment.Singleton.Botters)
        {
            if (Vector3.Distance(this.gameObject.transform.position, botter.gameObject.transform.position) <=auraRange)
            {

            }
        }
    }
}
