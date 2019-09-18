Feature: OpenNewAccount
	In order to test the create account API
	As a QA
	I want to open a new account successfully


@OpenBankAccount 
Scenario Outline: UITest - Open a Checking or Savings Bank Account 
Given I have logged in and I am on the home page
	When I click on Open New Account link
	Then I should land on the Open New Account Page
	When I choose the <AccountType> 
	And when I choose any existing account
	And click on Open New Account Button
	Then I should see the success message
	Examples:
	| AccountType | 
	| Checking    | 
	| Savings     |

	
@OpenBankAccount 
Scenario: ControllerTest - Authentionation of Bank Account Controller
	Given I make a POST call to the CreateAccount Controller without credentials
	Then I should get an unauthorized status

@OpenBankAccount 
Scenario: ControllerTest - Post Call to get the Response of Bank Account Controller 
	When I click on Open New Account link
	Then I should land on the Open New Account Page
	Given I make a POST call to the CreateAccount Controller 
	Then I should get the response of the Bank Account Controller



	
