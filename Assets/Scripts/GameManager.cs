using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject RetryBtn;
    public GameObject Dog;
    public GameObject Food;
    public GameObject NormalCat;
    public GameObject FatCat;
    public GameObject PirateCat;
    public Text levelText;
    public GameObject levelFront;

    int level = 0;
    int cat = 0;
    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeFood", 0.0f, 0.1f);
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFood()
    {
        float x = Dog.transform.position.x;
        float y = Dog.transform.position.y + 2.0f;
        Instantiate(Food, new Vector3(x, y, 0), Quaternion.identity);
    }

    void MakeCat()
    {
        Instantiate(NormalCat);
        float p = Random.Range(0, 10);
        if (level == 1)
        {
            if (p < 2) Instantiate(NormalCat);
        }
        else if(level == 2)
        {
            if(p < 4) Instantiate(NormalCat);
        }
        else if (level == 3)
        {
            if (p < 6) Instantiate(NormalCat);
            Instantiate(FatCat);
        }
        else if (level >= 4)
        {
            if (p < 3) Instantiate(NormalCat);
            else if (p >= 4 && p < 7) Instantiate(FatCat);
            Instantiate(PirateCat);
        }
    }

    public void GameOver()
    {
        RetryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}
