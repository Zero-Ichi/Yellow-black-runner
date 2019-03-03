using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    protected float gameSpeed = 15;

    protected GameObject playerGo;
    protected PlayerController playerController;

    private void Awake()
    {
        playerGo = GameObject.Find("Player");
        if (playerGo != null)
        {
            playerController = playerGo.GetComponent<PlayerController>();
        }
        else
        {
            Debug.Log("<color=Red>Aucun Player n'a pu être trouver dans la scene</color>");
            Debug.Break();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopGame()
    {
        //Pas fou mais fait le taff pour le moment
        Time.timeScale = 0;
    }

    public float GetSpeed()
    {
        return gameSpeed;
    }

    public void SlowDown(float speedDivider, float slowdownTime)
    {
        if (playerController.IsHurt)
        {
            playerController.Dead();
        }
        else
        {
            float MaxSpeedOrigin = gameSpeed;
            gameSpeed /= speedDivider;
            playerController.Hurt();
            //Lance une fonction coroutine
            StartCoroutine(RecoverySpeed(slowdownTime, MaxSpeedOrigin));
            Debug.Log("Aïe !! je vais a : " + gameSpeed + " au lieux de " + MaxSpeedOrigin);
        }
    }
    IEnumerator RecoverySpeed(float slowdownTime, float MaxSpeedOrigin)
    {
        //Attends le nombre de seconde passer en paramètre 
        yield return new WaitForSeconds(slowdownTime);
        gameSpeed = MaxSpeedOrigin;
        playerController.Hurt();
        Debug.Log("Speed " + gameSpeed);
    }


}
