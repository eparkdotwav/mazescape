code written by: epark
github link: https://github.com/eparkdotwav
made in october 2023

this project is a game i made in unity with c# called mazescape.
mazescape utilizes skills i learned recently, like 
loading new screens, handling collisions, playing sounds,
using canvas ui elements, and changing game objects dynamically.

upon opening the build, a player must click start on the menuscreen.
they will then be taken to the main screen, where they spawn as a blue square.
the main objective of the game is to avoid walls (points will be lost for each wall touched)
and to collect as many gems as possible. the gems are worth different amounts of points
depending on their spawn rate, and they change dynamically as the game goes on.
in order to end the game, the player must catch the yellow gem at the end which is worth
an additional 20 points. the player's high score is then saved via player prefs, and the
menu screen will display it. if the player doesn't catch the yellow gem by the time
they're out of time, they then lose, and the game stops working. the player can
escape the game by pressing escape any time. pressing escape while in game will take the player
to the menu screen, and pressing escape while on the menu screen will then exit the game.