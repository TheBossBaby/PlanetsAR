using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNativeToolkit : MonoBehaviour
{
    public Text console;
    public GameObject[] toToggle;
    static string screenshotPath = " ";

    void Start()
    {
        console.text += "\nLocation enabled: " + NativeToolkit.StartLocation();
        console.text += "\nDevice country: " + NativeToolkit.GetCountryCode();
        console.text += "\nLaunched from notification: " + NativeToolkit.WasLaunchedFromNotification();
    }

    void OnEnable()
    {
        NativeToolkit.OnScreenshotSaved += ScreenshotSaved;
        // NativeToolkit.OnImageSaved += ImageSaved;
        // NativeToolkit.OnImagePicked += ImagePicked;
        // NativeToolkit.OnCameraShotComplete += CameraShotComplete;
        // NativeToolkit.OnContactPicked += ContactPicked;
    }

    void OnDisable()
    {
        NativeToolkit.OnScreenshotSaved -= ScreenshotSaved;
        // NativeToolkit.OnImageSaved -= ImageSaved;
        // NativeToolkit.OnImagePicked -= ImagePicked;
        // NativeToolkit.OnCameraShotComplete -= CameraShotComplete;
        // NativeToolkit.OnContactPicked -= ContactPicked;
    }


    //=============================================================================
    // Button handlers
    //=============================================================================

    public void Share()
    {
        new NativeShare().SetTitle("Planets AR").SetText("*Planets AR - A Guide to our olar System* 🚀\n\nBring Planets to Life via Augmented Reality (AR). Let's go 🚀\n\nhttps://play.google.com/store/apps/details?id=com.AgrMayank.PlanetsAR").Share();
    }

    public void CaptureNativeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("/storage/emulated/0/DCIM/Planets AR/Planets AR");
    }

    public void OnSaveScreenshotPress()
    {
        for (int i = 0; i < toToggle.Length; i++)
        {
            if (toToggle[i].activeSelf)
            {
                toToggle[i].SetActive(false);
            }
            else
            {
                toToggle[i].SetActive(true);
            }
        }

        NativeToolkit.SaveScreenshot("Planets AR", "/storage/emulated/0/DCIM/PlanetsAR", "png");
    }

    // public void OnSaveImagePress()
    // {
    //     NativeToolkit.SaveImage(texture, "MyImage", "png");
    // }

    // public void OnPickImagePress()
    // {
    //     NativeToolkit.PickImage();
    // }

    // public void OnEmailSharePress()
    // {
    //     NativeToolkit.SendEmail("Hello there", "<html><body><b>This is an email sent from my App!</b></body></html>", imagePath, "", "", "");
    // }

    // public void OnCameraPress()
    // {
    //     NativeToolkit.TakeCameraShot();
    // }

    // public void OnPickContactPress()
    // {
    //     NativeToolkit.PickContact();
    // }

    public void OnShowAlertPress()
    {
        NativeToolkit.ShowAlert("Native Toolkit", "This is an alert dialog!", DialogFinished);
    }

    public void OnShowDialogPress()
    {
        NativeToolkit.ShowConfirm("Native Toolkit", "This is a confirm dialog!", DialogFinished);
    }

    public void OnLocalNotificationPress()
    {
        string message = "Bring Planets to Life via Augmented Reality (AR). Let's go 🚀";

        NativeToolkit.ScheduleLocalNotification("Planets AR", message, 0, 180, "notification_sound", true, "ic_planetsar", "ic_planetsar_large");

    }

    public void OnClearNotificationsPress()
    {
        NativeToolkit.ClearAllLocalNotifications();
    }

    // public void OnGetLocationPress()
    // {
    //     console.text += "\nLongitude: " + NativeToolkit.GetLongitude().ToString();
    //     console.text += "\nLatitude: " + NativeToolkit.GetLatitude().ToString();
    // }

    public void OnRateAppPress()
    {
        NativeToolkit.RateApp("Like the app?", "Give us a 5 ⭐ rating and share your valuable feedback with us for more amazing apps!", "Rate Now", "", "No, Thanks!", "", AppRated);
    }

    //=============================================================================
    // Callbacks
    //=============================================================================

    void ScreenshotSaved(string path)
    {
        // screenshotPath = path;
        console.text += "\n" + "Screenshot saved to: " + path;

        for (int i = 0; i < toToggle.Length; i++)
        {
            if (toToggle[i].activeInHierarchy)
            {
                toToggle[i].SetActive(false);
            }
            else
            {
                toToggle[i].SetActive(true);
            }
        }
    }

    // void ImageSaved(string path)
    // {
    //     console.text += "\n" + texture.name + " saved to: " + path;
    // }

    // void ImagePicked(Texture2D img, string path)
    // {
    //     imagePath = path;
    //     console.text += "\nImage picked at: " + imagePath;
    //     Destroy(img);
    // }

    // void CameraShotComplete(Texture2D img, string path)
    // {
    //     imagePath = path;
    //     console.text += "\nCamera shot saved to: " + imagePath;
    //     Destroy(img);
    // }

    void DialogFinished(bool result)
    {
        console.text += "\nDialog returned: " + result;
    }

    void AppRated(string result)
    {
        console.text += "\nRate this app result: " + result;
    }

    // void ContactPicked(string name, string number, string email)
    // {
    //     console.text += "\nContact Details:\nName:" + name + ", number:" + number + ", email:" + email;
    // }
}
