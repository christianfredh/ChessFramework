Feature: Moving a Rook
	I want the rook to be able 
	to move and capture 
	according to chess rules

Scenario: Move one step
	Given a new game
	And the game has just started
	When White move a2 to a3
	And Black move e7 to e5
	And  White move a1 to a2
	Then then there should be a white rook at a2
	And a1 should be empty
	And it should be Black's turn

Scenario: Capture
	Given a new game
	And the game has just started
	When White move a2 to a4
	And Black move e7 to e6
	And White move a1 to a3
	And Black move e6 to e5
	And White move a3 to b3
	And Black move e5 to e4
	And White move b3 to b7
	Then then there should be a white rook at b7
	And a black pawn should be captured
	And it should be Black's turn