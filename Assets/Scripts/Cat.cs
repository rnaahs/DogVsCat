using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    float full = 5.0f;
    float energy = 0.0f;
    bool isfull = false;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0);

        if(type == 1)
        {
            full = 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(energy < full)
        {
            //畴富成
            if(type == 0)
            {
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            }
            //蹲成
            else if(type == 1)
            {
                transform.position += new Vector3(0.0f, -0.03f, 0.0f);
            }
            //秦利成
            else if(type == 2)
            {
                transform.position += new Vector3(0.0f, -0.1f, 0.0f);
            }
            if (transform.position.y < -16f)
            {
                GameManager.I.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            if (energy < full) {
                energy += 1.0f;
                Destroy(collision.gameObject);
                gameObject.transform.Find("Hungry/Canvas/Front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                if(energy == full)
                {
                    if (!isfull)
                    {
                        GameManager.I.addCat();
                        gameObject.transform.Find("Hungry").gameObject.SetActive(false);
                        gameObject.transform.Find("Full").gameObject.SetActive(true);
                        isfull = true;
                    }
                }
            }
            else
            {
                if(!isfull)
                {
                    GameManager.I.addCat();
                    gameObject.transform.Find("Hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("Full").gameObject.SetActive(true);
                    isfull = true;
                }
            }
        }
    }
}