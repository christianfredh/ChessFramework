Feature: Moving a Knight
	I want the knight to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's knight
	Given a new game
	And the game has just started
	When White move b1 to c3
	Then then there should be a white knight at c3
	And b1 should be empty
	And it should be Black's turn
