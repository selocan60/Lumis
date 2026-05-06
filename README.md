**Team Name:** Lumis

**Team Members and Roles:**
* **Selman Erdoğdu** (GitHub: [selocan60](https://github.com/selocan60)) – Game, Level, and UI/UX Designer
* **Görkem Arslan** (GitHub: [ArslanGorkem52](https://github.com/ArslanGorkem52)) – Gameplay Programmer

---

# Game GDD (Game Design Document)

**Game Title:** Lumi
**Genre:** 2D Platformer / Puzzle (Includes Auto-Runner Elements)

**Elevator Pitch:** Lumi is a character who runs forward endlessly, trying to escape pursuing enemies. While the player uses the keyboard to trigger Lumi's instant abilities (shield, jump, drop decoy) with precise timing, they must also use the mouse to draw platforms to bridge gaps. In this game where quick thinking and proper timing are crucial, the main objective is to evade enemies and guide Lumi to the safe goal at the end of the level.

**Core Gameplay Loop:** Continuously Advance → Spot Danger → Use the Right Ability (Key) on Time → Draw a Path (Platform) for Gaps → Reach the Goal.

**Controls and Mechanics:**
Lumi moves forward automatically. The player intervenes based on the situation as follows:

* **Platform Drawing (Keyboard + Mouse):**
  * **`Z` + Left Mouse Click:** By pressing the `Z` key on the keyboard and clicking the left mouse button, a temporary ground (platform) is placed at the targeted location. This is the only mechanic in the game that utilizes the mouse.

* **Lumi's Instant Abilities (Keyboard Only):**
  * **`X` - Drop Decoy:** Lumi drops a decoy at their current position and continues running. Pursuing enemies will stop chasing Lumi and get distracted by this decoy.
  * **`C` - Jump:** Lumi throws a jump pad right in front of them and immediately bounces off it to vault over obstacles/enemies.
  * **`V` - Shield:** Lumi creates an instant shield around themselves to block one instance of incoming damage.

**Win-Loss Conditions:**
* **Win:** Lumi successfully running non-stop and reaching the safe goal at the end of the level.
* **Loss:** Lumi falling into a gap, colliding with an obstacle, or being caught by an enemy.

**Art Style:** Minimalist 2D / Vector Design (Dark space theme and a flat color palette).

**GitHub Link:** [https://github.com/selocan60/Lumis](https://github.com/selocan60/Lumis)
