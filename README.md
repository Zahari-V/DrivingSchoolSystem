# DrivingSchoolSystem

## Purpose

- An application that allows driving schools to provide their students with everything related to their courses.

## Infrastructure

![DatabaseDiagramDrivingSchoolApp](https://user-images.githubusercontent.com/117441759/207171108-75a6d28e-c6be-43e3-88ac-459aa427178d.PNG)

- ### Account Entity
Contains the business logic required for driving school accounts.

- ### Roles
1.Admin: Administrator of application (App has only one administrator) => Username: "Admin", Password: "user123"

2.Manager: Manager of driving school (Driving school has only one manager)

3.Instructor: Instructor in driving school

4.Student: Student in driving school

## Business Logic

- CRUD operations on Driving Schools, Accounts, Courses and Student Cards

- Registration and Authentication logic are described with comments in [DrivingSchoolSystem/Controllers/UserController.cs](https://github.com/Zahari-V/DrivingSchoolSystem/blob/master/DrivingSchoolSystem/Controllers/UserController.cs)

## Test Application

1.Login with ADMIN profile.

2.Create driving school in Admin/DrivingSchool/Add.

3.Must register manager of driving school with data which provided in adding driving school.

4.Login with manager which you registered.

5.You can add Account(Instructor or Student) and register with this Account. Also you can add Courses.

6.With the registered Accounts you can test functionality of application.

# !!!Application is not finished.