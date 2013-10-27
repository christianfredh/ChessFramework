﻿Feature: Moving a Pawn
	I want the pawn to be able 
	to move and capture 
	according to chess rules

Scenario: Move one step from starting position
	Given a new game
	And the game has just started
	When White move e2 to e3
	Then then there should be a white pawn at e3
	And e2 should be empty
	And it should be Black's turn

Scenario: Move two steps from starting position
	Given a new game
	And the game has just started
	When White move d2 to d4
	Then then there should be a white pawn at d4
	And d2 should be empty
	And it should be Black's turn

Scenario: Simple capture
	Given a new game
	And the game has just started
	When White move d2 to d4
	And Black move e7 to e5
	And White move d4 to e5
	Then there should be a white pawn at e5
	And a black pawn should be captured
	And it should be Black's turn

Scenario: En passant
	Given a new game
	And the game has just started
	When White move e2 to e4
	And Black move a7 to a6
	And White move e4 to e5
	And Black move d7 to d5
	And White move e5 to d6
	Then there should be a white pawn at d6
	And d5 should be empty
	And a total of 5 moves should be registered
	And a black pawn should be captured
	And it should be Black's turn
