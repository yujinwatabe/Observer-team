using UnityEngine;
using System.Collections;

public class Kenki : MonoBehaviour {
    find Find;
    MoveToTarget movetotarget;
    GameObject enemy;
    bool captureMode;
    float time;
    public float tuisekizikan = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        GameObject obj = transform.FindChild("find").gameObject;
        Find =obj.GetComponent<find>();
        if (Find.Findbool)
        {
            captureMode = true;
            Trackingmode();
        }
        else
        {
            captureMode = false;
            searchmode();
            
        }
	}
    void searchmode()
    {
        time = 0;
        //非発見状態
        gameObject.GetComponent<MoveToTarget>().enabled = false;
        //巡回のスクリプトをオォン！にする。
    }
    void Trackingmode()
    {
        //発見状態
        gameObject.GetComponent<MoveToTarget>().enabled = true;
        //巡回のスクリプトをｵﾌｯにする。
        time += Time.deltaTime;
        print(time);
        if (Find.Findbool)
        {
            time = 0;
        }
        if (time >= tuisekizikan)
        {
            //指定時間見失い続けたときの処理
            captureMode = false;
            Find.sikakuhantei = false;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (captureMode)
        {
            if (col.gameObject.tag == "Player")
            {
                //捕まった場合

                //プレイヤーにダメージのスクリプト（ライフを設定してないのでまだ）
                captureMode = false;
                Find.sikakuhantei = false;
                Invoke("sikaku_sessyoku_hukkatu", 2);//2秒後視覚と接触の判定が復活する。
            }
        }
    }
    void sikaku_sessyoku_hukkatu()
    {
        //視覚判定・接触判定を復活させる
        captureMode = true;
        Find.sikakuhantei = true;

    }
}
