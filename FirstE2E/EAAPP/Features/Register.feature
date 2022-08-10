Feature: Register
	As a user I want to be able to create a new user in the website

@happyPath
Scenario: Successful registering
	Given The user is in the main page
	When The user clicks Register button in the navbar
	And The user enter "username" in the username field for registration
	And The user enter "Pas$word1234" in the password field for registration
	And The user enter "Pas$word1234" in the confirm password field for registration
	And The user enter "email@email.com" in the email field for registration
	And The user clicks Register button
	Then The user is redirected to the main page
	And The user sees the message "Hello username!" in the navbar

Scenario: Invalid registering when leaving all fields empty
	Given The user is in the main page
	When The user clicks Register button in the navbar
	And The user clicks Register button
	Then The user see the following error message: "The UserName field is required."
	And The user see the following error message: "The Password field is required."
	And The user see the following error message: "The Email field is required."

Scenario Outline: Invalid registering
	Given The user is in the main page
	When The user clicks Register button in the navbar
	And The user enter <username> in the username field
	And The user enter <password> in the password field
	And The user enter <confirmPassword> in the confirm password field
	And The user enter <email> in the email field
	And The user clicks Register button
	Then The user see the following single error message: <errorMessage>
	Examples: 
	| username | password | confirmPassword | email | errorMessage |
	| "username" | "12345" | "12345" | "email@email.com" | "The Password must be at least 6 characters long."      |
	| "username" | "12345abcde" | "12345abcde" | "email@email.com" | "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z')."      |
	| "username" | "12345" | "12345" | "email@email.com" | "Passwords must have at least one non letter or digit character."      |
	| "username" | "123455" | "123456" | "email@email.com" | "The password and confirmation password do not match."      |
	| "user" | "123456" | "123456" | "email@email.com" | "The UserName must be at least 6 charecters long."      |
	| "username" | "123456" | "123456" | "email" | "The Email field is not a valid e-mail address."      |
	| "username" | "123456" | "123456" | "julilostumbo.jl@gmail.com" | "Email 'julilostumbo.jl@gmail.com' is already taken."      |
