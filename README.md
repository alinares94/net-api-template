# .Net API Template

API Template for Visual Studio.

To use the template you can download the [CleanArchitectureTemplate.zip](https://github.com/alinares94/net-api-template/blob/main/CleanArchitectureTemplate.zip) file and copy it to the directory {UserDirectory}\Documents\Visual Studio 2022\Templates\ProjectTemplates.

When the visual studio is opened again, the new template will appear as one more option.

## Architecture

| Project          | Description                                                        |
| ----------------- | ------------------------------------------------------------------ |
| API | Registers the different endpoints |
| Core.Application | Business logic |
| Core.Model | Model that agrees with what the database will return |
| Infrastructure.Db | Connection to databases |
| Infrastructure.External | Connection to external services such as Email, SMS, etc. |
| Test | Test on the business layer |

<img src="https://user-images.githubusercontent.com/54104479/224661709-7ff2e2eb-1c31-48ac-aae5-4acecbe0bbab.png" 
     data-canonical-src="https://user-images.githubusercontent.com/54104479/224661709-7ff2e2eb-1c31-48ac-aae5-4acecbe0bbab.png" 
     width="600" height="500"/>

### API

It contains only endpoint definitions and the *Middleware/Filter* that will be used to intercept errors or input/output logs.

To create new endpoints, new controllers must be created, which must never return a Model entity (*Core.Model*). They can only return system types like string, bool, etc. or DTO classes.

### Core.Application

It contains the business logic, among which we find:

- Definition of DTOs.
- Automappers.
- Validations of input DTOs.
- Service/repository interfaces.

Input and output values to this application layer must be DTOs. If you want to return an entity from the Model, you must use a DTO and transform one into another using Automapper.

### Core.Model

Definition of the database model or entities returned by database functions/procedures.

### Infrastructure.Db

Connections to databases through *Contexts* and repositories. Repositories will only contain simple queries and actions on the database, they will not contain object modifications or any logic.

Only Model entities or system types can be used as parameters or outputs in these classes.
