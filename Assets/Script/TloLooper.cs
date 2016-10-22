using UnityEngine;
using System.Collections;

public class TloLooper : MonoBehaviour
{
    int panels = 9;
    float random;
    int type = 0;
    bool para = false;
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "miodek")
        {
            Vector3 poss = collider.transform.position;
            poss.x += 33;
            random=Random.Range(-0.5f, 0.5f);
            Debug.Log(random + " " + poss.y + " " + collider.name);
            if (poss.y > 3.8)
            {
                poss.y -= 0.3f;
                type = 0;
            }
            else if (poss.y < 2.4)
            {
                poss.y += 0.3f;
                type = 1;
            }

            else
            {
                
                poss.y += random;
                type = 2;
            }
            collider.transform.position = poss;

        }else if (collider.gameObject.tag == "miodekdol")
            {
            Vector3 poss = collider.transform.position;
            poss.x += 33;
            if (type == 0) poss.y -= 0.3f;
            else if (type == 1) poss.y += 0.3f;
            else poss.y += random;
            collider.transform.position = poss;
        }
        else
        {
            float widthofBGObject = ((BoxCollider2D)collider).size.x;
            Vector3 pos = collider.transform.position;
            pos.x += widthofBGObject * panels - widthofBGObject / 2 - 1;
            collider.transform.position = pos;
        }
    }
}
