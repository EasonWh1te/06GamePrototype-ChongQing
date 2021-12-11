using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CS_Player : MonoBehaviour
{

    [SerializeField] float mySpeed;
    [SerializeField] Rigidbody2D myRigidBody;
    [SerializeField] GameObject mySound;
    [SerializeField] GameObject myGameManager;

    [SerializeField] GameObject[] myPosision;

    [SerializeField] GameObject UI_GameOver;
    [SerializeField] GameObject UI_Finish;


    [SerializeField] Text UI_HP;

    [SerializeField] Animator myAni;


    private int nowPosition = 1;
    public int myHP = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UI_HP.text = "ÌýÉùÒô °´¿Õ¸ñ£¡HP:" + myHP.ToString();
    }

    

    void Move()
    {
        //myRigidBody.velocity = Vector2.right * mySpeed;
        if (Input.GetKeyDown(KeyCode.Space) && mySound.transform.GetComponent<CS_Sound>().canMove)
        {
            mySound.transform.GetComponent<CS_Sound>().canMove = false;
            switch (mySound.transform.GetComponent<CS_Sound>().myMovingType)
            {
                case 0:
                    nowPosition--;
                    if (nowPosition < 0) nowPosition = 0;
                    Debug.Log("nowPosition" + nowPosition);
                    break;
                case 1:
                    nowPosition++;
                    if (nowPosition > 2) nowPosition = 2;
                    Debug.Log("nowPosition" + nowPosition);
                    break;
            }
        }
        Vector2 t_direction = myPosision[nowPosition].transform.position - this.transform.position;
        t_direction = t_direction.normalized;
        myRigidBody.velocity = t_direction * mySpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<CS_Building>() == true)
        {
            myHP--;
            Debug.Log("HP:" + myHP);
            GameOverCheck();
            StartCoroutine(ResetPosition());
        }
        if (collision.transform.GetComponent<CS_Finish>() == true)
        {
            UI_Finish.SetActive(true);
            myGameManager.GetComponent<CS_SceneManager>().moveSpeed = 0;
            
        }
    }

    void GameOverCheck()
    {
        if (myHP <= 0)
        {
            UI_GameOver.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator ResetPosition()
    {

        yield return new WaitForSeconds(1);
        this.transform.position = myPosision[1].transform.position;
        nowPosition = 1;
        myAni.SetBool("Reset", true);
        StartCoroutine(Flashing());
    }
    IEnumerator Flashing()
    {
        yield return new WaitForSeconds(1);
        myAni.SetBool("Reset", false);
    }
}
