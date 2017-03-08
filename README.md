# BowieCode
Personal Code, Snippet & Reference Library for Unity 3D

![david-bowie-2015-04-24t16-49-11-1](https://cloud.githubusercontent.com/assets/166915/22928405/3921cc9a-f2ae-11e6-8553-5deb69ab7073.png)

## Features

### Components

- `BindToCamera` will position an transform a parent camera's near or far.
- `CameraFulstrumGizmo` alway shows the camera's fulstrum in the scene view even if the camera is not selected.
- `DestroyAllChildren` destroys the gameobject's children. Useful for dynamic content. Can be undone when in editor mode.
- `DistributeChildren` distributes it's children between two points. The two points can be manipulated in the scene view.
- `DropdownCameraSelector`binds a list of cameras to a UI.Dropdown
- `GridRepeater` clones prefabs into a grid
- `InstantiateAtTag` creates instances of a prefab in the scene at the position of game objects with a certain tag. When used in editor it can be undone. Instances can be parented with the game object at the tag, a container or the root of the scene. 
- `Motion` applies trig based motions to selectable variables of the transform component.
- `MotionCloner` applies a master transforms position, rotation and scale to components transform. Provides options for using local or world space, and retaining offsets.
- `MouseHider` hides the mouse after a set number of seconds.
- `PivotGizmo3D` draws customisable axises like the move tool when the object is not selected.
- `SceneRecorder` frame capture and video creation on OSX using ffmpeg installed by Homebrew.
- `Singleton` inherit from to make a singleton. _Umm... really not sure about this_.
- `Spawner` instantiates prefabs in a random location within a predefined shape. It can set to do this every frame and spawn multiples.
- `TextGizo` always displays text in the scene view.


### Attributes

- `TagAttribute` and `TagDrawer` provides range tag selection for `string`. See: [TagAttributeExample.](https://github.com/rc1/BowieCode/blob/master/Examples/TagAttributeExample.cs)
- `MinMaxSliderAttribute` and `MinMaxSliderDrawer` provides range sliders for `Vector2`. See: [MinMaxSliderExample](https://github.com/rc1/BowieCode/blob/master/Examples/MinMaxSliderExample.cs)
- `InspectorButtonAttribute` and `InspectorButtonAttribute` creates a button in the editor for `InspectorButton`. See: [InspectorButtonExample](https://github.com/rc1/BowieCode/blob/master/Examples/InspectorButtonExample.cs)

### Datatypes

- `Cycle` wraps a `Enumerable` into a container with a `Next` method.
- `InspectorButton` creates a button in the inspector when paired with an `InspectorButtonAttribute`. See: [InspectorButtonExample](https://github.com/rc1/BowieCode/blob/master/Examples/InspectorExample.cs)
- `ParentingMode` helps define where instanced GameObject should be placed.
- `ShapedRange` evaluates to a constant value, a value between two numbers or a value from an Animation curve. These options can be selected in the editor. It's inspired by Unity's particle system.

### Utils

- `BitmaskHelper` provides `IsSet`, `Set`, `Unset` enum helper.
- `BowieMath` 
	- `CompareVectors` compares if Vector are close to equal.
	- `MapIntervalF` maps an input float from one range to another.
	- `SinF`is a sine wave generator with an amplitude, and frequency defined by `cyclesPerSecond`
- `BowieTime` fractional day & time and format helpers.
- Editor Only
	- `ReorderableListUtil` wrapper to `Create` and `Draw` a reorderable list with the correct spacing. See example for usage. See: [ReorderableListExample](https://github.com/rc1/BowieCode/blob/master/Examples/ReorderableListExample.cs) & [ReorderableListExampleEditor](https://github.com/rc1/BowieCode/blob/master/Examples/Editor/ReorderableListExampleEditor.cs)


