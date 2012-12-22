Feature: Moving a Bishop
	I want the bishop to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's left bishop
	Given a new game
	And the game has just started
	When White move d2 to d3
	And Black move e7 to e6
	And White move c1 to f4
	Then then there should be a white bishop at f4
	And c1 should be empty
	And it should be Black's turn
