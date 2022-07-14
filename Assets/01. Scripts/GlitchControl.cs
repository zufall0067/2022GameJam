using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchControl : MonoBehaviour
{
    DigitalGlitch digitalGlitch;
    // Start is called before the first frame update
    void Start()
    {
        digitalGlitch = FindObjectOfType<DigitalGlitch>();
        StartCoroutine(Control(digitalGlitch._intensity));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Control(float val)
    {
        while (true)
        {
            val += Time.deltaTime * 1 / 2.5f;
            if (val >= 1)
            {
                break;
            }
        }

        while (true)
        {
            val -= Time.deltaTime * 1 / 2.5f;
            if (val <= 0)
            {
                yield return null;
                break;
            }
        }
    }
}
