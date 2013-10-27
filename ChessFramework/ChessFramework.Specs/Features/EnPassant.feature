Feature: En passant
	En passant is a special pawn capture which can occur immediately after 
	a player makes a double-step move from its starting position, 
	and an enemy pawn could have captured it had the pawn moved only one square forward.

    - the capturing pawn must be on its fifth rank;
    - the captured pawn must be on an adjacent file and move two squares in a single move (i.e. a double-step move);
    - the capture can only be done on the move turn immediately after the opposing pawn makes the double-step move (if not done then, the right to capture it en passant is lost).


Scenario: En passant
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move a7 to a6
	And White move e4 to e5
	And Black move d7 to d5
	When White move e5 to d6
	Then there should be a white pawn at d6
	And d5 should be empty
	And a total of 5 moves should be registered
	And a black pawn should be captured
	And it should be Black's turn

Scenario: Invalid En passant - not a double step
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move a7 to a6
	And White move e4 to e5
	And Black move d7 to d6
	When White move a2 to a3
	And Black move d6 to d5
	Then White should not be able to move e5 to d6

Scenario: Invalid En passant - not directly after
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move a7 to a6
	And White move e4 to e5
	And Black move d7 to d6
	When White move a2 to a3
	And Black move d6 to d5
	Then White should not be able to move e5 to d6
