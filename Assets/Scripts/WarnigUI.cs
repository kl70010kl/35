using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarnigUI : MonoBehaviour
{
    private Slider warningSlider;
    private float warningDgree;
    private float setSlider;
    public Image fillImage;
    public GameObject enemy;
    private EnemyMove enemyMove;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        warningSlider = GameObject.Find("WarningDigree").GetComponent<Slider>();
        enemyMove = enemy.GetComponent<EnemyMove>();
        setSlider = 100;
        warningDgree = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(warningDgree >= 100)
        {
            warningDgree = 100;
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

        if (warningDgree < 50)
        {
            fillImage.color = Color.green;
        }
        else if(warningDgree < 100)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }

    public void GetWarningDgree(float warningDgree)
    {
        this.warningDgree += warningDgree;
    }
}
