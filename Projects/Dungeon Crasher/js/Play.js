class Play extends Phaser.Scene {
    constructor() {
        super({
            key: `Play`
        });
    }

    create() {

        // Creates the stage where the game is played
        const map = this.make.tilemap({ key: `dungeon` });
        const tileset = map.addTilesetImage(`Dungeon_01 Tileset`, `tiles`);
        const backgroundColorLayer = map.createLayer('Bottomless Pit', tileset, 0, 0);
        const backgroundLowerWalls = map.createLayer('Lower Walls Extra', tileset, 0, 0);
        const backgroundWalls = map.createLayer('Lower Walls', tileset, 0, 0);
        const groundLayer = map.createLayer('Ground', tileset, 0, 0);
        const wallsLayer = map.createLayer('Walls', tileset, 0, 0)

        // Creates the level's collisions
        wallsLayer.setCollisionByProperty({ collides: true })
        groundLayer.setCollisionByProperty({ collides: true })
        backgroundWalls.setCollisionByProperty({ collides: true })
        backgroundLowerWalls.setCollisionByProperty({ collides: true })
        backgroundColorLayer.setCollisionByProperty({ collides: true })

        // Creates the the player avatar and his collisions
        this.avatar = this.physics.add.sprite(88, 115, `playerCharacter`);
        this.avatar.scale = 1;
        this.avatar.speed = 4500;
        this.avatar.setMaxVelocity(700, 700);
        this.physics.add.collider(this.avatar, wallsLayer);
        this.physics.add.collider(this.avatar, groundLayer);
        this.physics.add.collider(this.avatar, backgroundWalls);
        this.physics.add.collider(this.avatar, backgroundLowerWalls);
        this.physics.add.collider(this.avatar, backgroundColorLayer);

        // Initiates the character's animations
        this.avatar.play('run animation');

        // Creates the variables that count how many enemies are onscreen and how many enemies can be onscreen at once
        this.spawnedEnemies = 0
        this.maxEnemyCount = 4

        // Sets up the display of the player's score
        let style = {
            fontFamily: `sans-serif`,
            fontSize: `12px`,
            fill: `#ffffff`,
        };
        this.score = 0
        this.scoreText = this.add.text(88, 78, 'Score = 0', style);

        // Create the basic controls
        this.cursors = this.input.keyboard.createCursorKeys();

        // Sets up the various cameras in the game
        this.cameras.main.setSize(200, 160);
        this.cam2 = this.cameras.add(200, 0, 200, 160);
        this.cam3 = this.cameras.add(0, 160, 200, 160);
        this.cam4 = this.cameras.add(200, 160, 200, 160);

        this.cameras.main.setBounds(70, 60, 960, 960);
        this.cam2.setBounds(690, 60, 800, 640);
        this.cam3.setBounds(70, 750, 800, 640);
        this.cam4.setBounds(690, 750, 800, 640);

        // Creates the pixelated transition & visual effect when exiting the title screen and entering the game
        const fxCamera = this.cameras.main.postFX.addPixelate(40);
        this.add.tween({
            targets: fxCamera,
            duration: 700,
            amount: -1,
        });
        const fxCamera2 = this.cam2.postFX.addPixelate(40);
        this.add.tween({
            targets: fxCamera2,
            duration: 700,
            amount: -1,
        });
        const fxCamera3 = this.cam3.postFX.addPixelate(40);
        this.add.tween({
            targets: fxCamera3,
            duration: 700,
            amount: -1,
        });
        const fxCamera4 = this.cam4.postFX.addPixelate(40);
        this.add.tween({
            targets: fxCamera4,
            duration: 700,
            amount: -1,
        });

        // Sets the bounds of the world
        this.physics.world.setBounds(0, 0, 960, 960);
        this.avatar.setCollideWorldBounds(true);
    }


    // Continuously checks for player input and manages the number of enemies and when/where to spawn them
    update() {
        this.handleInput();
        this.handleEnemies();
    }

    // Removes the enemy lizards after the player has collided with them, makes the enemy counter go down by 1 and makes the score counter count up by 1
    destroyEnemy(playerCharacter, enemy) {
        enemy.destroy();
        this.spawnedEnemies = this.spawnedEnemies - 1;
        this.score = this.score += 1
        this.scoreText.setText('Score: ' + this.score)
    }

    // Spawns enemy lizards that the player must collide into to defeat
    handleEnemies() {
        if (this.spawnedEnemies == 0) {

            for (let i = 0; i < this.maxEnemyCount; i++) {
                if (i == 0) {
                    let x = random(88, 265)
                    let y = random(78, 206)
                    this.lizard = this.physics.add.sprite(x, y, `lizardIdle`);
                    this.lizard.setImmovable(true);
                    this.lizard.scale = 1.4;
                    this.lizard.play('lizard idle');

                    // Allows the players to defeat the lizards once they collide/overlap with them
                    this.physics.add.overlap(this.avatar, this.lizard, this.destroyEnemy, null, this);
                }
                if (i == 1) {
                    let x = random(88, 265)
                    let y = random(763, 882)
                    this.lizard[i] = this.physics.add.sprite(x, y, `lizardIdle`);
                    this.lizard[i].setImmovable(true);
                    this.lizard[i].scale = 1.4;
                    this.lizard[i].play('lizard idle');
                    this.physics.add.overlap(this.avatar, this.lizard[i], this.destroyEnemy, null, this);
                }
                if (i == 2) {
                    let x = random(696, 872)
                    let y = random(78, 206)
                    this.lizard[i] = this.physics.add.sprite(x, y, `lizardIdle`);
                    this.lizard[i].setImmovable(true);
                    this.lizard[i].scale = 1.4;
                    this.lizard[i].play('lizard idle');
                    this.physics.add.overlap(this.avatar, this.lizard[i], this.destroyEnemy, null, this);
                }
                if (i == 3) {
                    let x = random(696, 872)
                    let y = random(763, 882)
                    this.lizard[i] = this.physics.add.sprite(x, y, `lizardIdle`);
                    this.lizard[i].setImmovable(true);
                    this.lizard[i].scale = 1.4;
                    this.lizard[i].play('lizard idle');
                    this.physics.add.overlap(this.avatar, this.lizard[i], this.destroyEnemy, null, this);
                }
                // Sets the number of spawned enemies to 4 using the highest amounts of for loops
                this.spawnedEnemies = i + 1
            }
        }
    }

    handleInput() {
        // Handles player 1's movement and the size changes and attacks of both players
        this.input.keyboard.on('keydown', event => {

            if (event.keyCode === 87) {
                this.avatar.setGravityY(-this.avatar.speed);
            }
            else if (event.keyCode === 83) {
                this.avatar.setGravityY(this.avatar.speed);
            }

            else if (event.keyCode === 65) {
                this.avatar.setGravityX(-this.avatar.speed);
            }

            else if (event.keyCode === 68) {
                this.avatar.setGravityX(this.avatar.speed);
            }
        });

        // Makes player 1 stop moving when the movement keys are released
        this.input.keyboard.on('keyup', event => {

            if (event.keyCode === 87) {
                this.avatar.setGravityY(0);
                this.avatar.setVelocityY(0);
            }
            else if (event.keyCode === 83) {
                this.avatar.setGravityY(0);
                this.avatar.setVelocityY(0);
            }

            else if (event.keyCode === 65) {
                this.avatar.setGravityX(0);
                this.avatar.setVelocityX(0);
            }

            else if (event.keyCode === 68) {
                this.avatar.setGravityX(0);
                this.avatar.setVelocityX(0);
            }
        });
    }
}
