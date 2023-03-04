Feature: APIAutomation

@Test @DataSource:Data/GetUserByID.xlsx
Scenario: 1)Get single user by ID
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>'
	And User executes the api call
	Then User should expect '<response_code>' response code

@Test @DataSource:Data/GetUserDelayed.xlsx
Scenario: 2)Get user (Delayed reponse)
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>'
	And User sets 'delay' query param value as '2'
	And User executes the api call
	Then User should expect '<response_code>' response code

@Test @DataSource:Data/CreateUser.xlsx
Scenario: 3)Create User
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>' for '<body>'
	And User executes the api call
	Then User should expect '<response_code>' response code

@Test @DataSource:Data/UpdateUser.xlsx
Scenario: 4)Update User
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>' for '<body>'
	And User executes the api call
	Then User should expect '<response_code>' response code

@Test @DataSource:Data/DeleteUser.xlsx
Scenario: 5)Delete User
	Given The test case title is '<testcase>'
	When User makes a '<method>' call at the '<endpoint>'
	And User executes the api call
	Then User should expect '<response_code>' response code