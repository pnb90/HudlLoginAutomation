# HudlLoginAutomation

A simple test automation suite for Phuoc's Hudl interview.

## Description

This test automation suite is written in C# and Selenium with NUnit. 

## Getting Started

### Dependencies

* NUnit
* Selenium.WebDriver
* Selenium.WebDriver.ChromeDriver

### TroubleShooting

* Most common error is that the ChromeDriver included is out of date. If this occurs, then update the ChromeDriver to match the version running on your local machine. Learn more here: https://www.google.com/chrome/update/

### Installing

* Contact a QA team member to get the appropriate .runsettings file.

### Executing program

* To run the test automation suite locally, navigate to the HudlLoginAutomation folder and run the following command in your terminal:

```
dotnet test --settings .runsettings
```

* Alternatively, if you have Visual Studio already installed
1. Open the solution locally.
2. Clean the solution.
3. Build the solution.
4. Open Test -> Test Explorer
5. Feel free to run/debug individually or as a group by either clicking the "Run All Tests in View" green arrow icon in the upper lefthand corner of the Test Explorer or by right-clicking the tests and selecting "Run" or "Debug."

### Future Steps 
* implementing a reporting system to be able to quickly diagnose and resolve errors
* implementing fake data for login probably by using Faker to avoid hardcoding personal emails and passwords
* adding API testing to speed up testing especially for more minor and repetitive test cases (i.e. null emails, etc.)
* mobile testing 
* testing in most common browsers 
* remember me testing with cookies
* better method of storing/obscuring sensitive data
