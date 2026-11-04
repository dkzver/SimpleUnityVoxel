# Lunar Outpost — Voxel Rover

A cozy voxel-inspired lunar rover and base-building prototype for Unity 2022.3 LTS. The loop: explore a crater, mine regolith/ice/iron/titanium, level up, construct outpost modules, repair the rocket landing pad, then request scientists, technicians and workers from Earth.

## Play
1. Open the project with Unity 2022.3 LTS.
2. Create/open an empty scene, create an empty GameObject named `Game`, and attach `Assets/Scripts/LunarGameBootstrap.cs`.
3. Press Play. World, rover, HUD and game systems are generated at runtime.

**Controls:** WASD drive, E mine nearby deposits, 1 Solar panel, 2 Habitat, 3 Refinery, 4 repair landing pad, B request Earth crew (requires pad restored, level 3, adequate power/oxygen), Space brake, RMB locks mouse, Esc releases cursor.

## Economy & progression
- Deposits yield 3 units each; mining grants 12 XP. Levels require 100 XP × current level.
- Solar: 8 Iron + 2 Electronics → +35 power.
- Habitat: 12 Iron + 15 Regolith + 4 Electronics → additional crew capacity and oxygen.
- Refinery: 15 Iron + 5 Titanium.
- Landing pad restoration: 20 Iron + 10 Parts + 30 Regolith. Unlocks Earth supply/crew missions.
- Earth delivery: level 3+, repaired pad, Power ≥20 and O₂ ≥30; grants one scientist, technician, worker, electronics/parts, power and oxygen.
- Crew consumes power and oxygen periodically; expand solar/habitat to support a larger settlement.

This is a prototype-scale game simulation, not engineering-grade life support or launch modeling. Primitive meshes are used to keep the repository dependency-free.