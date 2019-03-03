using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {
    protected GameManager GameManager { get; set; }

    protected virtual void Awake()
    {
        GameObject tmpManager = GameObject.Find("GameManager");
        if (tmpManager != null)
        {
            GameManager = tmpManager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("<color=Red>Aucun GameManager n'a pu être trouver dans la scene</color>");
            Debug.Break();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
