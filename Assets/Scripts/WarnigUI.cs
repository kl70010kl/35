using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarnigUI : MonoBehaviour
{
    private Slider warningSlider;
    public float warningDgree;
    private float setSlider;
    public Image fillImage;
    public GameObject enemy;
    private EnemyMove enemyMove;
    private float timer;
    
    public Image fillImage2;
    public Image fillImage3;
    public Image fillImage4;
    public Image fillImage5;
    public Image fillImage6;
    public Image fillImage7;
    public Image fillImage8;
    public Image fillImage9;

    public static float enemySpeed;

    //Color orange;

    //public static Color rgb(int red, int green, int blue)
    //{
    //    return new Color(red / 255f, green / 255f, blue / 255f);
    //}

    //public static Color Orange = rgb(255, 215, 0);

    // Start is called before the first frame update
    void Start()
    {
        warningSlider = GameObject.Find("WarningDigree").GetComponent<Slider>();
        enemyMove = enemy.GetComponent<EnemyMove>();
        setSlider = 100;
        warningDgree = 0;
        enemySpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(warningDgree >= 225)
        {
            warningDgree = 225;
        }
        if(warningDgree <= 0)
        {
            warningDgree = 0;
        }

        if(enemyMove.GetEnemyState() == EnemyMove.EnemyState.Walk)
        {
            timer += Time.deltaTime;
            if(timer >= 1.0f)
            {
                warningDgree -= 25;
                timer = 0;
            }
        }
        
        if (warningDgree < 25)
        {
            fillImage.color = Color.gray;
            fillImage2.color = Color.gray;
            fillImage3.color = Color.gray;
            fillImage4.color = Color.gray;
            fillImage5.color = Color.gray;
            fillImage6.color = Color.gray;
            fillImage7.color = Color.gray;
            fillImage8.color = Color.gray;
            fillImage9.color = Color.gray;
        }
        else if (warningDgree < 50)
        {
            fillImage.color = Color.green;
            fillImage2.color = Color.gray;
            enemySpeed = 10;
        }
        else if (warningDgree < 75)
        {
            fillImage2.color = Color.green;
            fillImage3.color = Color.gray;
            enemySpeed = 20;
        }
        else if (warningDgree < 100)
        {
            fillImage.color = Color.green;
            fillImage2.color = Color.green;
            fillImage3.color = Color.green;
            fillImage4.color = Color.gray;
            enemySpeed = 30;
        }
        else if (warningDgree < 125)
        {
            fillImage.color = Color.yellow;
            fillImage2.color = Color.yellow;
            fillImage3.color = Color.yellow;
            fillImage4.color = Color.yellow;
            fillImage5.color = Color.gray;
            enemySpeed = 40;
        }
        else if (warningDgree < 150)
        {
            fillImage5.color = Color.yellow;
            fillImage6.color = Color.gray;
            enemySpeed = 50;
        }
        else if (warningDgree < 175)
        {
            fillImage.color = Color.yellow;
            fillImage2.color = Color.yellow;
            fillImage3.color = Color.yellow;
            fillImage4.color = Color.yellow;
            fillImage5.color = Color.yellow;
            fillImage6.color = Color.yellow;
            fillImage7.color = Color.gray;
            enemySpeed = 60;
        }
        else if (warningDgree < 200)
        {
            fillImage.color = Color.red;
            fillImage2.color = Color.red;
            fillImage3.color = Color.red;
            fillImage4.color = Color.red;
            fillImage5.color = Color.red;
            fillImage6.color = Color.red;
            fillImage7.color = Color.red;
            fillImage8.color = Color.gray;
            enemySpeed = 70;
        }
        else if (warningDgree < 225)
        {
            fillImage8.color = Color.red;
            fillImage9.color = Color.gray;
            enemySpeed = 80;
        }
        else if (warningDgree < 250)
        {
            fillImage9.color = Color.red;
            enemySpeed = 90;
        }
        //else
        //{
        //    fillImage9.color = Color.red;
        //}
    }

    public void GetWarningDgree(float warningDgree)
    {
        this.warningDgree += warningDgree;
    }
}
