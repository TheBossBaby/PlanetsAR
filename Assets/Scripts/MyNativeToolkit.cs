using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNativeToolkit : MonoBehaviour
{
    public Text console;

    void Start()
    {
    }

    public void Share()
    {
        new NativeShare().SetTitle("Planets AR").SetText("\"Planets AR - A Guide to our Solar System 🚀 \"\n\nBring Planets to Life via Augmented Reality (AR). Let's go 🚀\n\nhttps://play.google.com/store/apps/details?id=com.AgrMayank.PlanetsAR").Share();
    }

    public void CaptureNativeScreenshot()
    {
        StartCoroutine(CaptureCameraImage());
    }

    IEnumerator CaptureCameraImage()
    {
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        // do something with texture
        NativeGallery.SaveImageToGallery(texture, "Planets AR", "Planets AR_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss"));

        // cleanup
        Object.Destroy(texture);
    }
}
