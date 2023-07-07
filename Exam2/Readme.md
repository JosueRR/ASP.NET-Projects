# Exam Summary

This repository contains the solution for an exam taken for the course CI-0126. The exam focused on testing the functionality of a school management application, specifically the CRUD operations for schools.

## About Project Structure

The project was made wih MVC asp.net 6.0 consists of the following components:

- **SchoolHandler**: A class that handles the interaction with the database and provides methods for CRUD operations on schools.
- **SchoolModel**: A model class representing a school with properties such as ID, name, province, state, number of classrooms, and public/private status.
- **SchoolController**: Controller of app
- **SchoolViews**: Views of app
- **SchoolHandlerTests**: Unit tests for the SchoolHandler class, covering the EditarSchool, CrearSchool, ObtenerSchools, and BorrarSchool methods.

## Unit Tests

The unit tests aim to ensure the correctness of the SchoolHandler class's methods:

- **EditarSchoolTest**: Verifies the functionality of the EditarSchool method by editing an existing school in the database and checking if the operation is successful.
- **CrearSchoolTest**: Tests the CreateSchool method by creating a new school with valid input and checking if it is successfully added to the database.
- **ObtenerSchoolsTest**: Tests the ObtenerSchools method by retrieving a list of schools from the database and verifying that the result is not null and contains at least one school.
- **BorrarSchoolTest**: Verifies the functionality of the BorrarSchool method by deleting a school from the database and checking if the operation is successful.

## Author

- Josué Retana Rodríguez

