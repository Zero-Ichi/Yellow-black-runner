using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilling : MonoBehaviour
{

    private List<Transform> sprites;
    private int indexLeft;
    private int indexRight;
    private float viewZone;

    // Use this for initialization
    void Start()
    {
        this.indexLeft = 0;
        this.sprites = new List<Transform>();
        Transform tmpChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            tmpChild = transform.GetChild(i);
            if (tmpChild.GetComponent<SpriteRenderer>() != null)
            {
                this.sprites.Add(tmpChild);
            }
        }

        this.indexRight = sprites.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        RepeatChild();
    }

    private void RepeatChild()
    {
        //Récupere la zone de vue
        viewZone = (Camera.main.orthographicSize * Screen.width) / Screen.height;
        if (Camera.main.transform.position.x >= (sprites[indexRight].position.x + sprites[indexRight].GetComponent<SpriteRenderer>().bounds.size.x / 2) - viewZone)
        {
            sprites[indexLeft].position = new Vector3(sprites[indexRight].position.x + sprites[indexRight].GetComponent<SpriteRenderer>().bounds.size.x, sprites[indexRight].position.y, sprites[indexRight].position.z);
            indexRight = indexLeft;
            indexLeft++;
            if (indexLeft > sprites.Count - 1)
            {
                indexLeft = 0;
            }
        }

        if (Camera.main.transform.position.x <= (sprites[indexLeft].position.x - sprites[indexLeft].GetComponent<SpriteRenderer>().bounds.size.x / 2) + viewZone)
        {
            sprites[indexRight].position = new Vector3(sprites[indexLeft].position.x - sprites[indexLeft].GetComponent<SpriteRenderer>().bounds.size.x, sprites[indexLeft].position.y, sprites[indexLeft].position.z);
            indexLeft = indexRight;
            indexRight--;
            if (indexRight < 0)
            {
                indexRight = sprites.Count - 1;
            }
        }


    }
}
