# Snake and Ladders
Flexible game of snakes and ladders that can be played on any size board. Objects are randomly generated for players to go up and down.

This is used to demonstrate OOP relationship principles through practical examples. The class diagram follows along with a description of the relationships made between classes:

![Class diagram](/ClassDiagram.png)

###Composition
Relationship where parts of the whole are not shareable as seen between:
- Game and Dice
- Game and Board
- Board and Cell

###Aggregation
Relationship where parts of the whole are shareable as seen between:
- Game and Player
- Cell and Player
- Object and Cell
