 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setumei : MonoBehaviour {
    public Image setumeiimage;
    public GameObject text;
    public string setuneutext;
    public string setuneutext2;
    public float readtyme = 2f;
    public bool a = true;
    float i = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (a)
            {
                a = false;
                StartCoroutine("setumeikaisi");
            }
        }
    }
    IEnumerator setumeikaisi()
    {
        i = 0;
        setumeiimage.enabled = true;
        text.SetActiveRecursively(true);
        text.GetComponent<Text>().text= setuneutext.ToString();
        yield return new WaitForSeconds(readtyme);
        text.SetActiveRecursively(false);
        setumeiimage.enabled = false;
        if (setuneutext2 != null)
        {
            setumeiimage.enabled = true;
            text.SetActiveRecursively(true);
            text.GetComponent<Text>().text = setuneutext2.ToString();
            yield return new WaitForSeconds(readtyme);
            text.SetActiveRecursively(false);
            setumeiimage.enabled = false;
        }
    }
}
