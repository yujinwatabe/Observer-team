using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public GameObject shatta;
    public Text buttontext;
    public Text title;
    public Sprite snaarashi;
    private Color originalColor;
    float a, b;
    float time;
    bool Fadeout = true;
    float z;
    public void Buttonpush()
    {
        if (Fadeout)
        {
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
            StartCoroutine("FadeOut");
            Fadeout = false;
        }


    }
    IEnumerator FadeOut()
    {
        AsyncOperation async = Application.LoadLevelAsync("stage1");//シーンのロード
        async.allowSceneActivation = false;//だがまだシーンの移動はしない
        
        iTween.ScaleTo(gameObject, iTween.Hash("x", Screen.width, "y", Screen.height, "time", 40.0f));
        iTween.MoveTo(gameObject, iTween.Hash("x", Screen.width / 2, "y", Screen.height / 2, "time", 40.0f));
        
        
        yield return new WaitForSeconds(1f);
        Image img = this.GetComponent<Image>();
        img.sprite = snaarashi;
        for (; ; )
        {
            if(z == 180){
                z = 0;
            }
            else
            {
                z = 180;
            }
            
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.0f);
        async.allowSceneActivation = true;
    }
}

