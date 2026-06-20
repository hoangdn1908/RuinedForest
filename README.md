# 🌲 Ruined Forest

> A small 2D platformer adventure built with Unity and C#.

![Unity](https://img.shields.io/badge/Engine-Unity-black?style=for-the-badge\&logo=unity)
![CSharp](https://img.shields.io/badge/Language-C%23-purple?style=for-the-badge\&logo=csharp)
![Status](https://img.shields.io/badge/Status-AlmostDone-success?style=for-the-badge)

---

## 🎮 About The Game

**Ruined Forest** is a small 2D action-platformer project developed as part of my game development learning journey.

Explore a mysterious ruined forest, collect coins, defeat enemies, and reach the end of each level to achieve victory.

Although the gameplay is simple, this project focuses heavily on building a clean and scalable architecture using common game development patterns and programming principles.

---

## 📖 Gameplay

### Objectives

* Explore the forest
* Collect coins
* Defeat enemies
* Reach the goal and complete the level

### Current Content

* 2 Playable Levels
* Multiple enemy types
* Coin collection system
* Combat system
* Victory conditions
* UI feedback system

---

## 🛠 Technologies Used

* **Unity Engine**
* **C#**
* Unity Animator
* Scriptable Objects
* Object Pooling

---

## 🏗 Architecture & Design Patterns

This project was built with maintainability and scalability in mind.

### State Machine

State Machines are used to control:

#### Player States

* Idle
* Walk
* Jump
* Fall
* Dash
* Attack

#### Enemy States

* Patrol
* Chase
* Attack
* Death

#### Game States

* Main Menu
* Playing
* Game Over
* Victory

This approach keeps behaviors organized and prevents large, difficult-to-maintain scripts.

---

### Event-Driven Architecture

The game uses **Action Events** to decouple gameplay systems from UI systems.

Examples:

* Health changes update the Health Bar
* Coin collection updates the Coin Counter
* Game state changes update menus and screens

This creates cleaner communication between systems and reduces dependencies.

---

### Scriptable Objects

Scriptable Objects are used to store and manage game data such as:

* Player Stats
* Enemy Stats
* Configurable Values

Benefits:

* Easy balancing
* Reusable data
* Cleaner inspector workflow

---

### Object Pooling

Object Pooling is used to efficiently spawn and recycle objects such as:

* Visual Effects
* Projectiles
* Temporary Gameplay Objects

This helps reduce runtime allocations and improves performance.

---


