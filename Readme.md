# Juicy 2D Shooter Game #

A Simple unity project 2D Project with Cinemachine, New Input System and URP
Game features with 
- camera shake
- different vfx effects - inprogress
- foot steps
- bullet cell drops - planned
- lighting
- muzzle flashes
- dotween
- blood splatters using particle system - planned
- postprocessing, bloom 
- shadows etc.
and all juicy stuff.

Interesting Stuffs.

- Shader Graph
- Procedural Dungeon - planned
- Save/Load System - planned

<br>
Udemy Course:
https://www.udemy.com/course/unity-2020-urp-how-to-make-a-2d-roguelike-shooter/


Create New Player:
1. Create a prefab variant from the Player
2. Update below references:
	a. OnDie Event in Player (Script) add RestartButton Gameobject setActive
	b. UI Health (Player (Script))- add reference for UIController
	c. UI Ammo (Player Weapon (Script)) - add reference for UI Controller
