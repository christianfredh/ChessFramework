Feature: Moving a Knight
	I want the knight to be able 
	to move and capture 
	according to chess rules

Scenario: Move White's knight
	Given a new game
	And the game has just started
	When White move b1 to c3
	Then there should be a white knight at c3
	And b1 should be empty
	And it should be Black's turn

Scenario: Must protect king if in check
	Given a new game
	And the game has just started
	When White move e2 to e3
	And Black move d7 to d6
	And White move f1 to b5
	Then Black should be able to move b8 to
	| To |
	| c6 |
	| d7 |
