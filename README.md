Project Title: "Test" - A complete E2E automation Suite consisting of UI and Controller tests for a banking website using C# and Specflow.
Selenium for UI and RestSharp for API tests.

Versions Used in this Project:
Microsoft Visual Studio - 2017. Version 15.7.5
Microsoft .Net Framework. version 4.7.03
Specflow Version - 2.4.0
WebDriver Version - v4.0.30319
RestSharp Version - 4.0.30319
Chrome Driver Version - 77.0
Selenium WebDriver - 76.0

Getting Started
Install Visual Studio 2017
Make sure to download and Install Specflow packages
Reference - https://specflow.org/getting-started/#InstallSetup
To get started, clone the git repository to your local and pull the changes from the master.

Running the tests
Once the above steps are completed, build the project.
On successful build, you will be able to see 14 tests in the test explorer.
Right click on the entire test suite or any particular category to run/debug through the tests.

Break down of the framework:
Since I have used Specflow to develop my automation suite, you will see the following framework structure:
Test Project
	-->Properties
	-->References
	-->Control Steps - Implementation of the test control methods.
	-->Feature Files - Test Case/Scenario Design
	-->Helpers - Getters/Setters, API/Db helper methods 
	-->Hooks - Test data creation, background for the tests
	
Tags in the test:
The tags in the specflow test automation suite can be used to run particular set of tests while integrating with the CI/CD pipeline.

For Eg: In case if there are changes only to the "Accounts Overview" Controllers/API and if only that particular build is getting deployed, I can specify @AccountsOverview tag (as used in the test framework )in the VSTS CI/CD pipeline, to run only tests specific to AccountsOverview.

Also, I added the @SmokeTest tag, which has the UI tests that would particularly focus on making sure taht all the sites in the application are up and running and no site returns any error.

Using Hooks in the test Suite, executes a basic repititive test steps that can be shared across all the tets in the test suite.
The backgroud test data setup for the tests could be added under the Before/After Feature/Scenario methods under Hooks.
	

