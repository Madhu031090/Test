Feature: LoginAndLogout
	In order to use the Parasoft Appilication
	As a QA
	I want to test the login functionality

@login
Scenario: Successful Login
	Given I am on the login page
	When I click on Register for the user to login
	Then I can successfully register and login to the application

@Logout
Scenario: Successful Logout
    Given I am on the login page
	When I click on Register for the user to login
	Then I can successfully register and login to the application
	When When I click on Logout
	Then I should be logged out of the application