Feature: AccountsOverView
	In order check the balances of each of the accounts
	As a Qa
	I want to test the accounts overview Functionality


@AccountsOverView
Scenario Outline: UITest - Test the Accounts Overview for Checking or Savings Bank Account 
    Given I have logged in and I am on the home page
	When I click on Open New Account link
	Then I should land on the Open New Account Page
	When I choose the <AccountType> 
	And when I choose any existing account
	And click on Open New Account Button
	Then I should see the success message
	When I click on Accounts Overview link
	Then I should land on the Accounts Overview Page
	And then I should be able to see the accounts I opened
	Examples:
	| AccountType | 
	| Checking    | 
	| Savings     |

@AccountsOverView
Scenario: Controllertest - GET Call to the Accounts Overview API
    Given I have logged in and I am on the home page
	When I click on Open New Account link
	Then I should land on the Open New Account Page
	When I choose the Checking
	And when I choose any existing account
	And click on Open New Account Button
	Then I should see the success message
	When I click on Accounts Overview link
	Then I should land on the Accounts Overview Page
	Then then I should be able to see the accounts I opened
	When I make a GET call to the Accounts Overview Controller
	Then I should get the response of the Accounts Overview call




