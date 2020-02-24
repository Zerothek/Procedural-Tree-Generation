using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reveal : MonoBehaviour
{
    float scale_fraction = 0, final_destination;
    Vector3 initial_position;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        final_destination = this.transform.position.y + this.transform.localScale.y;
        initial_position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        scale_fraction = elapsedTime / 5;


        if (elapsedTime > 5)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            //this.transform.localScale = new Vector3(scale_fraction * final_scale, scale_fraction * final_scale, scale_fraction * final_scale);
            this.transform.position = initial_position + this.transform.up * scale_fraction * this.transform.localScale.y;
        }

    }
}
