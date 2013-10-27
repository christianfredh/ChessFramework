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
	Then there should be a white bishop at f4
	And c1 should be empty
	And it should be Black's turn

Scenario: Bishop cannot jump over other pieces
	Given a new game
	And the game has just started
	When White move e2 to e3
	And Black move b7 to b5
	Then White should be able to move f1 to
	| To |
	| b5 |
	| c4 |
	| d3 |
	| e2 |

Scenario: Must protect king if in check
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move d7 to d5
	And White move e4 to d5
	And Black move d8 to d5
	And White move a2 to a3
	And Black move d5 to e5
	Then White should be able to move f1 to
	| To |
	| e2 |