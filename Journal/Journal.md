# Journal

## Make A Thing: Dungeon Crasher ((22/01/2026))

### Initial Idea

In one of my previous programming classes, I was introduced to the browser supported game engine Phaser that enables developers to create games that can run on web browsers. I was quite impressed by its wide array of features for a game engine tailored to making web-based games. While I was looking at the various examples of code on their website, one of them stood out to me. It was a code setup that enabled [multiple cameras to be used within the same display area](https://phaser.io/examples/v3.85.0/camera/view/follow-sprite). I thought to myself that something interesting could be done with this system and I decided to build a game starting from this system.

![CameraExample](Media/CameraExample.png)

### Development Process

From this initial idea, I studied the possible applications of such a feature in a game. It could be used in a puzzle game to highlight objects that you must find in a large map. It could be used in a multiplayer game to enable two players to explore a vast space within the constraints of a single screen/game window. I finally settled on creating a game where the player must defeat enemies across a large stage, but the player can only see its four corners. 
The game’s main level is simply a very large square, but I adjusted the zoom and position of each camera to create an illusion that brings the players to believe that the stage is much smaller than it is due to how the tiles align perfectly at the edge of each camera. Creating a surprise effect when the player sees his character leave the screen

![FakeEnemyProx1](Media/FakeEnemyProx1.png)

In this situation, a player would probably think: This enemy seems close; I’ll go defeat him.

![FakeEnemyProx2](Media/FakeEnemyProx2.png)

But then suddently, the game catches him by suprise. He gasps: What? I cannot reach him? I’m leaving the screen?

In the areas that the player cannot see, there are a multitude of obstacles that can block their way. Consequently, the challenge this game presents to the players is that they must successfully navigate across obstacles positioned in the areas of the map that they cannot see to reach the enemies that only spawn in the four corners of the map.

After creating the bulk of the game, I continued to look at more of the examples on the Phaser website and I discovered a camera effect that enables [adjusting the pixelization of the camera's rendered space](https://phaser.io/examples/v3.85.0/fx/pixelate/view/pixelate-transition-scene). I tested implementing it in my game and I realized that it improved the illusion that I created beforehand. I was happy with the result, so I kept this camera effect on in the game.

![PixelateOff](Media/PixelateOff.png)

A pixel perfect image is rendered, everything is quite distinct.

![PixelateOn](Media/PixelateOn.png)

The blur caused by the pixelate filter creates a retro game impression, also helping in concealing the illusion.

### Concluding Thoughts

This smaller project was a good creative exercise for me. It was able to practice developing a project from a single strong idea/concept. Study and explore the potential avenues from this initial idea before finally adapting and transforming it into something playable. I have worked on various games before, and their development mostly started with an amalgamation of ideas/mechanics, and it can be quite easy to get entangled in trying to make them all coexist. So, developing a game from a singular idea this time, building mechanics and complexity starting from a single baseline, was a valuable experience.

## Unity Exploration: fallAsleep2025_+ ((29/01/2026))

### Initial Idea

To explore the Unity game engine and further familiarize myself with it, I decided to modify and insert additions to the fallAsleeep2025 project that was in the class's archive. The fallAsleeep2025 project is a game where you must catch falling yawning emojis. To add some spice to the game, I decided that I will add obstacles that the player will have to avoid. Since I didn't want to do anything too difficult, I though these additions would be a fair challenge for someone at my level.

### Development Process

After downloading and opening the unity project, the first step was to create the obstacle object and the script that will enable its functions. For the purpose of this game, the obstacle should be able to move horizontally within the confines of the screen/camera's rendered space and it should be able to destroy the player character. To simplify things, I decided to pack all of the funcitons needed to acheive this within a single script as I am not familiar with how to set up dependencies and references across scripts in Unity.

![ObstacleVariables](Media/ObstacleVariables.png)

The script begins with the creation of all the necessary variables for each obstacle to function properly. The xLocation and yLocation help set the obstacle's location when the game starts. The movementSpeed variable decides how fast the obstacle can move and a publig GameObject slot lets me connect the obstacle to the text object that will display the game over screen if the player ever collides with it.

The start function's goal is to set the position of the obstacle upon starting the game. Originally this would be set manually, but then I noticed that it would make every playthrough the same. So I used the UnityEngine.Random function to chose a random number within a specific range (between -7 and 7). Which will make the obstacle spawn at a different position horizontally each time.

![ObstacleMovement](Media/ObstacleMovement.png)

Making the obstacle move wasn't too difficult. In the update function, I simply added the movementSpeed value to the x position of the obstacle. I also added if statement to prevent the object from leaving the camera's bounds by inverting the value of the movementSpeed variable. When I initially tested this setup, the obstacle moved too quickly. So I multiplied the value used to move the object by the Time.deltaTime. Which is the time between each frame. This helped stabilize the obstacle's movement as it was very inconsistent and jittery.

![ObstaclePlayerDestroy](Media/ObstaclePlayerDestroy.png)

To enable the obstacle to destroy the player upon collision. I gave the player's sprite and the obstacle's sprite a rigidbody component to enable collision detection. Then, copying the logic found in the collector script that enable it to catch the falling emojis, I tagged the player as "Player" and enabled the obstacle to destroy gameobjects with said tag. To display the phrase "Game Over" upon being destroyed. Since I didn't know how to adjust text opacity within Unity. I simply positionned the text outside of the camera's view and simply changed its position to be within the camera's view to make it apprear.

Making one obstacle is nice, but then I though to myself. "One is a little boring, Why not make three!" So I duplicated the obstacle object to create 3 different obstacles, set them up at different heights, and enabled the player to move upwards and downwards to maneuver around all of them.

To make the player able to move up and down, I copied the current logic that enables them to move left and right and adjusted it to enable vertical movement. I added a yMovement variable and by pressing a key, it gets added or it is subtracted to the current yLoc value.

![MoveUp](Media/MoveUp.png)

But with that setup, the player can reach a near infinite positive or negative y value. So I added a maxHeight and minHeight value to constrain the player's vertical movement. 

![MoveUpRevised](Media/MoveUpRevised.png)

I finally ended up with a scene setup like so, with 3 obstacles, 1 player and the "Game Over" text just outside the camera's view.

![FinalSetup](Media/FinalSetup.png)

### Concluding Thoughts

I was able to meet all of the goals I set for myself in this little explorative project. I must admit though that some of the solutions that I found to solve my problems here aren't perfect. For example, sometimes, despite the current coding logic, the obstacles will exit the camera bounds because it moved faster than the script could process its x position. Constraining objects within specific bounds is something that I will have to study more as this type of feature is quite present in many modern video games and it is very likely that I will need to know how to implement this in a foolproof manner.

## Pawng evolution ((05/02/2026))

### Initial Idea

Pong (or Pawng here) is a digital replication of the sport of table tennis. Table tennis is a competitive sport for which tournaments are organised quite often. Games that have users compete with eachother must usually balance consistency and randomness in order to creat an experienc that rewards skill, but also doesn't always create or enable players to create the same situations over and over. Pawng, due to being based on table tennis, is a very deterministic game. With these thoughts in mind, I decided to reflect on the balance between consistency and randomness in Pawng and what additions could I do to the game to adjust or disrupt this balance in order to make the game more interesting to play and watch. Since I cannot lie about the fact that playing pawng, as opposed to table tennis, can get a little boring and repetitive.

Why does playing pawng get boring and repetitive? Earlier I mention that this game is a very deterministic game. The actions you take lead to easily predictable/calculable outcomes. There usually is no suprise when you knock the ball back with your paddle. But the rare moments where the ball takes a completely unexpected path after being struck would be the only time where the game demonstrates randomness besides the ball's initial trajectory on round start. So I decided to think about how to introduce more variety and/or randomness in the game in order to reduce the deterministic/consistent aspects of Pawng.

### Development Process

To introduce variety into Pawng, I must first take outline what elements of the game are static and consistent. There is the position, the movement speed, and the size of each paddle, the ball's speed and starting point, the terrain's height/length and the goal area's size (though the last two may change depending on the screen's size).

To manipulate the static and consistent elements of Pawng, I decided to create a randomly rotating state system within the ball's script.

![PawngReset](Media/PawngReset.png)

![PawngRdmSetup](Media/PawngRdmState.png)

Each time the game's Reset() function is called, the RandomState function is called. This function will roll a random number between 0 and 7. Depending on this number, certain variables will change through if statements that will be triggered by the value assigned to the state variable. Which will be the position, speed, and size of the paddles, the ball's speed and starting position, and the position of the top and bottom walls.

![ControlledObjects](Media/ControlledObjects.png)

To enable the BallScript to perform the aformetionned actions, I enabled the script to store the relevant game objects for easy referencing.

![RdmStateExample](Media/RdmStateExample.png)

Then, within if statements that rely on the random number assigned to the state variable, I can easily cause modifications to the base state of the game. However, there was a problim with this setup. Since I am using multiple if/else statements. If the requirements for a single if statement were met, it would also execute all other else statements for each if statement whoose condition was not met. Which lead to unwanted results. The only solution I was able to find to this problem was to assign specific variables to every manipulable game object in each state individually and remove all else statements as shown in the picture below. This solution was quite tedious to apply though and would definetly be something that could be improved upon in the future.

![RdmStateRework](Media/RdmStateRework.png)

With the completed BallScript, each reset creates various game states. Which helps retain the player's interest as the game will behave differently on each round. Also preventing the game from being monotonous due to being repetitive. I believe that this is an appropriate solution to my initial question.

![StateExample](Media/StateExample3.png)

![StateExample](Media/StateExample.png)

![StateExample](Media/StateExample2.png)

### Concluding Thoughts
Through this project, I learned how to tackle game development through the act of asking a question. Games can be built with the goal of providing an answer to all sorts of questions that someone could asks themselves. In this case, I asked a question regarding the emotional state of players interacting with Pawng. This has led me to theorize and study the various aspects of the game that can lead to this emotional response (boredom), and work on these outlined aspects to potentially change this emotional response for the better.

## Unity Exploration: BreakinOut ((12/02/2026))

### Initial Idea

Last week's exploration project showed me that interesting results can be acheived by introducing inconcistency and variation into a game's static/consistent elements or mechanics. Considering that I wish to build upon the breakinOut project, a classic video game where you must knock a ball towards destructible bricks to destroy them. I must first identify what elements of this game are static and/or consistent.

Within this game, the consistent elements are the paddle's speed and size, the ball's speed and size , the position, rotation, durability and point value of the bricks. Within the previous class, we already figured out how to add some variation to the point value of the individual bricks. So starting from there I decided to implement variation to the bricks' position and durability.

### Development Process

Taking inspiration from the code I wrote to include obstacles in the first week's exploration, I enabled the bricks to move left and right and to change their movement's direction when colliding with one another and added a Collision2D component. To prevent the bricks from always moving in the same direction, the initial movement speed and direction of each brick will be randomly assigned.

![StateExample](Media/MovementSpeedSet.png)

![StateExample](Media/BrickMovement.png)

However, after compiling the code and hitting the play button, this is what the play area looked like.

![StateExample](Media/CollisionlessMovement.png)

The bricks moved properly, but overlaped eachother instead of colliding because I didn't add a rigidbody 2D component to enable the bricks to collide. After adding the rigidbody 2D component, I tested my program again.

![StateExample](Media/InitialMovementTest.png)

The bricks pushed themselves out of place! Maybe this effect could be interesting for a future project, but it wasn't what I was looking for here. So I adjusted the rigidbody 2D settings to lock the y position and the rotation of the bricks to prevent them from rotating and from moving up and down.

![StateExample](Media/ClippingMovement.png)

This time the bricks clipped into eachother and got stuck. Which made their movement behave improperly. I assumed that the problem was that the bricks lacked space, which causes them to collide with eachother too frequently and consequently end up clipping into eachother. So I created a new brick prefab that is smaller than the original brick in order to leave more space between each one.

![StateExample](Media/SmallBrick.png)

![StateExample](Media/SmallBrickTest.png)

The bricks no longer clipped into eachother thanks to the extra space they have to move in now. However, some bricks are static. Probably due to the fact that the Random.Range code line includes the value 0. So I created a setup that should hopefully avoid assigning the value 0 to any brick's movement speed.

![StateExample](Media/MovementSpeedSet2.png)

But after compiling, I have met another problem.

![StateExample](Media/MovementSpeedSetFailure.png)

The bricks are not moving! And after verifying the moveent speed value of the bricks during runtime, they are all set to 0!

In order to prevent this from happening, I decided to change how movement speed is assigned to each brick. The new method I scripted starts with a new float "initialMovement" and a boolean "initializeMovement".

![StateExample](Media/initialMovementVar.png)

When a brick gets created, a random number within the specified range (-1, 2) gets gets assigned to the initialMovement variable. Then, the assigned value drives the function that will determine the brick's initial movement speed.

![StateExample](Media/AssignMovement.png)

The if and else if statements within the initializeMovement function depend on the value assigned to "initialMovement". If the value is below or equal to 0, the brick's initial movement will be towards the left. If the value is superior to 0, the brick's initial movement will be towards the right. This setup completely avoids assigning the movement value of 0, so no brick stays still. However, the bricks began clipping into eachother and got stuck in large groups again. So I tried another potential solution, which is to increase the size of their collision box.

![StateExample](Media/SmallBrickRegCollision.png)

![StateExample](Media/SmallBrickBigCollision.png)

Somehow, this solution wasn't able to solve the problem. The bricks still got stuck, but they had more space between eachother due to their larger collision box.

![StateExample](Media/SmallBrickBigCollisionTest.png)

Honestly, since collisions are causing so much trouble, I've decided that I will simply abandon making the bricks change their direction by colliding with eachother and allow them to overlap. So I removed the rigidBody 2D which enabled this behaviour, adjusted the range of available values for movement speed and with this, this exploration prototype is complete. 

![StateExample](Media/SmallBrickOverlap.png)

![StateExample](Media/SmallBrickOverlap2.png)

### Concluding Thoughts

Through this exploration, I discoverd the complexity of introducing randomized and continuous variation into a game. Building a game with variation and randomness in mind sadly makes the it very prone to errors and bugs. I am a little sad that I wasn't able to make collisions work. But I am still quite happy with my final result. I now have much greater insight on the reason why video games tend to avoid too much randomness and variation within the game's mechanics/code, because not only it can cause many cases of unintended behavior, but also make the game difficult with how annoying it is to do certain things. For example, when I tried playing my complete prototype. I realized that the less bricks there were, the more annoying ther were to destroy, especially those that moved too quickly. It's nice and all that the game never behaves in a repetitive manner thanks to randomness and variation, but it is also important such things must have the smallest impact possible the game's playability. Lest you piss off your playerbase and end up with nobody playing your game because its too "random".

## Unity Exploration: Level Based BreakinOut ((19/02/2026))

### Initial Idea

Considering how in the following weeks we will begin developing a project on a larger scale, I wanted to eget a little head start by experimenting on a longer gameplay loop with added complexity. Looking back at my previous BreakinOut project, I tought that it could be an interesting experiment to try to create an expansion to this game by building something new ontop of its current gameplay loop.

A great way to create something new based on an existing game is to change or transform the game's mechanics. The game that I am modifying here, a classic brick breaking game, is played by launching a ball towards a brick using a paddle in order to gain points while avoiding letting the ball reach the bottom of the screen. The game usually takes place in a small square or rectangular arena and the player can take advantage of the walls to send the ball towards the bricks. With these basic mechanics outlined, I had to decide which one I would adjust in order to create a longer gameplay loop that feels fresh and innovative compared to the original game. I thought to myself that It could be interesting to go for modifying the arena in which the game could take place. Then, I got the idea that I could combine elements of the platformer genre with this game. Creating a game where you (the paddle) must navigate across various levels while using the ball to remove obstacles in your way and/or to create new paths. 

### Development Process

I began by creating the level the game will take place in. It wasn't too difficult to make using primitive shapes. I also had to adjust the size of the paddle, the ball and both their speed values due to the change of size.

![StateExample](Media/InitialLevelBuild.png)

Then, I wanted to add obstacles. To create them, I simply duplicated the bricks used in the original game, adjusted their size, and removed the brickScript which made them move since I wanted them to stay still.

![StateExample](Media/LevelObstacles.png)

Finally, to make the level end, I created a yellow colored brick that when destroyed, would change the scene to the game over screen. I put this brick at the end of the level.

![StateExample](Media/WinBrickScript.png)

![StateExample](Media/LevelWinBrick.png)

Then, to enable the player to properly navigate across the level, I had to enable him to jump. So, in the paddleScript, I added code to enable the paddle to jump.

![StateExample](Media/PaddleJump.png)

To make the player jump, the script adds a vertical velocity to the player. And to disable jumping mid air, I used an isJumping boolean that is set to true when the player hits the jump key and that only returns to fals when the player collides with the ground. However, the collision system didn't work very well and the player could still jump mid air as if he was flying. I tried multiple other methods to fix this, but in the end, I left it as is because I thought that despite being an unintended behaviour, It reinforced the importance of the ball in clearing the obstacles. The player's movement is free and unrestricted, but he cannot bypass the obstacles.

With all of this, the game worked relatively well. However, an annoying problem surfaced during gameplay.

![StateExample](Media/BallClipping.png)

The ball went out of bounds!

I theorized that the ball went out of bounds due to its speed. When going over the ball's script. I noticed that I forgot to make it recognize the ground and execute the speedCheck() function upon collision, so I added that in the script in hopes that it would fix my problem.

![StateExample](Media/BallGroundCheck.png)

Sadly, It did not fix my problem. the ball kept reaching ridiculously high speeds. So I decided to make the ball heavier instead to prevent it from accellerating and moving too quickly. I increased the ball's mass from 0,01 to 1. Weakening the application of kinetic force on it and sucessfully slowing down its movement overall. The ball no longer went out of bounds. 

![StateExample](Media/LevelGameplay.png)

![StateExample](Media/LevelGameOver.png)

Also, since the obstacles are bricks, the player's score will vary depending on how many obstacles they destroy. They aren't forced to destroy all of them to complete the level. But to obtain the highest score possible, they will have to destroy all of them. This adds an extra layer of challenge for those who are interested.

### Concluding thoughts

This project was an interesting opportunity to try adding a twist to an existing game genre/gameplay loop. I've seen many cases where innovation in the landscape of games and video games was acheived through this technique and I understand no why it works so well. Reminiscing on the concepts of randomness and variation that I explored in the earlier weeks, you can create an incredible amount of changes and variation in a preexisting game by tweaking a few variables or changing rules. Here, I changed the rules of the traditional brick breaking game and transformed it into a completely new experience while also retaining some connection to the original by adapting its gameplay and feedback loop to a new environment: a platforming game.

## Session Project: Brainstorming ((25/02/2026))

### Initial Idea Brainstorming

The first step to a project is the idea behind it, working without a clear idea of what I want to make can lead to a headless chicken scenario. So I wanted to start this project by writing down the details of the project that I will be working on. The brain dump done in class helped alot in generating a wide variety of potential projects. During the brain dump, I split the keywords I wrote down into eight categories: 

Guides: Sounds, Warnings, Color, indicators, map, arrows

Space & Style: 3D, verticality, Atmospheric, Stylized, Cartoony, Y2k x Frutiger aero, Bryce 3D, 2000s core

Enemies: Obstacles, targets, moving enemies, jumping enemies, blocking/parrying enemies, invincible enemies

Hazards: holes, fire, slippery floors, traps

Goals: Avoid the ball, avoid the enemies, destroy all targets, reach the ending quickly, survive for x duration

Areas: Garden, city, mountain range, sky, space, volcano, temple, castle, streets

Total results: max speed, avoidance, score, targets destroyed

During the previous weeks' explorations, I developed a greater and greater interest in movement within games and how its behaviour and the actions it can enable to various objects can create interesting gameplay experiences. I decided then that my game will have a focus on movement and environmental interaction. From this focus, I created three potential ideas that I may continue developing in the following weeks.

Idea 1: A movement-based platforming game where you must destroy objects or enemies by striking them with a boomerang. Since it is a boomerang, it is constantly returning to you and if it hits you, you lose.

Idea 2: A Stealth turn-based game where you must stealthily sneak around enemies with limited movement available to you during your turn. You move around by rolling a dice, but you can also manipulate the dice’s result by using the environment (throwing the dice at a wall for example)

Idea 3: A platformer where you must build your way out using your own body. Create duplicates of yourself and adjust their position and rotation to build stairs, ladders, bridges and more.

In terms of ease of implementation, the 1st idea would be the easier one to develop into a playable prototype. The second and third ideas have a much higher base implementation requirements but I do think these ideas are quite interesting and I may merge them into the my project if I am interested. The keywords generated in the brain dump will be a great aid in creating the project. As thanks to them, I already have an idea of what I should implement in my game project and I won't get stuck in the planning process due to having a list of references to pull from.

To test out the 1st idea, I revised one of my older game projects. It was a game where you had to avoid a growing enemy constantly chasing you. Here I was able to program the enemies to follow the player automatically, which means that I could reuse this code to make the boomerang move towards the player after being thrown.

![StateExample](Media/EnemyTrackingLogic.png)

The enemy's x and y acceleration changes depending on the player's position in relation to it. Consequently making it follow the player. This method only takes the x and y axis into account so If I wanted to pivot to 3D, I would have to include the z axis too. But I'll decide that later.

![StateExample](Media/AvoidTheEnemy.gif)

### Future Steps

The next step for the project would be to create a solid and highly descriptive project idea and outline the steps that will lead to its completion. It's obviously impossible to perfectly predict and plan the project's development and there will always be unexpected moments that may lead to spending time in other parts of the project or even new additions. But having a clear idea of what will be needed to lead the project to fruition helps greatly with maintaining a sense of direction and avoiding getting "lost in the sauce".

## Session Project: 2003D Breaker development begins! ((11/03/2026))

### Before development: Solidifying the idea of 2003D Breaker

Last week, I mentionned the importance of having a solid idea behind a project. Following my own advice, I firstly debated on which idea I came up with to expand upon. The 1rst idea came out as the winner. From this, I created a document outlining the majority of the project while leaving some space for some changes in case I change my mind on some things or I get inspired to add extra things to my project.

Titled 2003D Breaker, this project will be a movement-based platforming game where you must destroy objects or enemies by striking them with a boomerang like weapon. The game's special twist is that you cannot catch wour weapon after it is initially thrown and your weapon can hurt you. Additionaly, since it is a boomerang, it will constantly attempt to return to you and if it hits you, you will lose life points.

Many of the ideas that I came up with during the brainstorming session will be used in this project:

Guides: Sounds, Warnings, Color, indicators, map, arrows

Since I am making a platformer, I could simply organize the level's design to naturally guide the player towards the end of the level. If needed, I may incorporate color codes, warnings, arrows and indicators in areas with less intuitive traversal paths.

Space & Style: 3D, verticality, Atmospheric, Stylized, Cartoony, Y2k x Frutiger aero, Bryce 3D, 2000s core

I think that platformers benefit greatly from 3D space, so I will be making the game in 3D in Unity. In terms of visual style, if my available time allows it, I find stylized retro visuals very attractive. So I would definetly like to emulate this style within my game (again, if my time allows it, I'll focus primarily on prototyping and making the mechanics work).

Enemies: Obstacles, targets, moving enemies, jumping enemies, blocking/parrying enemies, invincible enemies

Hazards: holes, fire, slippery floors, traps

Enemies and hazards are a staple in platformers. I will definetly include enemies in the game and giving them the ability to block in a specific direction for example could creat interesting scenarios where the player must make clever use of the boomerag weapon's motion path. Traps also could create interesting dynamics with the boomerang weapon as the player will have to be wary of them alongside his own weapon.

Goals: Avoid the ball, avoid the enemies, destroy all targets, reach the ending quickly, survive for x duration

The game's primary goal is to complete the level. Extra secondary goals could be to complete it without getting hit, complete it in under 1 minute, etc...

Areas: Garden, city, mountain range, sky, space, volcano, temple, castle, streets

These are all fantastic potential areas for levels, but since this is a prototyping class, I will probably have to focus on making 1 level first. For the sake of ease of creation, I will probably create a level high in the sky, which would give me the affordance of only having to model floating islands and not having to model the a landscape.

Total results: max speed, avoidance, score, targets destroyed

### Development process: The boomerang

The boomerang-like behaviour of the player's weapon is arguably one of the most important parts of my project. Last week, I returned to one of my older projects and studied the logic I used to code an enemy that follows the player. With the information I gathered from this study, I created the first iteration of the boomerang script which will enable the player's weapon to behave like one.

![StateExample](Media/BoomerangScriptOriginal.png)

So far, the script begins by storing various variables such as the speed, the maximum distance it can travel before returning, its starting position, a "returning" boolean which will be used to determine whether the boomerang is returning or not, which game object is the player and their position(transform data). Once instantiated, the boomerang flies forward until it reaches the max distance, then the "returning" boolean is set to true and the boomerang begins to return to the player by tracking the player's position and calculating Vector3 transforms that will lead the boomerang to reach the player. This method only enables the boomerang to track the player rigidly, but it's a fair start.

![StateExample](Media/BoomerangInitialTest.gif)

### To-do List
-Boomerang Acceleration
The boomerang script works fine so far, but I need to figure out how to make it accelerate and decelerate naturally as it only moves with a static speed. Figuring this out is very important as it should be what enables the boomerang to overshoot and fly past the player.

-Boomerang return movement
To adjust the boomerang's return movement, instead of continuously tracking the player, I could make it capture and store the player's position once it has reached its max distance and use that position as a point of origin. It will move to that point, then move further until it reaches max distance, then restart this cycle.

-Enemy Programming
Create and program enemies. Take inspiration from the obstacles programmed in the fallAsleep+ project.

## Session Project: 2003D Breaker development: movement ((19/03/2026))

This week, I decided to tackle the most important component of my game, movement. I wanted to finalize the script that enables the player to move and the BoomerangScript’s tracking method as it was too precise and consequently made it very difficult for the player from dodging it.

### Development process: Finalizing player movement

In the case of the player’s movement. The script that enables the player to move and jump worked just fine. To enable the main camera to be controllable with a mouse and to follow the player, I used the Cinemachine FreeLook camera included in the Cinemachine add-on. However, the player’s movement didn’t adapt to the camera turning around. For example, if I turned my camera to the left and held the “w” key to move forward, I would move to the right instead.

To adjust this, I used some math to adjust the vector used to move the player in order for it to be relative to the camera’s angle. 

![StateExample](Media/PlayerMovementRotate.png)

By calculating a vector facing forward from the camera’s view angle and multiplying that vector by the vector used for movement then normalizing it, I made it possible to .

### Development process: The boomerang pt2

In the case of the boomerang’s movement. I while I was reviewing the method used to make it move in game. I had to make a decision: Should I make the boomerang move using step-by-step translation or physics-based movement?

For my game, I needed to replicate a boomerang's ability to overshoot when returning to the one who threw it. After studying real-life boomerangs and a few hours of trial and error in modifying the original BoomerangScript, I decided to opt for the physics-based approach since I realized that in the original step-by-step translation method, I was essentially recreating physics-based movement (acceleration, deceleration, friction, drag, etc...). So why not just use physics directly instead.

To enable the boomerang to move using physics, I took heavy inspiration from the ballScript from the breakinOut+ project. The ballScript uses the “addforce” function to apply a force on the rigidbody. Since the BoomerangScript already calculates a vector that points towards the player’s position. I can simply apply a force in the direction of that vector to make the boomerang move towards the ball using physics. After figuring this out, I immediately went to testing.

![StateExample](Media/BoomerangCompleteInitialTest.gif)

For some reason, it didn't seem like the ball was tracking the player. Instead, it bounces left and right without a clear direction. Considering how this is most likely a physics issue, I went over the rigidbody's parameters and noticed that I was using the "ballMat" physics material.

![StateExample](Media/BallMat.png)

 I decided to remove it then test again to see if the behaviour changes.

![StateExample](Media/BoomerangCompleteNoMatTest.gif)

The boomerang now moves properly and tracks the player relatively well. But now a new problem surfaced. The boomerang wouldn't dissapear anymore when it entered the ranged within which it could be "caught" by the player. The BoomerangScript uses the distance between the player and the boomerang to determine whether to destroy the boomerang or not. I decided to increase the minimum distance required for the boomerang to be caught by the player.

![StateExample](Media/BoomerangCompleteDistanceTest.gif)

### To-do list

- The BoomerangScript is now pretty much complete. All that is left would be creating a custom physics material for the boomerang object itself, extra tweaks, and, if possible, enabling it to phase through objects I wouldn't want it to collide with.

- Begin testing collision interactions between the boomerang and foreign rigidbodies.

- Continue working on enemy programming. The method I used to make the boomerang home in on the player could be used in the enemies too to make their movement more interesting and varied instead of being linear.

## Session Project: 2003D Breaker development: enemies ((26/03/2026))

This week I decided to work on the game's enemies. I wanted to create at least one type of enemy to include within this prototype as I planned.

### Development process: Creating the script that drives enemies

Before beginning to work on the script that drives the enemies, I had to decide on how would I want the enemies to behave within the game. Will the enemies stay grounded or can they fly? Would I want them to follow specific paths? Would I want them to track the player? If yes, with how much accuracy? For now, I decided that the enemies in the game will be able to fly (maybe other enemy types will be grounded), they won't follow specific paths, they will track the player instead. Most importantly, just like the boomerang, they must be able to miscalculate their movement and overshoot the player.

The desire to avoid making the enemy's movement deathly accurate made me remember how I divided the two types of methods I use to make objects move within the game.

Moving using basic translation: Making the enemies move using translation can make their movement towards the player a little too accurate, which can make them more difficult to dodge as they will home in on you with perfect precision.

Moving using physics: Just like with the boomerang, making the enemies move using physics makes their homeing movement much less accurate. They can now miss you if you run close by and they can overshoot you if they are moving too quickly.

Thus I decided to make the enemies move using physics just like the boomerang. Consequently, the Enemy script I created for them is very inspired by the BoomerangScript itself. It draws a vector pointing towards the player and applies a force in that direction on the enemy GameObject.

![StateExample](Media/EnemyMovementScript.png)

After creating this script, I created a test enemy (a simple capsule) and applied the script to it to test its functionnality.

![StateExample](Media/EnemyPlayerFollow.gif)

The script works well, the enemy tracks the player in a similar fashion as the boomerang. The next step is to enable the enemy to eliminate the player. To do so, I simply used collisions. If the enemy collides with the player, the player GameObject is destroyed and they lose.

![StateExample](Media/DestroyPlayerContact.png)

Of course I then tested this new fuction.

![StateExample](Media/EnemyDestroyPlayer.gif)

The player does get eliminated when entering colliding with the enemy. Now, I can add the final touch to the enemy script: the ability to defeat(destroy) them using the boomerang. To do so, I used the same collision system the enemies use to destroy the player GameObject, but now targeting the enemies instead.

![StateExample](Media/BoomerangDestroyEnemyContact.png)

I then tested this new fuction.

![StateExample](Media/BoomerangEnemyDestroy.gif)

The player's boomerang can now eliminate enemies. With that, the script that drives the enemies is pretty much complete. Now I must set up the enemy spawners which will dictate how and where the enemies spawn.

Last week, I created an outline for the game's first level. This level will alternate between obstacles and areas with enemies to defeat. Once you overcome an obstacle, there will be an area where you must defeat enemies before proceeding towards the next obstacle. In total, there will be 4 obstacles and 3 areas with enemies to defeat. The final obstacle being the one behind which the level's end is hiding.

Considering how I divided this level in steps. The direction that I am planning to take in terms of level design will be to create interconnected dedicated areas for each obstacle/puzzle to overcome and for each wave of enemies to defeat. Since there will be areas dedicated for combat, the method that I will use to spawn enemies will be using a collision box that will encompass the entire battle arena. Once the player steps inside, the enemies will spawn in random points within the collision box and from there will begin moving towards the player to attack them. To make this possible, I created a EnemySpawner script that uses collisions to determine whether the player has entered it and spawns instances of a select enemy prefab within the area it covers.

![StateExample](Media/EnemySpawnerScriptOriginal.png)

I enlarged the test area and tested the EnemySpawner's functionnality.

![StateExample](Media/EnemyInstantiateProblem.gif)

For some reason the enemies that are spawned are way too big! Instantly destroying the player upon spawning. I decided to review the code line that creates the enemy instances as the prefab that it is supposed to instantiate doesn't have that size. Which means the problem must be in the act of creating instances of the prefab. I found out that I made the instancing code line refer to the EnemySpawner's transform(scale) values. Which probably enlarged the instanced enemies as they would use these values. Thus I removed this reference within the code line.

From this:

![StateExample](Media/EnemyInstantiateProblem.png)

To this:

![StateExample](Media/EnemyInstantiateFixed.png)

I then tested the spawner once again to see if this change solved my problem.

![StateExample](Media/EnemyInstantiateFixed.gif)

The enemies now spawn properly and with the right size. The EnemySpawner script is now complete!

Looking back at the solution I created to spawn enemies, I realized that using a box to spawn enemies wouldn't work very well in a larger more complex area with varied elevations (a staircase for example). As enemies could spawn inside terrain due to the spawning area clipping into surrounding terrain. But this could be solved using complex custom made shapes for the spawn areas or dividing one large spawn area into a multitude of smaller boxes that avoid clipping into the terrain. I also noticed that since the EnemySpawner script spawns instances of a prefab, I could make it spawn multiple types of enemies at once too or even curate a specific type of battle by specifying where to spawn which kind of enemy within the battle arena. There is potential for expansion here, I will probably try to explore this if I ever try making more levels in the future.

### To-do list

- Begin working on the obstacles and level design. Think about possible types of obstacles that would be interesting to interact with the current mechanics (destructible walls, opening doors by hitting a lever, etc...) and how the level could be designed with them in mind (giving the player enough space within the puzzle/obstacle area to build up the boomerang's momentum).

## Session Project: 2003D Breaker development: 1st level ((02/04/2026))

For this week, my goal was to work on the game’s first level and at least finish one obstacle. 

### Development process: Creating the first level

As mentioned in one of my earlier journals, this level will follow the following format:

1st obstacle => Battle area => 2nd obstacle => Battle area => 3rd obstacle => Battle area => 4th obstacle (Final)

With this in mind, I began selecting what types of obstacles will be present in this level. Since this is the first level, I need to choose obstacles that highlight the game’s mechanics and gameplay without being too difficult. So I choose to have the following obstacles:

1st obstacle: Climbing platforms

2nd obstacle: Walking on narrow passage

3rd obstacle: Pushing objects out of the way

4th obstacle (Final): Destroy the target

With the level’s design settled, I began creating a low-fidelity prototype of the level for testing purposes.

![StateExample](Media/LevelObstacle1.png)

I quickly created the level's first obstacle with the first battle area and immedieatly went to testing. However, something bizarre happened during this first test:

![StateExample](Media/EnemySpawnPositionInitialTest.gif)

The enemies spawned outside of their designated spawn area. To find the problem, I reopened the EnemySpawner script and looked for mistakes. And I found one mistake:

![StateExample](Media/ZCalculationMistake.png)

The MinZ and MaxZ variables mistakenly calculated using x values. So I corrected these formulas to use the right variables.

![StateExample](Media/ZCalculationFixed.png)

![StateExample](Media/EnemySpawnPositionFixed.gif)

Now the enemies spawn inside the spawn area. But I noticed that even when the battle area is just a simple plane, the enemies can get stuck outside of it. To avoid enemies being stuck outside of the battle area, I decided to constrain them within their spawn area.

I had to try a variety of methods to make this work since some of them led to errors. For example, the my first attempt of implementing this mechanic relied on collisions. I wanted to make each enemy object use collisions to recognize where the spawn area is and then pull the minX, maxX, minZ, and maxZ variables from it. However this didn't work due to variable conversion issues and compiler errors.

The second method that i tried was to use a list. The EnemySpawner script would create a list containing every enemy that it spawned and it would manage the position of each one of them, preventing them from going beyond the minX, maxX, minZ, and maxZ values.

![StateExample](Media/EnemySpawnerList.png)
![StateExample](Media/EnemySpawnerPositionConstrain.png)

I then tested this constrain system.

![StateExample](Media/EnemySpawnPositionConstrainTest.gif)

The enemies still flew beyond the spawn area's boundaries. I thought that it was another variable conversion error, but by returning to the EnemySpawner script, I noticed that I didn't write the code that enables the instantiated enemies to be added to the list where they will be managed. So I enabled adding the instantiated enemy objects to the list.

From this:

![StateExample](Media/EnemySpawnerListProblem.png)

To this:

![StateExample](Media/EnemySpawnerListAdd.png)

Then I tested this solution.

![StateExample](Media/EnemySpawnPositionConstrainFixed.gif)

The enemies are now constrained within their spawn area, which is the battle area itself. However, it seems like once an enemy is defeated, the begin to fly out of the battle area once again. This is probably due to the EnemySpawner attempting to interact with an object that is no longer there. I will fix this problem later as I do not have the knowledge required to to tackle this problem right now.

### Takeaways

Building and testing the level made me realize the impact of my initial testing area. I realize now that it was actually quite small and its small size led me to completely ignore how some of the game’s mechanics such as the boomerang or the enemies would behave in a large boundless area. Or how the player field of view comes into play when keeping track of the boomerang's position. I recognize that I wasn’t as through in my testing process as I thought I was and I understand now the importance of testing in different scenarios and situations in order to have a more comprehensive and complete look on what you are working on.

### To-do list

-Complete the prototype of the 1st level (Finish the last three obstacles and two other battle areas)

-Adjust the physics of the enemies (and maybe their speed too?) and the boomerang (prevent it from going too far away from the player).

## Session Project: 2003D Breaker development: 1st level ((09/04/2026))

For this week, my goal was to finish the game’s first level and create a playable test build for the gameplay demo period.

### Development process: Finishing the first level

Last week, I finished the first obstacle and tweaked the enemy spawner. This week's work started with creating the next three obstacles, the narrow passage, the objects you must push out of the way and the target that you must destroy.

![StateExample](Media/NarrowPassage.png)

The second obstacle was simply created dublicating and resizing a bunch of cubes. In a future revised version, I would like to create a custom mesh for this obstacle. But for testing purposes in an early prototype this feels sufficient.

![StateExample](Media/PushingObstacle.png)

The third obstacle was created using cubes and spheres. The cubes are platforms on which the spheres rest. In order to cross the void, you must jump on these platforms. But before doing so you must knock the spheres off of them. Each sphere has a rigidbody component to enable physics and their mass is greatly reduced (0.04) in order to make them easy to push.

For example, when the weight was left untouched, the spheres were very hard to push. That is why I reduced their weight.

![StateExample](Media/HeavyBallTest.gif)

When their weight was reduced, they became significanly easier to push. Which was my goal.

![StateExample](Media/LightBallTest.gif)

Then I created the final obstacle, starting with the script for the target itself.

![StateExample](Media/DestroyableTargetScript.png) 

It uses the same logic ase most other scripts that I use here for collisions. Except this time it looks specifically for the boomerang when something collides with it. When destroyed, it destroys the wall leading to the end of the level with it.

![StateExample](Media/DestroyableTargetTest.gif)

I applied a gold material on the target to make it stand out. Maybe it'll make it obvious that this is something you must hit with the boomerang in order to progress in the level.

![StateExample](Media/TargetDestroyObstacle.png)

The sphere behind the wall triggers the end of the level when the player strikes it with the boomerang. For the sake of the playable demo. I simply made the sphere invoke the GameOver method in the GameManager script which releads the level.

With the level being done, now I pivoted to adding elements to ensure that my demo build is not only playable but also give me, the designer, a good opportunity to test certain of the game's mechanics. Thus, I had to add safeguards if the player falls out of bounds, a life point system and adjusted the boomerang and enemy scripts to make use of the life point system in order to trigger a game over if the player runs out of life points.

### Development process: Gameplay additions for the demo build

To prevent the player from falling out of bounds, I created the returnToTerrain script which will be connected to large rectagles floating under the level. When the player collides with any of these rectangles. they will be teleported back to the level instead of falling infinitely.

![StateExample](Media/ReturnToTerrainScript.png)

When the player collides with a rectangle with the script equipped, their position will be edited to match that of an empty object positionned in the stage. Effectively teleporting them back on the stage. When I initially created this script, there was an issue with the teleportation. The player would get teleported, but then they would immedieatly return to their previous position. [Thanks to an answer from Unity forum user Zarenityx on the subject](https://discussions.unity.com/t/teleporting-character-issue-with-transform-position-in-unity-2018-3/221631/4), I learned that disabling the character controller before the teleport and reenabling it after was the key to making this work.

![StateExample](Media/returnToTerrainTest.gif)

With this solved, I then enabled the enemy and boomerang scripts to use the LoseLife() method in the GameManager script and set the player's lives to 5. When a player gets hit or falls out of bounds, they loose one life point. Loose all five and it is game over and they get sent back to the beginning of the level.

I also readjusted the movement of the enemies and the boomerang. I increased both their linear/angular damping, I slightly increassed their mass (0.01 => 0.02), and removed the normalization of the vectors behind the force applied onto them. These changes increased the boomerang's accuracy and removed its tendency of flying around you with a very large circular movement. The enemies also are now much more aggressive as they are quicker and more accurate too.

### Development Extras: Visual style

With the extra time I had left, I decided to experiment with Unity's graphical settings and post processing in order to begin working on the game's visual identity. 

I sarted with the global volume's post processing abilities: while testing out its various settings, I stumbled upon split toning. This setting allowed me to change the color of the shadows and highlights to obtain interesting results.

![StateExample](Media/SplitToning.png)

![StateExample](Media/SplitToningResult.png)

Then, in the PCRenderer, I cut adjusted the render scale to 50% to obtain a retro stylized look.

![StateExample](Media/50%RenderScale.png)

Finally, [I added a custom skybox obtained from an asset pack into the scene](https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353).

![StateExample](Media/CustomSkybox.png)

This is just the beginning of the development of the game's visual style. In future updates, I would definetly like to add custom models, textures and animations not only for the player's charater, but for the objects that compose the level too.

### Takeaways

Building the rest of the level was a fun activity and it was also very interesting to see how easy it is to vastly change look of a scene using post processing and other visual elements. Now that my game's mechanics have been realized and adapted for a playable demo, I was now able to dedicate some time to the game's visuals. The feedback I will recieve during playtests will shape my to-do list for the future of this project.