using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerSave : GenericSave
{
    [JsonProperty]
    private string lastVersionPlayed = "";

    [JsonIgnore]
    public string LastVersionPlayed
    {
        get { return lastVersionPlayed; }
        set
        {
            lastVersionPlayed = value;
            SaveSystem.Instance.Flag(this);
        }
    }

    [JsonProperty]
    private string deviceID;

    public string GetDeviceID()
    {
        if (!HasPlayerID())
        {
            deviceID = SystemInfo.deviceUniqueIdentifier;
        }
        
        Debug.Log("deviceId: " + deviceID);

        return deviceID;
    }

    public bool HasPlayerID()
    {
        return !string.IsNullOrEmpty(deviceID);
    }
    
    [JsonProperty]
    private string uniqueID;
    
    [JsonIgnore]
    public string UniqueID
    {
        get
        {
            if (string.IsNullOrEmpty(uniqueID))
            {
                uniqueID = Guid.NewGuid().ToString();
            }
            return uniqueID;
        }
        set
        {
            uniqueID = value;
            SaveSystem.Instance.Flag(this);
        }
    }
}

public enum TutorialType
{
    None = 0,
    Intro = 1,
    Discard = 2,
    RotateHorizontal = 3,
    RotateVertical = 4
}

public enum PatternColorMode
{
    Bright = 0,
    Vibrant = 1,
    Colorblind = 2
}

public enum ThemeMode
{
    Night = 0,
    Snow = 1
}

[Serializable]
public struct XPLevel
{
    public int Level;
    public int StarsRequired;
    public int StarsToCollect;
}

// To make the google-services.json config values accessible to Firebase SDKs, you need the Google services Gradle plugin.
//
//
//     Kotlin DSL (build.gradle.kts)
//
// Groovy (build.gradle)
// Add the plugin as a dependency to your project-level build.gradle file:
//
// Root-level (project-level) Gradle file (<project>/build.gradle):
// plugins {
//     // ...
//
//     // Add the dependency for the Google services Gradle plugin
//     id 'com.google.gms.google-services' version '4.4.0' apply false
//
// }
// Then, in your module (app-level) build.gradle file, add both the google-services plugin and any Firebase SDKs that you want to use in your app:
//
// Module (app-level) Gradle file (<project>/<app-module>/build.gradle):
// plugins {
//     id 'com.android.application'
//
//     // Add the Google services Gradle plugin
//     id 'com.google.gms.google-services'
//
//         ...
// }
//
// dependencies {
//     // Import the Firebase BoM
//     implementation platform('com.google.firebase:firebase-bom:32.7.0')
//
//
//     // TODO: Add the dependencies for Firebase products you want to use
//     // When using the BoM, don't specify versions in Firebase dependencies
//     implementation 'com.google.firebase:firebase-analytics'
//
//
//     // Add the dependencies for any other desired Firebase products
//     // https://firebase.google.com/docs/android/setup#available-libraries
// }
// By using the Firebase Android BoM, your app will always use compatible Firebase library versions. Learn more
// After adding the plugin and the desired SDKs, sync your Android project with Gradle files.