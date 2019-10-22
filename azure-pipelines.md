# ASP.NET
# Build and test ASP.NET projects.
# Add steps that publish symbols, save build artifacts, deploy, and more:
# https://docs.microsoft.com/azure/devops/pipelines/apps/aspnet/build-aspnet-4

trigger:
- master
variables:
  solution: '**/*.sln'
  buildPlatform: 'Any CPU'
  buildConfiguration: 'Release'
stages:
  - stage : Build
    displayName: Restore & Build
    jobs:
       - job: Build
         pool:
            vmImage: 'windows-latest'
         steps:
         - task: NuGetToolInstaller@1
         - task: NuGetCommand@2
           inputs:
             restoreSolution: '$(solution)'
         - task: VSBuild@1
           inputs:
              solution: '$(solution)'
              msbuildArgs: '/p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:PackageLocation="$(build.artifactStagingDirectory)"'
              platform: '$(buildPlatform)'
              configuration: '$(buildConfiguration)'
  - stage: Test
    displayName: Unit Tests
    jobs:
       - job: Tests
         pool:
            vmImage: 'windows-latest'
         steps: 
         - task: VSTest@2
           inputs:
              platform: '$(buildPlatform)'
              configuration: '$(buildConfiguration)' 
  - stage: Deploy
    displayName: Deploy to Azure
    jobs:
       - job: Deploy_App
         pool:
            vmImage: 'windows-latest'
         steps: 
         - task: AzureRmWebAppDeployment@4
           inputs:
              ConnectionType: 'AzureRM'
              azureSubscription: 'rafa_dev (95b44dd6-5808-485e-9f1a-923eaeef3b37)'
              appType: 'webApp'
              WebAppName: 'rpr-aspnetb2c-wapp'
              packageForLinux: 'TaskWebApp.zip'
    #d:\a\1\a\TaskWebApp.zip
       - job: Deploy_Api
         pool:
            vmImage: 'windows-latest'
         steps: 
         - task: AzureRmWebAppDeployment@4
           inputs:
              ConnectionType: 'AzureRM'
              azureSubscription: 'rafa_dev (95b44dd6-5808-485e-9f1a-923eaeef3b37)'
              appType: 'webApp'
              WebAppName: 'rpr-aspnetb2c-wapi'
              packageForLinux: 'TaskService.zip'
    #d:\a\1\a\TaskWebApp.zip
