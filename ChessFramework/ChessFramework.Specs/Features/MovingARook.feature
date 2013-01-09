Feature: Moving a Rook
	I want the rook to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's left rook
	Given a new game
	And the game has just started
	When White move a2 to a3
	And Black move e7 to e5
	And  White move a1 to a2
	Then there should be a white rook at a2
	And a1 should be empty
	And it should be Black's turn

Scenario: Move Black's right rook
	Given a new game
	And the game has just started
	When White move e2 to e3
	And Black move h7 to h5
	And  White move d2 to d3
	And Black move h8 to h6
	Then there should be a black rook at h6
	And h8 should be empty
	And it should be White's turn

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
	Then there should be a white rook at b7
	And a black pawn should be captured
	And it should be Black's turn