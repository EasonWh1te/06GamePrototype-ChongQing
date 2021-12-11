using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_SceneManager : MonoBehaviour
{
    private float Timer;
    [SerializeField] float setTime;

    [SerializeField] Rigidbody2D allBuildings;
    public float moveSpeed;

    [SerializeField] GameObject UI_GameOver;
    [SerializeField] GameObject UI_Finish;
    // Start is called before the first frame update
    void Start()
    {
        allBuildings.velocity = Vector2.left * moveSpeed;
        UI_GameOver.SetActive(false);
        UI_Finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed == 0f)
        {
            allBuildings.velocity = Vector2.zero;
        }
        Restart();
        /*
        Timer += Time.deltaTime;
        if (Timer >= setTime)
        {
            Timer = 0f;
            SetBuilding();
        }*/
    }
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    /* 随机生成地图版本
    void SetBuilding()
    { 
        GameObject t_building1 = Instantiate()
    }
    */
}
