# BowieCode
Personal Code, Snippet & Reference Library for Unity 3D

![david-bowie-2015-04-24t16-49-11-1](https://cloud.githubusercontent.com/assets/166915/22928405/3921cc9a-f2ae-11e6-8553-5deb69ab7073.png)

## Features

### Components

- `BindToCamera` will bind it's transform to parent's camera's near or far. Handy for keeping thing to the front or the back of a camera.
- `CameraFrustumGizmo` always shows the camera's frustum in the scene view. Even when the camera is not selected.
- `CameraFader` fades the camera to a texture. It includes a inspector button to generate a solid color texture.
- `DefaultInstance` Gets/sets a single static `Default` instance. Rather than have singletons, instances can utilize this generic container. For example `DefaultInstance<MyClass>.Set( this )` and `MyClass instance = DefaultInstance<MyClass>.Get()`.
- `DestroyAllChildren` destroys the gameobject's children. Useful for dynamic content. Can be undone when in editor mode.
- `DistributeChildren` distributes it's children between two points. The two points can be manipulated in the scene view.
- `DropdownCameraSelector`binds a list of cameras to a UI.Dropdown.
- `GridRepeater` clones prefabs into a grid.
- `InstantiateAtTag` creates instances of a prefab in the scene at the position of game objects with a certain tag. When used in editor it can be undone. Instances can be parented with the game object at the tag, a container or the root of the scene.
- `Motion` applies trig based motions to selectable variables of the transform component.
- `MotionCloner` applies a master transforms position, rotation and scale to components transform. Provides options for using local or world space, and retaining offsets.
- `MouseHider` hides the mouse after a set number of seconds.
- `PivotGizmo3D` draws customisable axises like the move tool when the object is not selected.
- `SceneRecorder` frame capture and video creation on OSX using ffmpeg installed by Homebrew.
- `Singleton` inherit from to make a singleton. _See `DefaultInstance` for a better system_.
- `Spawner` instantiates prefabs in a random location within a predefined shape. It can set to do this every frame and spawn multiples.
- `TextGizo` always displays text in the scene view

#### Managers

Managers use the `BowieCode.DefaultInstance<T>` system.

- `DebugNotificationManager` displays short notification labels with a severity level of either info, warning or error. They are displayed indefinitely or for a set timespan, and can be updated once displayed.
- `AppManager` includes:
    - hides the mouse if none are detected or after a set period of time,
    - adds a checkbox to run application in the background.

### Attributes

- `SortingLayerAttribute` and `SortingLayerDrawer` provides sorting layer selection for an `int`.
- `TagAttribute` and `TagDrawer` provides range tag selection for a `string`. See: [TagAttributeExample.](https://github.com/rc1/BowieCode/blob/master/Examples/TagAttributeExample.cs).
- `LayerAttribute` and `LayerDrawer` provides layer selection for an `int`.
- `MinMaxSliderAttribute` and `MinMaxSliderDrawer` provides range sliders for `Vector2`. See: [MinMaxSliderExample](https://github.com/rc1/BowieCode/blob/master/Examples/MinMaxSliderExample.cs).
- `InspectorButtonAttribute` and `InspectorButtonAttribute` creates a button in the editor for `InspectorButton`. See: [InspectorButtonExample](https://github.com/rc1/BowieCode/blob/master/Examples/InspectorButtonExample.cs).

### Datatypes

- `Cycle` wraps a `Enumerable` into a container with a `Next` method.

- `InspectorButton` creates a button in the inspector when paired with an `InspectorButtonAttribute`. See: [InspectorButtonExample](https://github.com/rc1/BowieCode/blob/master/Examples/InspectorExample.cs).
    - ![example button](https://user-images.githubusercontent.com/166915/31450955-b79b4d52-aea2-11e7-8f16-b95e99605089.gif)
- `ParentingMode` helps define where instanced GameObject should be placed.
- `ShapedRange` evaluates to a constant value, a value between two numbers or a value from an Animation curve. These options can be selected in the editor. It's inspired by Unity's particle system.

### Utils

- `BitmaskHelper` provides `IsSet`, `Set`, `Unset` for enums which use the `[Flags]` attribute.
- `BowieMath` includes:
	- `CompareVectors` compares if Vector are close to equal,
	- `MapIntervalF` maps an input float from one range to another,
	- `SinF`is a sine wave generator with an amplitude, and frequency defined by `cyclesPerSecond`.
- `BowieTime` fractional day & time and format helpers.
- `BowieExtensions` contains `ForEachWithIndex` for collection enumeration.
- Editor Only:
	- `ReorderableListUtil` wrapper to `Create` and `Draw` a reorderable list with the correct spacing. See example for usage. See: [ReorderableListExample](https://github.com/rc1/BowieCode/blob/master/Examples/ReorderableListExample.cs) & [ReorderableListExampleEditor](https://github.com/rc1/BowieCode/blob/master/Examples/Editor/ReorderableListExampleEditor.cs).
	- `Prefabs` enables a menu items to *Apply* selected prefabs.
