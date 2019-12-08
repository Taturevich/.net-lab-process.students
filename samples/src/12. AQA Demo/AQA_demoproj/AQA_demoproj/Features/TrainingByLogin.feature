Feature: TrainingByLogin
	As a user
	I want to be able to login site
	So I can do it from login form

Scenario: Login to training.by is failed with wrong credentials
	Given User is on training.by
	When User clicks Login button
	And Enters "ivan_taturevich@epam.com" to user name input
	And Enters "asda" to password field
	And Clicks Sign In button on login form
	Then Login form has error "Login failed. Please try again."

