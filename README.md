# The Legend Of Sheridan
This project was imported from GitLab.

The Legend Of Sheridan is a small game made in Unity where a hero, Erika, traverses two dungeons while picking up weapons (mace, mage staff, bow and arrow), fighting enemies (knights, zombies, dragon), riding a horse, and unlocking doors with keys. This game somewhat mimics the style of The Legend of Zelda: Link's Awakening, with a top-down camera view. <br>
The purpose of this project was to exercise and demonstrate our understanding of player movement, animation blend trees, object and enemy interaction, scene management, and the use of inverse kinematics.

This game was developed in Unity 3D on a team of 3 programmers.

Team:<br>
Alessandro Profenna <br>
Abhishek Tippireddy <br>
Rishi Barnwal <br>

All relevant code is in the scripts in /Assets/Scripts/. <br>
My major contributions to the project: 
* Picking up and and using items/weapons
* Mounting/dismounting and riding the horse
* Unlocking and opening gates

All 3D assets, including animations, were downloaded from third-party sources. The playable character, Erika, and her animations were downloaded from Mixamo.

### Some general notes:
* This game was developed using a PS4 controller.
* Our game starts with a main menu that will bring you to an overworld with two portals to our two dungeons.
* The first scene that should be opened is 'MainMenu'.
* There is a pause menu and also a game over screen when the player dies.
* The player, directional light, and background music are persistent objects between scenes.
* The horse uses 4 IK points (hands and feet)
* The weapons and keys are picked up using IK points
* There is a fiery wall before the dragon, which can only be destroyed using the magic staff.
* Locked doors must first be unlocked by using the key, then kicked open.
* The player's health bar UI doesn't update properly.

### Weapons:
* Mace: is the 2 handed weapon (uses a second invisible player rig for animation).
* Magic Staff: One-handed weapon, casts a magical spell that uses splines to direct the movement of the magic fire
* Bow and Arrow: Projectile-weapon, shoots arrows

There are keys that can also be picked up.
Any items that are picked up are part of your inventory within the current dungeon, and the equipped item can be swapped, this includes keys.

### Enemies:
(each moves with a navmesh) <br>
* Knight: will attack with sword
* Vampire: will pickup a sword in front of them and attack the player with it, otherwise they'll swipe with their claws
* Dragon: will spit fireballs at the player

Any weapon can kill them.

_____


### Controls (PS4):

Action | Control
------------ | -------------
Choose Menu Option | Left Analog
Confirm Menu Option | X Button
Pause | Options Button
Player Movement | left analog stick
Pickup items (weapons and keys) | Circle Button
Use equipped item | Circle Button
Change equipped item from inventory | Triangle Button
Unlock Locked Doors | use the key with Circle Button
Open unlocked Doors | kick them open with the Triangle Button
Mount Horse | Triangle Button
Dismount Horse | Triangle Button




Using the mage staff to attack enemies:
![magic](https://user-images.githubusercontent.com/15040875/72399164-50ef7c80-3713-11ea-806b-5a083d298b75.jpg)

Mounting the horse:
![horse](https://user-images.githubusercontent.com/15040875/72399736-05d66900-3715-11ea-9062-6987f28ce4bd.jpg)

Attack with the bow and arrow:
![Screenshot11](https://user-images.githubusercontent.com/15040875/72306847-7498c100-3646-11ea-8bac-51c142fc0482.PNG)
![Screenshot8](https://user-images.githubusercontent.com/15040875/72306844-7498c100-3646-11ea-9de9-cd761fcb6f4d.PNG)

Attack with the mace:
![Screenshot9](https://user-images.githubusercontent.com/15040875/72306845-7498c100-3646-11ea-8070-a10811fbc74f.PNG)
![72306837-74002a80-3646-11ea-8649-aa4200550f63](https://user-images.githubusercontent.com/15040875/72399958-b2b0e600-3715-11ea-80ba-459c5dc357f1.png)

Kicking open a gate after unlocking it:
![Screenshot10](https://user-images.githubusercontent.com/15040875/72306846-7498c100-3646-11ea-9ccd-4f52bff97521.PNG)


