Feature: Promotion
	Pawns promote to Knight, Bishop, Rook or Queen
	when reaching 8th rank for White 
	or 1st rank for Black 

Scenario: Queen promotion
	Given a new game
	And the game has just started
	When White move c2 to c4
	And Black move b7 to b5
	And White move c4 to b5
	And Black move b8 to a6
	And White move b5 to b6
	And Black move f7 to f5
	And White move b6 to b7
	And Black move f5 to f4
	And White promotes to queen when moving b7 to b8
	Then there should be a white queen at b8
	And it should be Black's turn

Scenario: Rook promotion
	Given a new game
	And the game has just started
	When White move c2 to c4
	And Black move b7 to b5
	And White move c4 to b5
	And Black move b8 to a6
	And White move b5 to b6
	And Black move f7 to f5
	And White move b6 to b7
	And Black move f5 to f4
	And White promotes to rook when moving b7 to b8
	Then there should be a white rook at b8
	And it should be Black's turn

Scenario: Bishop promotion
	Given a new game
	And the game has just started
	When White move c2 to c4
	And Black move b7 to b5
	And White move c4 to b5
	And Black move b8 to a6
	And White move b5 to b6
	And Black move f7 to f5
	And White move b6 to b7
	And Black move f5 to f4
	And White promotes to bishop when moving b7 to b8
	Then there should be a white bishop at b8
	And it should be Black's turn

Scenario: Knight promotion
	Given a new game
	And the game has just started
	When White move c2 to c4
	And Black move b7 to b5
	And White move c4 to b5
	And Black move b8 to a6
	And White move b5 to b6
	And Black move f7 to f5
	And White move b6 to b7
	And Black move f5 to f4
	And White promotes to knight when moving b7 to b8
	Then there should be a white knight at b8
	And it should be Black's turn
