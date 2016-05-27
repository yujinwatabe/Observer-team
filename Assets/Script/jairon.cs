using UnityEngine;
using System.Collections;
/// <summary>
///                         cv.若本
/// 『長い間酷使され続けたjairon君だよっ。
/// 　jairon君はスマホのジャイロセンサーの数値を読み取ってるのです～。
/// 　今回は監視カメラの角度の限界を設定しようと試みているのだ☆』
/// </summary>

public class jairon : MonoBehaviour {
    Camerakirikae camerakirikae;
    private GUIStyle style;
    public Vector3 genkai1;//ここ以上   の範囲で首の周りの限界を設定できる。(試作)
    public Vector3 genkai2;//ここ以下   すべて0の場合首の回りの限界は無し（プレイヤー用のカメラなど）になる。
    Quaternion gyro;
    Vector3 gyrosan;
    // Use this for initialization
    void Start () {
        //camera = gameObject;
		Input.gyro.enabled = true;//ジャイロセンサーをオォンにする。デフォルトでオフになっている！ナムサン！
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);//最初の向きを基準にするっ・・！！！なんて説明し辛いんだっ・・・！！！！
        style = new GUIStyle();
        style.fontSize = 30;
    }
	
	// Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("RigidBodyFPSController");
        camerakirikae = obj.GetComponent<Camerakirikae>();
        if (Input.gyro.enabled)
        {
            gyro = Input.gyro.attitude;//やわらかスマホの傾きをよみとる
            //gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));//スマホの向きを縦持ちに整える
            gyrosan = gyro.eulerAngles;
            //ここからカメラの角度の限界を設定している。(試作）
            if ((gyro.w < genkai1.x)&&(genkai1.x != 0))
            {
                gyro.w = genkai1.x;
            }
            if ((gyro.w > genkai2.x) && (genkai2.x != 0))
            {
                gyro.w = genkai2.x;
            }
            if ((gyro.x < genkai1.y) && (genkai1.y != 0))
            {
                gyro.x = genkai1.y;
            }
            if ((gyro.x> genkai2.y)&&(genkai2.y!= 0))
            {
                gyro.x = genkai2.y;
            }
            //ここまでカメラの角度の限界を設定している。
            gameObject.transform.localRotation =gyro;//カメラくんをスマホの向きに向かせる
        }
        
        //camera.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
        if (Screen.orientation == ScreenOrientation.Portrait)
            {
            //縦持ち
                camerakirikae.Playermode = true;
            }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {
            //横持ち(左傾け&右傾け)
                camerakirikae.Playermode = false;
            }

    }
    void OnGUI()
    {
        if (SystemInfo.supportsGyroscope)
        {
            //角度についての情報を表示（デバッグ的なアレ）
            Input.gyro.enabled = true;
            if (Input.gyro.enabled)
            {
                GUI.Label(new Rect(0, 15, 200, 100), gyro.ToString(), style);
            }
            else
            {
                GUI.Label(new Rect(0, 15, 200, 100), "Gyro Not Enabled.", style);
            }
        }
        else
        {
            GUI.Label(new Rect(0, 15, 200, 100), "Gyro Not Support.", style);
        }
    }
}

