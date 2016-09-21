# BowieCode
Code Library for Unity 3D

## Features

### Singleton

Inherit from `Singleton` to make the sub class a singleton.

### Cycle

Wraps a `Enumerable` into a container with a `Next` method.

### BitmaskHelper

`IsSet`, `Set`, `Unset` enum helper.

### BowieMath

- `CompareVectors` compares if Vector are close to equal.
- `MapIntervalF` maps an input float from one range to another.
- `SinF`is a sine wave generator with an amplitude, and frequency defined by `cyclesPerSecond`

### Components

- `BindToCamera` will position an transform a parent camera's near or far/
- `CameraFulstrumGizmo` alway shows the camera's fulstrum in the scene view even if the camera is not selected.
- `MotionCloner` applies a master transforms position, rotation and scale to components transform. Provides options for using local or world space, and retaining offsets.
- `MouseHider` hides the mouse after a set number of seconds.
- `SinMotion` applies sine based motions to selectable varibles of the transform component.
- `TextGizo` always displays text in the scene view.

### EditorUtils

- `CreateReorderableList` helps to draw a reorderable list with the correct spacing. See example for usage.
- `MinMaxSliderAttribute` and `MinMaxSliderDrawer` provide range sliders for `Vector2`s.
