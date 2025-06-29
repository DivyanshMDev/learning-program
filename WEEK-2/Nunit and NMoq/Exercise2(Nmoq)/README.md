# Exercise 2: NMoq Mocking Framework

## What I Built
A simple email sending system with unit tests that use mocking to avoid actually sending emails during testing.

## Projects
- **CustomerCommLib** - Main library with email functionality
- **CustomerComm.Tests** - Unit tests using NUnit and Moq

## Key Files
- MailSender.cs - Email sender interface and implementation
- CustomerComm.cs - Business logic class that uses dependency injection
- CustomerCommTests.cs - Unit tests with mocked email sender

## What I Learned
- How to use Moq to create fake objects for testing
- Dependency injection makes code easier to test
- Unit tests can run without external dependencies like email servers
- NUnit framework for writing and running tests

## How to Run
1. Open solution in Visual Studio
2. Build the project
3. Go to Test Explorer and run all tests

## Test Results
Tests pass successfully - the mock email sender works as expected and no real emails are sent during testing.

---
*Part of Cognizant Training Program - Week 2*
