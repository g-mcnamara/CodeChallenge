# DocFX
- What is DocFX? Static document generation tool
- Multiplataform *Not* constranted to windows
- Runs on command line
- It needs .NET Code to work

## Install DocFX
- The instructions for the installation are in the DocFX page https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html
- In my case I used -choco- because it was installed together with the node libraries, using a command window in administrative mode
- Goto the solution folder
- run ` docfx init -q `
- This will create a new project alongside other Visual Studio projects.


## Configuring environment 
- To generate documentation **it is necessary to comment on the source code** because that is where the information will be extracted.

### Using **Visual Studio**
- The project file must indicate the location of the xml file where the comments will be replicated.
- Check that docfx.json has the correct path pointing to the project file in the `metadata` section

``` json
"src": [
        {
          "cwd" : "../",
          "files": [
            "projectname/**.csproj"
          ]
        }
	,]
```

### For environments using **using Visual Studio Code**
- Verify that the `metadata` section of the docfx.json file is pointing correctly to the root of the solution and that the list of` files` has all the extensions of the source code files that will be parsed

- Single project sample

``` json
"src": [
        {
          "cwd" : "../projectname/",
          "files": [
            "**.cs, 
			**.js"
          ]
        }
	,]
```

- Multi project sample

``` json
"src": [
        {
          "cwd" : "../",
          "files": [
            "projectname1/**.cs", 
			"projectname1/**.js",
			"projectname2/**.cs", 
			"projectname2/**.js"
          ]
        }
	,]
```

## Generating metadata
- This can be performed from:
	- **Developer Command Prompt For VS-X** 
	- **Developer Command Prompt inside Visual Studio**
	- **Command window**

- Verify that the working directory is set to `[solution directory]/docfx_project`
- Run the command to generate the metadata `docfx metadata docfx.json`


## Generating documentation site
- Once the metadata has been created

- To configure the correct place to host the documentation website within the Github repository, the docfx.json file in the `build` section needs to be modified to create the 'docs' directory at the root of the solution

``` json
	"dest": "../docs",
```

- Run the command `docfx build docfx.json` to build the documentation site
- This should generate a `docs` folder in the root of the solution with the content of the project documentation website.
- Finally, the site can be tested using the `docfx serve ..\docs` command. The resulting message will be the URL where the documentation can be browsed.

## Notes:
- Pushing the project to the GitHub repo, and setting up the option to use a Doc-Pages, the site can be browsed.
- Commands to generate the **metadata** and **build** the documentation can be automated in the CI pipeline






