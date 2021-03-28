using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphTerrain : MonoBehaviour
{
    public KeyCode startMorphKey = KeyCode.Space;
    public float animTime = 2;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(startMorphKey))
        {
            //Stop any coroutine on going to avoid creating a mess if spamming the button
            StopAllCoroutines();
            //Start the anim
            StartCoroutine(Morph());
        }
    }

    IEnumerator Morph()
    {
        float t = 0;

        //Scale down loop
        while(t<1)
        {
            t += Time.deltaTime / animTime * 2;

            yield return null;
        }

        //Reset the progress variable
        t = 0;

        //Scale Up loop
        while (t < 1)
        {
            t += Time.deltaTime / animTime * 2;

            yield return null;
        }
    }
}
