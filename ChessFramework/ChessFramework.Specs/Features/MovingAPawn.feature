Feature: Moving a Pawn
	I want the pawn to be able 
	to move and capture 
	according to chess rules

Scenario: Move one step from starting position
	Given a new game
	When I move e2 to e3
	Then then there should be a white pawn at e3
	And e2 should be empty

Scenario: Move two steps from starting position
	Given a new game
	When I move d2 to d4
	Then then there should be a white pawn at d4
	And d2 should be empty
