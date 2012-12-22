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
	Then then there should be a white queen at g4
	And d1 should be empty
	And it should be Black's turn
