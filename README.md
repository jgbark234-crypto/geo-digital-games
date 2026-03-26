# Simple 3D FPS (Unity)

This project includes beginner-friendly Unity C# scripts for a simple 3D FPS prototype with:

- WASD + mouse look movement
- Jump + sprint
- Shield system with 3-second delayed regeneration
- One enemy that walks toward player and shoots
- Basic gun with shooting + reload

## Scripts

- `Assets/Scripts/PlayerController.cs`
- `Assets/Scripts/ShieldSystem.cs`
- `Assets/Scripts/GunController.cs`
- `Assets/Scripts/EnemyController.cs`
- `Assets/Scripts/SimpleHud.cs`

## Quick scene setup

1. Create a new **3D (Built-In)** Unity project.
2. Add a `Plane` as ground.
3. Create a `Player` GameObject:
   - Add `CharacterController`
   - Add `PlayerController`
   - Add `ShieldSystem`
   - Add `GunController`
4. Add a `Camera` as a child of player and place it around eye height.
   - Assign the camera transform to `PlayerController.cameraRoot`
   - Assign the camera to `GunController.playerCamera`
5. Create an `Enemy` object (Capsule is fine):
   - Add `EnemyController`
   - Drag `Player` into `EnemyController.player`
6. Optional UI:
   - Add Canvas + two Text elements for shield/health
   - Add `SimpleHud` to any object and wire references.

## Controls

- Move: `WASD`
- Look: Mouse
- Jump: `Space`
- Sprint: `Left Shift`
- Shoot: `Left Mouse`
- Reload: `R`

## Notes

- This uses Unity's default Input Manager axes: `Horizontal`, `Vertical`, `Mouse X`, `Mouse Y`, `Jump`, `Fire1`.
- Enemy shooting is direct damage (no projectile visuals) to keep the prototype simple.
