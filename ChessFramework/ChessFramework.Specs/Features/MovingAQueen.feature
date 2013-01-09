Feature: Moving a Queen
	I want the queen to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's left bishop
	Given a new game
	And the game has just started
	When White move e2 to e3
	And Black move e7 to e6
	And White move d1 to g4
	Then there should be a white queen at g4
	And d1 should be empty
	And it should be Black's turn

Scenario: Must protect king if in check
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move h7 to h5
	And White move a2 to a3
	And Black move h8 to h6
	And White move a3 to a4
	And Black move h6 to e6
	And White move a4 to a5
	And Black move e6 to e4
	Then White should be able to move d1 to
	| To |
	| e2 |