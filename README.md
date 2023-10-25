# PCRemoteControl (work in progress)

A windows service that makes it possible to control the keyboard and mouse on the PC remotely from a browser.

## How to publish executable and build installer

### Publish PCRemoteControl executable

Publish the PCRemoteControl project with a Folder profile with settings like theese:

```
<?xml version="1.0" encoding="utf-8"?>
<!--
https://go.microsoft.com/fwlink/?LinkID=208121.
-->
<Project>
  <PropertyGroup>
    <DeleteExistingFiles>false</DeleteExistingFiles>
    <ExcludeApp_Data>false</ExcludeApp_Data>
    <LaunchSiteAfterPublish>true</LaunchSiteAfterPublish>
    <LastUsedBuildConfiguration>Release</LastUsedBuildConfiguration>
    <LastUsedPlatform>Any CPU</LastUsedPlatform>
    <PublishProvider>FileSystem</PublishProvider>
    <PublishUrl>bin\Release\net7.0\publish\</PublishUrl>
    <WebPublishMethod>FileSystem</WebPublishMethod>
    <_TargetId>Folder</_TargetId>
    <SiteUrlToLaunchAfterPublish />
    <TargetFramework>net7.0</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishReadyToRun>true</PublishReadyToRun>
    <ProjectGuid>cd43d481-aca3-4f17-b699-afe102bb6123</ProjectGuid>
    <SelfContained>true</SelfContained>
  </PropertyGroup>
</Project>
```

Theese are the important publish settings:
* Deployment mode: Self-contained
* Produce single file: checked
* Enable ReadyToRun compilation: checked
* Trim unused assemblies (in preview): unchecked

### Build PCRemoteControlSetup installer

Build the PCRemoteControlSetup project with the Release configuration.

The MSI installer is then located here:

```
[VSProjectsFolder]\PCRemoteControl\PCRemoteControlSetup\bin\x64\Release\
```
