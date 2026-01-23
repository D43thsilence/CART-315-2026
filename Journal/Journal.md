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


