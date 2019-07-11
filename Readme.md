#Introduction 
Add iterations to teams in config automatically. 

#Getting Started
1. Create a personal token in Azure DevOps or TFS
2. Update appsettings.json file with your desired
3. Change personal access token.
4. Run!

        {
        "baseUrl": "https://tfs.server.com/",
        "collection": "DefaultCollection",
        "project": "Your project",
        "teams": [
            "DevOps",
            "Core",
            "Product",
            "Test",
            "Project Management"
        ],
        "iterationToAddToTeams": {
            "test/2021 August": {
            "attributes": {
                "startDate": "2021-10-15",
                "finishDate": "2022-10-31"
            }
            },
            "test/2019 Oktober": {
            "attributes": {
                "startDate": "2018-11-15",
                "finishDate": "2018-11-31"
            }
            }
        },
        "personalAccessToken": "wdgcdtvlhxsrbg6tcnzrphdlbc3sy2lldiehhtggrbolhz2zlqda"

        }


#Build and Test
Run test in Visual Studio and it will add and set active iterations on each team.

#Contribute
- Check if it works on Azure DevOps
- Add support for removing sprints from teams
