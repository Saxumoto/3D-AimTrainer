# 🎯 3D AR Aim Trainer

A mobile Augmented Reality (AR) aim training application built with Unity and ARCore. This project transforms the user's physical environment into a spatial shooting gallery, testing reflexes and accuracy within a strict 60-second time limit.

## ✨ Features

* **Spatial Tracking:** Utilizes AR Foundation and ARCore to map the physical environment and anchor 3D targets in real-world space.
* **Dynamic Target Spawning:** Targets spawn at randomized X/Y offsets exactly 2.5 meters in front of the device's camera.
* **Raycast Hit Detection:** Translates 2D screen taps into 3D physics raycasts to accurately detect and destroy targets.
* **Session Management:** Features a complete game loop (Menu -> AR Game -> Game Over) with a strict 60-second countdown timer.
* **Persistent Memory:** Utilizes Unity's `PlayerPrefs` to save the final score locally and pass data between scenes.
* **Responsive UI:** Device-agnostic user interface designed to scale perfectly on high-resolution Android displays.

## 🛠️ Tech Stack

* **Game Engine:** Unity 3D
* **Language:** C#
* **AR Frameworks:** AR Foundation, Google ARCore
* **Platform:** Android (APK)

## 🚀 How to Play (Installation)

Since this is an AR application, it must be run on an ARCore-supported Android device.

1. Download the latest `.apk` release (Link to your Google Drive or Releases page here).
2. Transfer the `.apk` file to your Android device.
3. Open the file on your device to install it. *(Note: You may need to allow "Install from Unknown Sources" in your Android settings).*
4. Launch the app, point your camera at an open, well-lit space, and tap "Start Game".

## 📂 Project Structure

* `Scripts/ARTargetManager.cs`: Core gameplay loop, timer execution, target instantiation, and raycast hit logic.
* `Scripts/MenuManager.cs`: Main menu scene routing and initialization.
* `Scripts/EndManager.cs`: Game over state handling and localized memory retrieval.

---
**Developer:** Chelsea Mae Julaily Banlasan (@Saxumoto)  
**Institution:** Holy Cross of Davao College (BSIT)