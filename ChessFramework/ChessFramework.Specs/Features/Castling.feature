Feature: Castling
	Castling is a special move in 
	the game of chess involving the 
	king and either of the original 
	rooks of the same color.

	Castling is permissible if and only if all of the following conditions hold:

	The king has not previously moved.
	The chosen rook has not previously moved.
	There are no pieces between the king and the chosen rook.
	The king is not currently in check.
	The king does not pass through a square that is under attack by enemy pieces.
	The king does not end up in check (true of any legal move).
	The king and the chosen rook are on the same rank.


Scenario: White's kingside casteling
	Given a new game
	And the game has just started
	When White move g1 to h3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move f1 to e2
	And Black move e5 to e4
	And White move e1 to g1
	Then there should be a white king at g1
	And there should be a white rook at f1
	And e1 should be empty
	And h1 should be empty
	And it should be Black's turn

	
Scenario: White's queenside casteling
	Given a new game
	And the game has just started
	When White move b1 to a3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move d2 to d3
	And Black move e5 to e4
	And White move c1 to d2
	And Black move d7 to d6
	And White move d1 to e2
	And Black move d6 to d5
	And White move e1 to c1
	Then there should be a white king at c1
	And there should be a white rook at d1
	And e1 should be empty
	And a1 should be empty
	And it should be Black's turn

Scenario: Black's kingside casteling
	Given a new game
	And the game has just started
	When White move a2 to a3
	And Black move g8 to h6
	And White move a3 to a4
	And Black move e7 to e6
	And White move a4 to a5
	And Black move f8 to e7
	And White move a5 to a6
	And Black move e8 to g8
	Then there should be a black king at g8
	And there should be a black rook at f8
	And e8 should be empty
	And h8 should be empty
	And it should be White's turn

Scenario: Black's queenside casteling
	Given a new game
	And the game has just started
	When White move h2 to h3
	And Black move b8 to a6
	And White move h3 to h4
	And Black move e7 to e6
	And White move h4 to h5
	And Black move d8 to e7
	And White move h5 to h6
	And Black move d7 to d6
	And White move b2 to b3
	And Black move c8 to d7
	And White move b3 to b4
	And Black move e8 to c8
	Then there should be a black king at c8
	And there should be a black rook at d8
	And e8 should be empty
	And a8 should be empty
	And it should be White's turn

Scenario: White's kingside casteling - Cannot castle if king has moved
	Given a new game
	And the game has just started
	When White move g1 to h3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move f1 to e2
	And Black move e5 to e4
	And White move e1 to f1
	And Black move a7 to a6
	And White move f1 to e1
	And Black move a6 to a5
	Then White should not be able to move e1 to g1
	
Scenario: White's queenside casteling - Cannot castle if king has moved
	Given a new game
	And the game has just started
	When White move b1 to a3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move d2 to d3
	And Black move e5 to e4
	And White move c1 to d2
	And Black move d7 to d6
	And White move d1 to e2
	And Black move d6 to d5
	And White move e1 to d1
	And Black move h7 to h6
	And White move d1 to e1
	And Black move h6 to h5
	Then White should not be able to move e1 to c1
	
Scenario: Black's kingside casteling - Cannot castle if king has moved
	Given a new game
	And the game has just started
	When White move a2 to a3
	And Black move g8 to h6
	And White move a3 to a4
	And Black move e7 to e6
	And White move a4 to a5
	And Black move f8 to e7
	And White move a5 to a6
	And Black move e8 to f8
	And White move b2 to b3
	And Black move f8 to e8
	And White move b3 to b4
	Then Black should not be able to move e8 to g8

Scenario: Black's queenside casteling - Cannot castle if king has moved
	Given a new game
	And the game has just started
	When White move h2 to h3
	And Black move b8 to a6
	And White move h3 to h4
	And Black move e7 to e6
	And White move h4 to h5
	And Black move d8 to e7
	And White move h5 to h6
	And Black move d7 to d6
	And White move b2 to b3
	And Black move c8 to d7
	And White move b3 to b4
	And Black move e8 to d8
	And White move g2 to g3
	And Black move d8 to e8
	And White move g3 to g4
	Then Black should not be able to move e8 to c8

Scenario: White's kingside casteling - Cannot castle if rock has moved
	Given a new game
	And the game has just started
	When White move g1 to h3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move f1 to e2
	And Black move e5 to e4
	And White move h1 to g1
	And Black move a7 to a6
	And White move g1 to h1
	And Black move a6 to a5
	Then White should not be able to move e1 to g1
	
Scenario: White's queenside casteling - Cannot castle if rock has moved
	Given TODO
	
Scenario: Black's kingside casteling - Cannot castle if rock has moved
	Given TODO

Scenario: Black's queenside casteling - Cannot castle if rock has moved
	Given TODO

Scenario: White's kingside casteling - Cannot castle if there are pieces in between
	Given a new game
	And the game has just started
	When White move g1 to h3
	And Black move e7 to e6
	And White move e2 to e3
	And Black move e6 to e5
	And White move f1 to e2
	And Black move e5 to e4
	And White move h1 to g1
	And Black move a7 to a6
	And White move g1 to h1
	And Black move a6 to a5
	Then White should not be able to move e1 to g1

Scenario: Cannot castle if king is in check
	Given TODO
Scenario: Cannot castle if king would pass through a square that is under attack
	Given TODO
Scenario: Cannot castle if king would would end up in check
	Given TODO
Scenario: Cannot castle if king and chosen rook is not on the same rank (same as second?)
	Given TODO