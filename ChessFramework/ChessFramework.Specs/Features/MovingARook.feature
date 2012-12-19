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
