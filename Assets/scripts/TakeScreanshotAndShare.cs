using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TakeScreanshotAndShare : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;

    public void takeScreenshoot()
    {
        if (panelMenu != null)
        {
            panelMenu.SetActive(false);
            StartCoroutine(Screenshot());
            panelMenu.SetActive(true);
        }
    }
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();

        GameManager.Instance.TakeScreenShot();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Estoy probando mi AR")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
        GameManager.Instance.EndTakeScreenshot();
    }
}
