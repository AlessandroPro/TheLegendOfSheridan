PROG50102 - Final Project

Team Name: Nintendon't

Abhishek Tippireddy
Alessandro Profenna
Rishi Barnwal

All requirements have been satisfied (as far as we can tell), but the player's health bar UI doesn't update properly.

Some notes:
This game was developed using a PS4 controller.
Our game starts with a main menu that will bring you to an overworld with two portals to our two dungeons.
The first scene that should be opened is 'MainMenu'.
There is a pause menu and also a game over screen when the player dies.
The player, directional light, and background music are persistent objects between scenes.
The horse is our vehicle with 4 IK points.
The destructible obstacle is a fiery wall before the dragon, which cna only be destroyed using the magic staff.
Locked doors must first be unlocked by using the key, then kicked open.

Weapons:
Mace: is the 2 handed weapon (uses a second invisible player rig for animation).
Magic Staff: One-handed weapon, casts a magical spell that uses splines to direct the movement of the magic fire
Bow and Arrow: Projectile-weapon, shoots arrows

There are keys that can also be picked up.
Any items that are picked up are part of your inventory within the current dungeon, and the equipped item can be swapped, this includes keys.

Enemies (each move with a navmesh):
Knight: will attack with sword
Vampire: will pickup a sword in front of them and attack the player with it, otherwise they'll swipe with their claws
Dragon: will spit fireballs at the player

Any weapon can kill them.

_____


CONTROLS (PS4):

Menus: Left Analog to choose an option, X to confirm
Pause: Options Button
Player Movement: left analog stick
Pickup items (weapons and keys): Circle Button
Use equipped item: Circle Button
Change equipped item from inventory: Triangle Button
Unlock Locked Doors: use the key with Circle Button
Open unlocked Doors: kick them open with the Triangle Button
Mount Horse: Triangle Button
Dismount Horse: Triangle Button
