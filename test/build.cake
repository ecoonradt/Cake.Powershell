#addin "Cake.Powershell"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");





///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Powershell-Script")
    .Description("Run an example powershell command")
    .Does(() =>
	{
		Information("Calling Powershell Script");

		StartPowershellScript("Write-Host 'hello world'");

		StartPowershellScript("Get-Process", new PowershellSettings()
		{
			FormatOutput = true,
			LogOutput = true
		});

		StartPowershellScript("Stop-Service", new PowershellSettings()
		{
			FormatOutput = true,
			LogOutput = true
		}.WithArguments(args => 
		{ 
			args.AppendQuoted("MpsSvc"); 
		}));
	});



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Powershell-Script");





///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);