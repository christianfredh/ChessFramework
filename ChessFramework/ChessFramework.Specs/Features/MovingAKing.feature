Feature: Moving a King
	I want the king to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's king
	Given a new game
	And the game has just started
	When White move e2 to e3
	And Black move e7 to e6
	And White move e1 to e2
	Then then there should be a white king at e2
	And e1 should be empty
	And it should be Black's turn