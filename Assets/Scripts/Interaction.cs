using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    private new Camera camera;

    public GameObject BalanceText;
    public GameObject HeartLfeText;
    public GameObject TheHeart;

    public GameObject Botter1 = null;
    public GameObject Botter2 = null;
    public GameObject Botter3 = null;
    public GameObject Botter4 = null;

    public int botter1_value;
    public int botter2_value;
    public int botter3_value;
    public int botter4_value;

    private GameObject current_botter_select { get; set; } = null;
    private int current_botter_value;


    public void Botter1_Select()
    {
        current_botter_select = Botter1;
        current_botter_value = botter1_value;
    }

    public void Botter2_Select()
    {
        current_botter_select = Botter2;
        current_botter_value = botter2_value;

    }

    public void Botter3_Select()
    {
        current_botter_select = Botter3;
        current_botter_value = botter3_value;

    }

    public void Botter4_Select()
    {
        current_botter_select = Botter4;
        current_botter_value = botter4_value;

    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_botter_select != null)
        {
            Vector3 initPos = camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0) && initPos.x<3 && initPos.x>-3 && initPos.y<3.5 && initPos.y>-4)
            {
                if (GameEnvironment.Singleton.Balance >= current_botter_value )
                {

                    GameObject botter = Instantiate(current_botter_select, new Vector3(initPos.x, initPos.y, 0), Quaternion.identity);

                    GameEnvironment.Singleton.AddBotter(botter);
                    botter.GetComponent<Botter>().BasePos = Input.mousePosition;

                    GameEnvironment.Singleton.ReduceMoney(current_botter_value);
                }
            }
        }

        BalanceText.GetComponent<TextMeshProUGUI>().text = GameEnvironment.Singleton.Balance.ToString();

        HeartLfeText.GetComponent<TextMeshProUGUI>().text = TheHeart.GetComponent<TheHeart>().life.ToString();
    }


}
