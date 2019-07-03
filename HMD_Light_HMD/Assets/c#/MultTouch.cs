using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class MultTouch : MonoBehaviour
{

    public PhotonView PV;
    public GameObject particle;
    private bool IsMutitouch = false;

    // Use this for initialization
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            if (IsMutitouch)
            {
                int i = 0;
                //loop over every touch found
                while (i < Input.touchCount)
                {
                    PV.RPC("Touch_pos", RpcTarget.Others, Input.GetTouch(i).position);
                }
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                PV.RPC("Touch_pos", RpcTarget.Others, Input.mousePosition);

            }
        }
        else if (PhotonNetwork.IsMasterClient)
        {

        }
    }

    [PunRPC]
    public void Touch_pos(Vector3 touch_pos)
    {
        var ray = Camera.main.ScreenPointToRay(touch_pos);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
        }
    }

}
