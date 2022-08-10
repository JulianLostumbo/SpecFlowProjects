Feature: Login
As a user I want to be able to login the app

@happyPath
Scenario Outline: Successfully login
	Given The user is in the main page
	When The user clicks Log In button
	And The user enter "specflow" in the username field
	And The user enter "Sf46@81" in the password field
	And The user clicks Log In button
	Then The user should see his username in the navbar

Scenario Outline: Invalid login when entering wrong credentials
	Given The user is in the main page
	When The user clicks Log In button
	And The user enter <username> in the username field
	And The user enter <pass> in the password field
	And The user clicks Log In button
	Then The error messaje is displayed as the following: "Login and/or password are wrong."

	Examples:
		| username     | pass        |
		| "user" | "password" |
		| "admin" | "123" |

Scenario Outline: Invalid login when leaving fields empty
	Given The user is in the main page
	When The user clicks Log In button
	And The user clicks Log In button
	Then The error messaje is displayed as the following: "The UserName field is required."
	And The error messaje is displayed as the following: "The Password field is required."