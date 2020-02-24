using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChange : MonoBehaviour
{
    float random_shade;
    Color autumn_color;
    float elapsedTime = 0;
    float elapsedTime2 = 0;
    float elapsedTime3 = 0;
    public GameObject root;
    float initialColor = 0;
    float blue;
    Color leafColor;

    void Start()
    {
        random_shade = Random.Range(20, 200) / 255f;

        initialColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color").g;
        leafColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        blue = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color").b;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        elapsedTime2 += Time.deltaTime;
        elapsedTime3 += Time.deltaTime;

        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, initialColor, 0, 1));

        if (elapsedTime > (root.GetComponent<RecursiveInstantiator>().recursion_iterations + 1) * 5)
        {

            if (initialColor >= random_shade && elapsedTime2 > 0.05)
            {
                initialColor -= 1f / 255f;
                elapsedTime2 = 0;
                Debug.Log(leafColor.b);

               /* if (leafColor.r < 1)
                {
                    leafColor.r += 1f / 255f;
                }
                if (leafColor.b > 0)
                {
                    leafColor.b -= 1f / 255f;
                    blue -= 1f / 255f;
                }**/
            } else
            {
                if (initialColor <= random_shade && initialColor < 100f/255f)
                {
                    this.gameObject.transform.position -= new Vector3(0, 50 * Time.deltaTime, 0);
                }
                /*if (elapsedTime2 > 0.05)
                {
                    elapsedTime2 = 0;

                    if (leafColor.r < 1)
                    {
                        leafColor.r += 1f / 255f;
                    }
                    if (leafColor.b > 0)
                    {
                        leafColor.b -= 1f / 255f;
                        blue -= 1f / 255f;
                    }
                }*/

            }
        }
    }
}
