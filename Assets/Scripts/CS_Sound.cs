using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CS_Sound : MonoBehaviour
{
    public int myMovingType; // 0向上 1不变 2向下
    public bool canMove;
    private bool timerOn;


    [SerializeField] AudioClip[] myAudioClip;
    public AudioSource myAudioSource1;
    public AudioSource myAudioSource2;

    private int last = 0;
    private int repeatTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //加一个canMove计时器
        if (!timerOn)
        {
            StartCoroutine(MyRandom());
            timerOn = true;
        }
    }

    private IEnumerator MyRandom()
    {
        myMovingType = Random.Range(0, 2);
        if (myMovingType == last)
        {
            repeatTime++;
            if (repeatTime >= 2)
                myMovingType = (myMovingType + 1) % 2;
        }
        else {
            repeatTime = 0;
        }
        last = myMovingType;
        Debug.Log(myMovingType);
        myAudioSource1.clip = myAudioClip[myMovingType];
        myAudioSource1.Play();
        canMove = true;
        yield return new WaitForSeconds(2);
        timerOn = false;
        canMove = false;
    }
}
