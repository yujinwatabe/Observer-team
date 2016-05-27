using UnityEngine;
using System.Collections;
/// <summary>
/// このスクリプトは監視カメラをチェックしたかの判定を行うスクリプトどすえ。
/// 監視カメラに基本的に入れ使うどすえ。
/// obj2にcamerakirikaeのスクリプトの入ったオブジェクト（どうせプレイヤー）を登録するのを忘れないでどすえ。
/// </summary>
public class camerahac : MonoBehaviour {
    GameObject target;
    public Camera activecamera;
    Camerakirikae camerakirikae;
    public float cameracode = 0;
    public GameObject obj2;
    Ray ray;
    void start(){
        
    }
    void Update()
    {
        camerakirikae = obj2.GetComponent<Camerakirikae>();
        if (Input.GetMouseButtonDown(0))
        {
            //監視カメラを起動したかのチェック
            if (camerakirikae.Playermode)
            {
                //メインカメラからのチェック
                ray = camerakirikae.mainCamera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                //監視カメラからのチェック
                ray = camerakirikae.HacCamera.ScreenPointToRay(Input.mousePosition);
            }
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj == gameObject)
                {
                    if (cameracode == 0)
                    {
                        //監視カメラをジャックした場合以下の処理を行う
                        Screen.autorotateToLandscapeRight = true;
                        Screen.autorotateToLandscapeLeft = true;
                        int i = 0;
                        //camerakirikae(監視カメラ情報）のスクリプトに自身がなければ新しく監視カメラを登録する。
                        while (camerakirikae.cameras[i] != null)
                        {
                            if (camerakirikae.cameras[i] == gameObject)
                            {
                                i = -1;
                                break;
                            }
                            i++;
                        }
                        if (i != -1)
                        {
                            camerakirikae.cameras[i] = gameObject;
                        }
                    }
                }
            }
        }
    }
}
