using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Send : MonoBehaviour
{
    public Texture MyTexture;
    public Texture2D receivedTexture;
    public byte[] receivedBytes;
    public byte[] N;
    public PhotonView PV;
    public Texture2D tex2D;

    public RenderTexture rt;
    public Camera cam;
    public GameObject plane;
    private float timer;
    public bool Start_Sending = true;

    public float delaytime = 0.25f;

    void Start()
    {
        MyTexture = null;
        PV = GetComponent<PhotonView>();
        
    }

    static public Texture2D GetRTPixels(RenderTexture rt)
    {
        // Remember currently active render texture
        RenderTexture currentActiveRT = RenderTexture.active;

        // Set the supplied RenderTexture as the active one
        RenderTexture.active = rt;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        // Restorie previously active render texture
        RenderTexture.active = currentActiveRT;
        return tex;
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.S)){
            Start_Sending = true;
        }
        timer += Time.deltaTime;
        PV = GetComponent<PhotonView>();

        if (PhotonNetwork.IsMasterClient && timer > delaytime && Start_Sending)
        {
            timer = 0;
            // Render to RenderTexture
            cam.targetTexture = rt;
            cam.Render();
            //MyTexture = GetRTPixels(rt);
            // MyTexture = GetRTPixels(rt);
            //MyTexture = GetComponent<Renderer>().material.mainTexture;
            //RenderTexture.active = myRenderTexture;
            RenderTexture.active = rt;
            Texture2D tex = new Texture2D(rt.width, rt.height);
            tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
            //tex2D = (Texture2D)tex;
            //tex2D = new Texture2D(tex2D.width, tex2D.height);
            //StartCoroutine(GetRenderTexturePixel(tex));
            tex.Apply();
            N = tex.EncodeToPNG();
            //plane.GetComponent<Renderer>().material.mainTexture = tex;
            
            //StartCoroutine(GetRenderTexturePixel());

            
            PV.RPC("ReceiveWebcamPNG", RpcTarget.Others, N);
            return;
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            /* if (MyTexture != null)
            {
                tex2D = new Texture2D(MyTexture.width, MyTexture.height);
                tex2D.LoadImage(N);
                plane.GetComponent<Renderer>().material.mainTexture = tex2D;
            }*/
        }

    }

    /*IEnumerator GetRenderTexturePixel(Texture2D tex)
    {
        Texture2D tempTex = new Texture2D(tex.width, tex.height);
        yield return new WaitForEndOfFrame();
        tempTex.ReadPixels(new Rect(0, 0, 400, 300), 0, 0);
        tempTex.Apply();
        N = tempTex.EncodeToPNG();
    } 
    IEnumerator GetRenderTexturePixel()
    {
        yield return new WaitForEndOfFrame();
        // Render to RenderTexture
        cam.targetTexture = rt;
        cam.Render();
        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();
        N = tex.EncodeToPNG();
        plane.GetComponent<Renderer>().material.mainTexture = tex;
    }
*/
    [PunRPC]
    public void ReceiveWebcamPNG(byte[] receivedByte)
    {
        receivedTexture = null;
        receivedTexture = new Texture2D(1, 1);
        receivedTexture.LoadImage(receivedByte);
        plane.GetComponent<Renderer>().material.mainTexture = receivedTexture;
    }
}