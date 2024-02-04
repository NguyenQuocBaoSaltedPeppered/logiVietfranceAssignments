# 1. API Design
## Description

Let's design an API to manage project lists for LOGI VIETFRANCE company. Know that Admin wants:

1. Create a new project Project creation information includes: project name, description, customer name, start date, end date (may or may not be present), project phases (development, testing, maintenance) . Each phase has a start time and may or may not have an end time. Each phase has a certain number of employees working on that project. For example, in the development stage there are 3 people: Quyet, Bao, Vu. The testing phase has Thao - Quyet - Bao, the maintenance phase has Quyet - Vu.
2. Edit project information
3. Delete 1 project
4. Get the list of existing projects
5. Add new employees to the project, each employee has a different role (Dev, Tester, Manager, etc)
## Requirements

Design APIs using the OpenAPI standard
