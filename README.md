### Test Approach and Reflections

For this test, in a time constrained environment, my primary goal was to focus on refactoring the solution such that it could be easily tested, as this brings business benefits from a regression safety point of view, but also encourages clean coding practices as I feel the two can go hand in hand.

After examining the code, I came to the conclusion that the blocker to testability of the PaymentService was the tight coupling with account storage concerns. This in mind, I began by writing tests to validate the business logic of the service, with an ignore flag applied. A test driven development approach if you will.

I then set about extracting the account storage concerns into a separate concern of project, interfaces, and concretions. This allowed me to inject the concern in a loosly coupled manner via dependency injection, meaning I could mock the results from the 'repository' application layer via the account service, and subsequently test the PaymentService with a range of success and failure scenarios.

With the payment service receiving full code coverage, I then looked towards architectural changes. This included a factory pattern implementation for selecting the account storage mechanism, abstracting away the need to know about which type of data store was being interacted with through a common interface, and allowing for simpler logic that didn't require an if statement to select the data store type.

Additional changes include the use of a 'ServiceResult' object, allowing me to return a success flag and error message where appropriate, along with an object to the caller itself. rather than relying on exceptions for flow control. I find these very useful for ensuring an application can handle an erroneous situation well at runtime.

Other subtle adjustments have taken place, such as minor refactors of the PaymentService business logic to improve readability via a private method to reduce cognitive complexity, but also the removal of account existence checks as these are effectively handled via a service result when fetching an account prior. I ultimately didn't opt to focus on refactoring the business logic for clarity or simplicity given my initial goal of focusing on testability, the regression protection provided by the tests themselves makes this a safer task for future endevours.

Given more time, I would have looked at the following adjustments:

 - Testing of infrastructure concerns, such as the account data store factory.
 - Testing of failure scenarios, such as the exceptions thrown by the account service.
 - Further refactoring of the business logic to improve readability and simplicity.
 - Implementation of a logging framework to capture errors and other information such as ILogger via Microsoft.Extensions.Logging. 
 - Async operations to allow for awaiting upon I/O bound tasks such as data store calls. Not required for this exercise, but a good practice for real world applications.

Overall I enjoyed the exercise, and I am grateful for the opportunity, for which you have my gratitude.



