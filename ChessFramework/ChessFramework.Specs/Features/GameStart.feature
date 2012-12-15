Feature: Game Start
	When the game start
	I want the game set up correctly

Scenario: Starting a game
	Given a new game
	When the game starts
	Then the board should look like
	|     |     |     |     |     |     |     |		|
	| BRo | BKn | BBi | BQu | BKi | BBi | BKn | BRo |
	| BPa | BPa | BPa | BPa | BPa | BPa | BPa | BPa |
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	| WPa | WPa | WPa | WPa | WPa | WPa | WPa | WPa |
	| WRo | WKn | WBi | WQu | WKi | WBi | WKn | WRo |
	And it should be White's turn
	