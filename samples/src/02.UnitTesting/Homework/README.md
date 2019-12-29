## Homework

### Requirements
Extend functionality of the library application: 
- add date assignments during rent process  
- implement all not implement services  
- add return book function. It should delete record fro UserBook storage  
- add book history action. New records which tracks all actions performed in library. (optional)  
- all of functionality should be covered by tests unit or integration  

### Common Mistakes
  
  
------------  
####Dev Process issues  
**Name** | **Issue** | **How to Fix**
------------ | ------------- | -------------
Bad timing for submitting work | Submitting results at the very end of deadline | Take into account time of review and time for later changes in your program.  Submit your work earlier than deadline.  In case of VCS commit regularly and in small pieces. Send them on pre-review as well  
  
  
------------  
####Technical Issues  
**Name** | **Issue** | **How to Fix**
------------ | ------------- | -------------
.NET Framework version | Random versions for projects  | Use target framework, defined in task. It will be 4.7.2 
Nugets and components | Manu unnecessary installed nugets | Do not install test adapters, runners etc. via nuget. They break solution for reviewer 
Test framework | Not support test framework was used | Use test framework defined in task or in approved software (it will be NUnit) 
  
  
------------  
####Design Issues
**Name** | **Issue** | **How to Fix**
------------ | ------------- | -------------
“Detached” methods | Added methods to classes without adding them to interface | Always add methods to interface first. 
DateTime conversions | Creating datetime objects from string. | Create DateTime using constructor or builder methods 
Incorrect usage of FluentAssertion  nuget package| Usage of Should().Equals() is incorrect. | Do not use fluent assertion at all. All test frameworks have asserts out of the box. Read docs for package and search for examples on the internet. 
Incorrect usage of Moq | No good mocks setup, TestDelegates everywhere | Do not use moq at all. Or read docs and search for examples. For this library there are literally thousands of them 
Tests are failing Thorough principle | Methods were covered only with positive or only with negative cases. Different variations of parameters were not used | Think of different use cases or situations for your testing classes or scenarios. If your method covered only by one test it is probably not fully covered
