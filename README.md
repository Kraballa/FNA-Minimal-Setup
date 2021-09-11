# FNA Minimal Setup

This is a collection of classes that aim to make it as easy as possible to start using FNA. It includes methods for drawing primitives, loading and rendering textures from file paths as well as keyboard and mouse input. It also features a simple persistence layer, allowing you to serialize objects to XML or binary.

I use these in all my projects.

# Setup (FNA)
1. download this project as .zip
2. copy all files (minus README.md and .gitignore) into your FNA project
3. Refactor the namespace to the one you're using
4. use `Controller.cs` as your main Game class.

# Details:

## Controller.cs
Implements `Game.cs` and provides an example on how to use the classes provided. 

## Calc.cs
Features a broad range of more or less useful functions that find its use in other parts of the repository, namely in rendering primitives. Also contains some basic extension functions for `Vector2` and `Point` to bring them up to par with MonoGame

## Graphic.cs
Wrapper around the `Texture2D` class. Make dealing with textures much easier and provide many useful functions for instantiating and rendering them.

## Render.cs
Main rendering class. Implements primitive rendering and controls the SpriteBatch instance. Uses `Graphic.cs` and `Calc.cs` to construct, rectangles, circles and other useful shapes.
Also has fun functionality for rendering basic graphs or even splines!

## MInput.cs, CInput.cs and KInput.cs
Wrapper around the `KeyboardState`, `GamePadState` and `MouseState` structs. Basic key checking methods as well as some utility.
There are plans for an improved VirtualInput system that can abstract over multiple keys for easy support of multiple input types.

## Camera.cs
A Wrapper around a 3x3 Matrix. This transformation matrix is intended to transform the screen through translation, rotation and scale.
For the actual rendering process it gets multiplied by the `Controller.ScreenMatrix` which can act as a global scale.
You don't need to touch the camera and can remove it outright if you don't want to use it, but occasionally for translation it is very useful (i.e. border around your game without having to displace everything by 5 pixels).
By default the camera is centered around the top left corner. To center it, set its position to the screen center and run `Camera.CenterOrigin()`

## Persistence.cs
Basic wrapper around `XmlSerializer` and `BinarySerializer` and saving and loading them to disk using `File.IO`. This is very basic and should only be used for savedata. Rework pending.

# Credits
This repo is partly based on the work of Maddy Thorson and the (formerly) open source MonoGame game engine `Monocle`. Mainly `Persistence.cs` (`SaveLoad.cs` in Monocle), `Graphic.cs` (`MTexture.cs` in Monocle), `Camera.cs`, `Calc.cs` and `Render.cs` were taken from Monocle and edited wherever it was necessary to make them work standalone. `Controller.cs`, `KInput.cs` and `MInput.cs` were written by me.

Monocle, and this project, are licensed under the MIT license. Because the monocle repository has been privated I don't have access to the original license.
