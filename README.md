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
    <Configuration>Release</Configuration>
    <Platform>Any CPU</Platform>
    <PublishDir>bin\Release\net7.0\publish\win-x64\</PublishDir>
    <PublishProtocol>FileSystem</PublishProtocol>
    <_TargetId>Folder</_TargetId>
    <TargetFramework>net7.0</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishReadyToRun>true</PublishReadyToRun>
    <PublishTrimmed>false</PublishTrimmed>
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
