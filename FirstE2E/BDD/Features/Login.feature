Feature: Login
As a user I want to be able to login the app


Scenario Outline: Successfully login
	Given The user is in the main page
	When The user clicks Sign In button
	And The user enter "username" in the username field
	And The user enter "password" in the password field
	And The user enter clicks Sign In button
	And The user reload the page
	Then The user should see his username in the navbar

Scenario Outline: Invalid login
	Given The user is in the main page
	When The user clicks Sign In button
	And The user enter <username> in the username field
	And The user enter <pass> in the password field
	And The user enter clicks Sign In button
	Then The error messaje is displayed as the following: "Login and/or password are wrong."

	Examples:
		| username     | pass        |
		| "user" | "password" |
		| "admin" | "123" |
