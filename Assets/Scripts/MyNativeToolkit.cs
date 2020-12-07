using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNativeToolkit : MonoBehaviour
{
    public GameObject m_BottomMenu, m_TopMenu;

    public void Share()
    {
        new NativeShare().SetTitle("Planets AR").SetText("\"Planets AR - A Guide to our Solar System 🚀 \"\n\n• Bring Planets to Life via Augmented Reality (AR).\n• View them in your room or see them in the night sky via 3D mode.\n• Works even at night, in dark rooms!!\n• An immersive AR experience to help the students learn faster!\n• Highly detailed and accurate 3D models sourced from NASA for both students and educators of all ages and more!!\n\nhttps://play.google.com/store/apps/details?id=com.AgrMayank.PlanetsAR").Share();
    }

    public void CaptureNativeScreenshot()
    {
        StartCoroutine(CaptureCameraImage());
    }

    IEnumerator CaptureCameraImage()
    {
        m_BottomMenu.SetActive(false);
        m_TopMenu.SetActive(false);

        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        // do something with texture
        NativeGallery.SaveImageToGallery(texture, "Planets AR", "Planets AR_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss"));

        // cleanup
        Object.Destroy(texture);

        m_BottomMenu.SetActive(true);
        m_TopMenu.SetActive(true);
    }
}
