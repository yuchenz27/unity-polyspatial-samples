# visionOS_Unity_ImmersiveApp

This repository explores how to implement visionOS basic features for the immersive mode.

## Simple Spatial Gesture Scene

This scene allows manipulation of cubes through both indirect gaze pinch and direct pinch in the shared space mode. 

In this scene, we can manipulate the cubes via both indirect gaze pinch gesture and direct pinch. See script [SharedSpaceInputManager](./Assets/!/Scripts/SharedSpaceInputManager.cs) for implementation.

<p align="center">
  <img src="https://github.com/yuchenz27/visionOS_Unity_SharedSpaceApp/assets/44870300/46b354ce-3631-403f-9a63-c0a81a9f1c4b" alt="ezgif-5-ed74bc79fb" style="margin-right: 10px;"/>
  <img src="https://github.com/yuchenz27/visionOS_Unity_SharedSpaceApp/assets/44870300/ab0c3292-482e-47a2-87e9-d664b7c49337" alt="ezgif-1-590094f8b5"/>
</p>

Use `VisionOSHoeverEffect` and `VisionOSGroundingShadow` to add hover effects and grouding shadows to the cubes.

## Simple Immersive Space Scene

This scene is the minimal setup for an immersive space.

<img width="1208" alt="image" src="https://github.com/yuchenz27/visionOS_Unity_ImmersiveApp/assets/44870300/e3642a08-8ce1-404e-a4ab-1fb4661d32ed">

A floating cube staying fixed in the physical environment.

![ezgif-1-79796de538](https://github.com/yuchenz27/visionOS_Unity_ImmersiveApp/assets/44870300/a9e0bd34-a44d-4de4-8b08-96a01c076b58)
